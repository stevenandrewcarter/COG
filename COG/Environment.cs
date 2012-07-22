using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Clockwork.Agents;
using Clockwork.Agents.ServiceAgents;
using Clockwork.Execution;
using Clockwork.Telegram;

namespace Clockwork {
  /// <summary>
  /// Maintains environment objects, such as agents
  /// </summary>
  public class Environment : BackgroundWorker {
    #region Events

    public delegate void NewAgentCallBack(object sender, ref Agent agent);
    public event NewAgentCallBack NewAgent;
    public delegate void DeleteAgentCallBack(object sender, ref Agent agent);
    public event DeleteAgentCallBack DeleteAgent;

    public delegate void TimerCallBack(object sender, int iteration, TimeSpan time);
    public event TimerCallBack TimerChange;

    public delegate void StatUpdateCallBack(object sender, STATISTIC stat, double amount);
    public event StatUpdateCallBack StatUpdate;

    public delegate void CompleteCallBack(object sender);
    public event CompleteCallBack Complete;

    #endregion

    // A list representing each agent currently in the environment
    private List<Agent> agents;
    private List<string> results;
    private Dictionary<STATISTIC, double> stats;
    private ExecutionTree executionTree;
    private MessageQueue messageQueue;
    // Drawing elements
    private Agent selectedAgent;
    private ImageList entities;
    private BufferedGraphics device;
    private Random rnd;
    private int speed;
    private double populationSize;
    private int iterations;
    private int duration;
    private TimeSpan timer;
    // Population Average
    private double totAgents;
    private double readings;

    public Environment(BufferedGraphics g, ImageList newEntities, int size, int newIterations, int newDuration) {
      rnd = new Random(System.Environment.TickCount);
      stats = new Dictionary<STATISTIC, double>();
      results = new List<string>();
      messageQueue = new MessageQueue();
      Environment a = this;
      executionTree = new ExecutionTree(ref a);
      entities = newEntities;
      device = g;
      WorkerSupportsCancellation = true;
      speed = 5;
      // Determine the percent chance that a new agent will be introduced into the environment.
      // The higher the chance the more likely the size of the population will be larger.
      if (size == 0)
        populationSize = 0.10;
      else if (size == 1)
        populationSize = 0.25;
      else if (size == 2)
        populationSize = 0.50;
      // Set the run parameters
      iterations = newIterations;
      duration = newDuration * 60;
      timer = new TimeSpan();
    }

    #region Properties

    public List<Agent> Agents { get { return agents; } }

    public ExecutionTree Execution { get { return executionTree; } }

    public int SimulationSpeed { get { return speed; } set { speed = value; } }

    #endregion

    #region Methods

    public void UpdateStat(STATISTIC stat, double amount) {
      if (stats.ContainsKey(stat))
        stats[stat] += amount;
      else
        stats.Add(stat, amount);
      if (StatUpdate != null) StatUpdate(this, stat, stats[stat]);
    }

    /// <summary>
    /// Perform a hit test at the location in the environment
    /// </summary>
    /// <param name="x">X-Point of the environment</param>
    /// <param name="y">Y-Point of the environment</param>
    /// <returns>Selected agent if any</returns>
    public Agent Selected(float x, float y) {
      if (selectedAgent != null) {
        selectedAgent.Selected = false;
        selectedAgent = null;
      }
      for (int i = 0; i < agents.Count; i++) {
        Agent a = agents[i];
        if (a.Intersect(new PointF(x, y))) {
          selectedAgent = a;
        }
      }
      if (selectedAgent != null)
        selectedAgent.Selected = true;
      return selectedAgent;
    }

    public void New() {
      if (agents != null && agents.Count > 0) {
        while (agents.Count > 0) {
          Agent agent = agents[agents.Count - 1];
          RemoveAgent(agent);
        }
      }
      agents = new List<Agent>();
      Environment a = this;
      messageQueue = new MessageQueue();
      if (executionTree == null)
        executionTree = new ExecutionTree(ref a);
      Agent operatorAgent = AddNewAgent(AGENT_TYPE.AGENT_OPERATOR, entities.Images[(int)AGENT_TYPE.AGENT_OPERATOR]);
      operatorAgent.Name = "Operator";
      Agent controllerAgent = AddNewAgent(AGENT_TYPE.AGENT_CONTROLLER, entities.Images[(int)AGENT_TYPE.AGENT_CONTROLLER]);
      controllerAgent.Name = "Controller";
      timer = new TimeSpan();
      stats = new Dictionary<STATISTIC, double>();
      stats.Add(STATISTIC.STOCKPRODUCED, 0);
      stats.Add(STATISTIC.STOCKSENT, 0);
      stats.Add(STATISTIC.STOCKLOST, 0);
      stats.Add(STATISTIC.STOCKDELIVERED, 0);
      stats.Add(STATISTIC.STOCKDELIVEREDUSED, 0);
      stats.Add(STATISTIC.STOCKDELIVEREDLOST, 0);
      stats.Add(STATISTIC.PRODUCTPRODUCED, 0);
      stats.Add(STATISTIC.PRODUCTPRODUCEDUSED, 0);
      stats.Add(STATISTIC.PRODUCTPRODUCEDLOST, 0);
      stats.Add(STATISTIC.PRODUCTDELIVERED, 0);
      totAgents = 0;
      readings = 0;
    }

    /// <summary>
    /// Provides cycles to each agent in the environment to allow
    /// the agent to move, think, etc
    /// </summary>
    private void DoAgentWork() {
      for (int i = 0; i < agents.Count; i++) {
        Agent a = agents[i];
        if (!a.Decay()) {
          a.Execute();
          a.Draw();
        } else {
          // The agents lifetime has expired so remove it from the environment
          RemoveAgent(a);
        }
      }
    }

    /// <summary>
    /// Determines the current agent population. If new agents should be added.
    /// </summary>
    private void GenerateAgentPopulation() {
      // 25% of the time a new random agent is added to the environment
      double newAgentChance = rnd.NextDouble();
      if (newAgentChance <= populationSize) {
        // A new agent is to be added to the environment
        // For now only logistics agents can be added
        int type = rnd.Next(0, 4);
        AddNewAgent((AGENT_TYPE)(type), entities.Images[type]);
      }
    }

    /// <summary>
    /// Background thread which performs the execution of the environment.
    /// </summary>
    /// <param name="e">Nothing at the moment is passed through the EventArgs</param>
    protected override void OnDoWork(DoWorkEventArgs e) {
      // Clear the execution plan
      executionTree.Reset();

      while (!CancellationPending && iterations > 0) {
        long tick = DateTime.Now.Ticks;
        device.Graphics.Clear(Color.White);
        GenerateAgentPopulation();
        DoAgentWork();
        device.Render();
        totAgents += agents.Count;
        readings++;
        tick = DateTime.Now.Ticks - tick;
        timer = timer.Add(new TimeSpan(tick));
        if (timer.TotalSeconds >= duration) {
          string r = iterations.ToString() + "," +
                     (totAgents / readings).ToString() + "," +
                     stats[STATISTIC.STOCKPRODUCED].ToString() + "," +
                     stats[STATISTIC.STOCKSENT].ToString() + "," +
                     stats[STATISTIC.STOCKLOST].ToString() + "," +
                     stats[STATISTIC.STOCKDELIVERED].ToString() + "," +
                     stats[STATISTIC.STOCKDELIVEREDUSED].ToString() + "," +
                     stats[STATISTIC.STOCKDELIVEREDLOST].ToString() + "," +
                     stats[STATISTIC.PRODUCTPRODUCED].ToString() + "," +
                     stats[STATISTIC.PRODUCTPRODUCEDUSED].ToString() + "," +
                     stats[STATISTIC.PRODUCTPRODUCEDLOST].ToString() + "," +
                     stats[STATISTIC.PRODUCTDELIVERED].ToString() + "\n";
          results.Add(r);
          iterations--;
          New();
        }
        if (TimerChange != null) TimerChange(this, iterations, timer);
        Thread.Sleep(speed * 100);
      }
    }

    protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e) {
      try {
        using (FileStream fs = File.Create("RESULTS" + DateTime.Now.ToString("yyyyMMddmm") + ".txt")) {
          foreach (string s in results) {
            byte[] info = new UTF8Encoding(true).GetBytes(s);
            fs.Write(info, 0, info.Length);
          }
        }
      } catch (Exception ex) {
        MessageBox.Show("While attempting to save the results file, the following error occured.\n" + ex.Message, "COG Model Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      if (Complete != null) Complete(this);
    }

    public bool RemoveAgent(Agent agent) {
      if (agents.Contains(agent)) {
        // Kill that agent
        agents.Remove(agent);
        agent.Kill();
        if (DeleteAgent != null)
          DeleteAgent(this, ref agent);
        agent = null;
        return true;
      }
      return false;
    }

    public Agent AddNewAgent(AGENT_TYPE agentType, Image image) {
      Agent newAgent = null;
      Environment a = this;
      // Set a random location for the agent 
      RectangleF bounds = device.Graphics.VisibleClipBounds;
      PointF location = new PointF((float)(bounds.Width * rnd.NextDouble()),
                                   (float)(bounds.Height * rnd.NextDouble()));
      switch (agentType) {
        case AGENT_TYPE.AGENT_CONTROLLER: {
            newAgent = new Controller(ref a, ref messageQueue, image, device.Graphics);
            break;
          }
        case AGENT_TYPE.AGENT_OPERATOR: {
            newAgent = new Operator(ref a, ref messageQueue, image, device.Graphics);
            break;
          }
        case AGENT_TYPE.AGENT_LOGISTICS: {
            // Logistics Agent
            newAgent = new TransportAgent(ref a, ref messageQueue, location, agents.Count, image, device.Graphics);
            break;
          }
        case AGENT_TYPE.AGENT_SUPPLIER: {
            newAgent = new SupplierAgent(ref a, ref messageQueue, location, agents.Count, image, device.Graphics);
            break;
          }
        case AGENT_TYPE.AGENT_MANUFACTURE: {
            newAgent = new ManufacturerAgent(ref a, ref messageQueue, location, agents.Count, image, device.Graphics);
            break;
          }
        case AGENT_TYPE.AGENT_CLIENT: {
            newAgent = new ClientAgent(ref a, ref messageQueue, location, agents.Count, image, device.Graphics);
            break;
          }
      }
      agents.Add(newAgent);
      if (NewAgent != null)
        NewAgent(this, ref newAgent);
      return newAgent;
    }

    #endregion

  }
}

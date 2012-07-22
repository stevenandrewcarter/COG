using System;
using System.Drawing;
using System.Windows.Forms;
using Clockwork;
using Clockwork.Agents;

namespace COG_Model {
  public partial class frmCogMain : Form {
    delegate void StatLabelCallback(Label label, double amount);
    delegate void EnvironmentCallBack();
    delegate void UpdateFormTitleCallback(string title);

    private ucExecutionTree executionTree;
    private Clockwork.Environment env;
    private BufferedGraphicsContext context;
    private BufferedGraphics grafx;

    public frmCogMain() {
      InitializeComponent();
      // Create a new Environment
      Graphics g = Graphics.FromHwnd(pnlSimulation.Handle);
      context = BufferedGraphicsManager.Current;
      context.MaximumBuffer = new Size((int)g.VisibleClipBounds.Width + 1, (int)g.VisibleClipBounds.Height + 1);
      grafx = context.Allocate(g, new Rectangle(0, 0, (int)g.VisibleClipBounds.Width, (int)g.VisibleClipBounds.Height));
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      env = new Clockwork.Environment(grafx, imgDrawList, COG_Model.Properties.Settings.Default.NumberOfAgents,
                                      (int)COG_Model.Properties.Settings.Default.NumberIterations, (int)COG_Model.Properties.Settings.Default.TimeIteration);
      // Register the events      
      env.NewAgent += new Clockwork.Environment.NewAgentCallBack(env_NewAgent);
      env.DeleteAgent += new Clockwork.Environment.DeleteAgentCallBack(env_DeleteAgent);
      env.StatUpdate += new Clockwork.Environment.StatUpdateCallBack(env_StatUpdate);
      env.TimerChange += new Clockwork.Environment.TimerCallBack(env_TimerChange);
      env.Complete += new Clockwork.Environment.CompleteCallBack(env_Complete);
      env.New();
      // Disable the run controls
      btnStop.Enabled = false;
      // Add the Execution plan tree to the display
      executionTree = new ucExecutionTree(ref env);
      executionTree.Dock = DockStyle.Fill;
      spltInfo.Panel2.Controls.Add(executionTree);
    }

    void env_Complete(object sender) {
      // Update the toolstrip controls
      btnStart.Enabled = true;
      btnStop.Enabled = false;
      MessageBox.Show("The scenario has completed. Please check the results file for the breakdown. The file is located where the application is run from.");
    }

    void env_TimerChange(object sender, int iteration, TimeSpan time) {
      UpdateFormTitle("COG Model " + iteration +
        " ( " + time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00") + "." + time.Milliseconds.ToString("000") +
        " )");
    }

    private void UpdateFormTitle(string title) {
      if (InvokeRequired) {
        UpdateFormTitleCallback d = new UpdateFormTitleCallback(UpdateFormTitle);
        Invoke(d, new object[] { title });
      } else
        Text = title;
    }

    private void UpdateStatLabel(Label label, double amount) {
      if (label.InvokeRequired) {
        StatLabelCallback d = new StatLabelCallback(UpdateStatLabel);
        label.Invoke(d, new object[] { label, amount });
      } else {
        label.Text = amount.ToString();
      }
    }

    void env_StatUpdate(object sender, STATISTIC stat, double amount) {
      switch (stat) {
        case STATISTIC.STOCKPRODUCED:
          UpdateStatLabel(lblSStat1, amount);
          break;
        case STATISTIC.STOCKSENT:
          UpdateStatLabel(lblSStat2, amount);
          break;
        case STATISTIC.STOCKLOST:
          UpdateStatLabel(lblSStat3, amount);
          break;
        case STATISTIC.STOCKDELIVERED:
          UpdateStatLabel(lblDStat1, amount);
          break;
        case STATISTIC.STOCKDELIVEREDUSED:
          UpdateStatLabel(lblDStat2, amount);
          break;
        case STATISTIC.STOCKDELIVEREDLOST:
          UpdateStatLabel(lblDStat3, amount);
          break;
        case STATISTIC.PRODUCTPRODUCED:
          UpdateStatLabel(lblMStat1, amount);
          break;
        case STATISTIC.PRODUCTPRODUCEDUSED:
          UpdateStatLabel(lblMStat2, amount);
          break;
        case STATISTIC.PRODUCTPRODUCEDLOST:
          UpdateStatLabel(lblMStat3, amount);
          break;
        case STATISTIC.PRODUCTDELIVERED:
          UpdateStatLabel(lblPStat1, amount);
          break;
        default:
          break;
      }
    }

    void env_DeleteAgent(object sender, ref Agent agent) {
      populationStatus.RemoveAgent(agent);
    }

    void env_NewAgent(object sender, ref Agent agent) {
      populationStatus.AddNewAgent(agent);
    }

    private void EnvironmentRunCompete() {
      btnStart.Enabled = true;
      btnStop.Enabled = false;
    }

    void env_RunComplete(object sender, EventArgs e) {
      EnvironmentRunCompete();
    }

    void frmCogMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) {
      env.CancelAsync();
    }

    private void tlsNavExe_Click(object sender, EventArgs e) {
      pnlExePln.Visible = !pnlExePln.Visible;
    }

    private void trkSimSpeed_Scroll(object sender, EventArgs e) {
      // Change the waiting time in the environment
      env.SimulationSpeed = trkSimSpeed.Value;
    }

    private void btnStart_Click(object sender, EventArgs e) {
      // Start the environment
      // Update the controls
      btnStart.Enabled = false;
      btnStop.Enabled = true;
      env.RunWorkerAsync();
    }

    private void btnStop_Click(object sender, EventArgs e) {
      // Start the environment
      env.CancelAsync();
      // Update the toolstrip controls
      btnStart.Enabled = true;
      btnStop.Enabled = false;
    }

    private void pnlSimulation_MouseClick(object sender, MouseEventArgs e) {
      Agent selected = env.Selected((float)e.X, (float)e.Y);
      populationStatus.SelectNode(selected);
    }

  }
}
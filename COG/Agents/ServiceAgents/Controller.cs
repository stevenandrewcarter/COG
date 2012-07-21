using Clockwork.Execution;
using Clockwork.Execution.Tasks;
using Clockwork.GraphStructures;
using Clockwork.Telegram;
using Clockwork.Telegram.MessageTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Clockwork.Agents.ServiceAgents
{
  public class Controller : Agent
  {
    private Graph coordGraph = new CoordinationGraph();
    private ExecutionTree tree;                         // Execution tree for the current run.
    private int completed;                              // Counter indicatating how many tasks the controller has completed

    public Controller(ref Environment environment, ref MessageQueue messages, Image image, Graphics g)
      : base(ref environment, ref messages, new PointF(g.VisibleClipBounds.Width - 16, 0), 0, image, g)
    {
      Reset();
      // Log agent creation
      manager = this;
      // Create a new broadcast message (Inform)
      Message aMessage = new InformMessage(this);
      messageQueue.Broadcast(aMessage);
      ImageKey = "cpu.png";
      SelectedImageKey = "cpu.png";
      type = AGENT_TYPE.AGENT_CONTROLLER;
      tree = environment.Execution;
    }

    #region Abstract Methods

    public override void Reset()
    {
    }

    /// <summary>
    /// Received a response from the operator with the results of the client
    /// task request in the environment. Check if a valid agent is registered
    /// and form a coordination group with the respective agents if required.
    /// </summary>
    /// <param name="destination">Client agent which made the original request</param>
    /// <param name="task">The results of the Client task request in the enivornment</param>
    private void HandleInformMessage(Agent destination, ClientTask task)
    {
      if (task.RegisteredAgents.Count > 0)
      {
        // Create an entry in the execution tree. For now the order
        // is placed as a task in the tree with the current client as 
        // the target.
        ExecutionNode n = new ExecutionNode(task);
        tree.Root.Add(n);
        // Greedy method means that the best payoff result will be assigned to the 
        // coordination group.
        // Send a message to the client and the manufacturer informing them of
        // the current situation
        InformMessage i = new InformMessage(this, task);
        // Send the message first to the client 
        messageQueue.SendPost(task.Agent, i);
        // Generate a manufacturer task 
        ManufacturerTask mTask = new ManufacturerTask((ClientAgent)task.Agent);
        mTask.Agent = task.RegisteredAgents[0].TaskAgent;
        tree.AddChild(task, mTask);
        i = new InformMessage(this, mTask);
        // Send the message also to the manufacturer
        communicationNode.AddEdge(task.RegisteredAgents[0].TaskAgent.CommunicationNode);
        messageQueue.SendPost(task.RegisteredAgents[0].TaskAgent, i);
      }
    }

    private void HandleInformMessage(Agent destination, ManufacturerTask task)
    {
      if (task.RegisteredAgents.Count > 0)
      {
        // Generate a Supplier task 
        SupplierTask sTask = new SupplierTask((SupplierAgent)task.RegisteredAgents[0].TaskAgent, (ManufacturerAgent)task.Agent, task.Demand);
        tree.AddChild(task, sTask);
        InformMessage i = new InformMessage(this, sTask);
        // Send the message first to the client         
        messageQueue.SendPost(task.Agent, i);        
        // Send the message also to the manufacturer
        messageQueue.SendPost(task.RegisteredAgents[0].TaskAgent, i);
      }
    }

    /// <summary>
    /// Handles a logistics agent request.
    /// </summary>
    /// <param name="destination">Original agent which made the request</param>
    /// <param name="task">Logistics task to be assigned</param>
    private void HandleInformMessage(TransportTask task)
    {
      if (task.RegisteredAgents.Count > 0)
      {
        // Generate a Supplier task         
        InformMessage i = new InformMessage(this, task);
        task.Agent = task.RegisteredAgents[0].TaskAgent;
        // Send the message first to the client         
        messageQueue.SendPost(task.Source, i);
        // Send the message also to the logistics agent        
        messageQueue.SendPost(task.RegisteredAgents[0].TaskAgent, i);
      }
    }

    /// <summary>
    /// Handles the inform message type from the message queue
    /// </summary>
    protected override void HandleInformMessage()
    {      
      // Handle an inform message
      if (post.Author is Operator)
      {
        if (post.Content == null)
          // Operator is Letting me know that it exists
          switchboard = post.Author;
        else if (post.Content is ClientTask)
          HandleInformMessage(((ClientTask)post.Content).Agent, (ClientTask)post.Content);
        else if (post.Content is ManufacturerTask)
          HandleInformMessage(((ManufacturerTask)post.Content).Agent, (ManufacturerTask)post.Content);
        else if (post.Content is TransportTask)
          HandleInformMessage((TransportTask)post.Content);     
      }
    }

    /// <summary>
    /// Handle the request message from the message queue.
    /// If the message is from a client then configure the
    /// execution tree to handle the request
    /// </summary>
    protected override void HandleRequestMessage()
    {
      if (post.Author is ClientAgent)                         // Check if a Demand from a client has been made
        HandleRequestMessage((ClientAgent)post.Author);       // Create an entry in the execution tree
      else if (post.Author is ManufacturerAgent && !(post.Content is TransportTask))              // Check if a Request from a manufacturer has been made
        HandleRequestMessage((ManufacturerAgent)post.Author ); // Update the entry in the execution tree
      else if (!(post.Author is Operator) && post.Content is TransportTask)
        HandleRequestMessage(post.Author, (TransportTask)post.Content);
    }

    /// <summary>
    /// Controller will create a coordination group between the
    /// client and the best possible solution agent.
    /// Three possibilities can occur when requesting an agent from
    /// the operator, all of which will be handled by the payoff function
    /// of the agent.
    ///   IE: A logistics agent is nearby which already has a load but no longer
    ///       has a client.
    ///       A manufacturer is nearby which already has capacity but no longer has
    ///       a client.
    ///       A manufacturer is nearby which has spare capacity.
    /// </summary>
    /// <param name="client">Client agent which is making the request</param>
    private void HandleRequestMessage(ClientAgent client)
    {     
      // Controller will request payoffs from all agents in the environment
      // from the possible payoffs it is possible for the controller to select the
      // best agent for the job.
      // Create a demand request message and send it to the operator agent.
      Task cTask = new ClientTask(client);
      Message agentRequest = new RequestMessage(this, ref cTask);
      messageQueue.SendPost(switchboard, agentRequest);
      // Check if the communication edge is already set
      communicationNode.AddEdge(client.CommunicationNode);     
    }

    /// <summary>
    /// Manufacturer is requesting supply. Find an agent that can provide it.
    /// </summary>
    /// <param name="manufacturer">The manufacturer agent making the request</param>
    private void HandleRequestMessage(ManufacturerAgent manufacturer)
    {
      Task mTask = manufacturer.Task;
      // Request the payoff results from the agents in the environment
      // which can provide the required service
      Message agentRequest = new RequestMessage(this, ref mTask);
      messageQueue.SendPost(switchboard, agentRequest);
    }

    /// <summary>
    /// Logistics request. Find an agent that can provide it.
    /// </summary>
    /// <param name="manufacturer">The supplier agent making the request</param>
    private void HandleRequestMessage(Agent author, TransportTask task)
    {      
      // Request the payoff results from the agents in the environment
      // which can provide the required service
      Task lTask = task;
      Message agentRequest = new RequestMessage(this, ref lTask);
      messageQueue.SendPost(switchboard, agentRequest);
    }

    protected override void Act()
    {

    }

    /// <summary>
    /// Monitor the execution tree to determine which tasks are completed
    /// </summary>
    protected override void Sensor()
    {
      for (int i = 0; i < tree.Root.Nodes.Count; i++)
      {
        ExecutionNode n = (ExecutionNode)tree.Root.Nodes[i];
        if (n.Task.Status)
        {
          completed++;
          n.Remove();
        }
      }
    }

    /// <summary>
    /// Controller Agent can never decay out of the environment.
    /// </summary>
    /// <returns>Always returns false since the controller cannot decay</returns>
    public override bool Decay()
    {
      return false;
    }

    public override string ToString()
    {
      return "Controller Agent";
    }

    #endregion
  }
}
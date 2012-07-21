using Clockwork.Agents.ServiceAgents;
using Clockwork.Execution.Tasks;
using Clockwork.GraphStructures;
using Clockwork.Telegram;
using Clockwork.Telegram.MessageTypes;
using UtilityClasses;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Clockwork.Agents
{
  /// <summary>
  /// Client agents in the supply chain make the initial request. The request is made
  /// to the Controller agent which in turn will put the client in contact with a 
  /// manufacturer.
  /// </summary>
  public class ClientAgent : Agent
  {
    private double demand;                   // Represents the total amount of product which the client wants
    private const int MAX_DEMAND = 100;   // Total amount of demand a client can ever want
    private const int MIN_DEMAND = 10;    // Minimum amount of demand a client can ever want

    #region Constructor

    public ClientAgent(ref Environment environment, ref MessageQueue messages, PointF spawnLocation, int agentID, Image image, Graphics g)
      : base(ref environment, ref messages, spawnLocation, agentID, image, g)
    {
      Reset();
      // Create a new broadcast message (Inform)
      Message aMessage = new InformMessage(this);
      messageQueue.Broadcast(aMessage);
      Text = "Client " + id.ToString();
      // GUI Display properties
      type = AGENT_TYPE.AGENT_CLIENT;
      SelectedImageIndex = (int)type;
      ImageIndex = (int)type;
      demand = 0;
      Nodes.Add("Quantity", "Quantity: " + demand.ToString(), 8, 8);
    }

    #endregion

    #region Properties

    public double Demand { get { return demand; } }

    #endregion

    public override void Reset()
    {
     
    }

    protected override void Act()
    {
    }

    public override void Kill()
    {
      base.Kill();
      // Remove the Execution tree reference
      env.Execution.Remove(assignedTask);
    }

    #region MessageHandlers

    /// <summary>
    /// Response from the controller indicating that the task group is a success
    /// </summary>
    /// <param name="controller">Controller which sent the message</param>
    /// <param name="task">Task associated with the current message</param>
    private void HandleInformMessage(Controller controller, ClientTask task)
    {
      coordinationNode.AddEdge(task.RegisteredAgents[0].TaskAgent.CoordinationNode);
      assignedTask = task;
    }

    /// <summary>
    /// Handle an inform message from the logistics agent.
    /// </summary>
    /// <param name="agent">Logistics agent which sent the inform message</param>
    /// <param name="content">Message contained in the message</param>
    protected void HandleInformMessage(TransportAgent agent, TransportTask content)
    {
      // If the manufacturer agent is the destination then it is a supply delivery
      // Reset the demand and make a new request
      env.UpdateStat(STATISTIC.PRODUCTDELIVERED, demand);
      demand = 0;
      assignedTask.Status = true;
      assignedTask = null;
    }

    /// <summary>
    /// Handles an inform message from the Operator
    /// </summary>
    /// <param name="aOperator">The Operator agent that sent the message</param>
    private void HandleInformMessage(Operator aOperator)
    {
      if (post.Content == null)
        // Operator is Letting me know that it exists
        switchboard = post.Author;
      else if (post.Content is Controller)
      {
        manager = (Controller)post.Content;
        communicationNode.AddEdge(((Controller)post.Content).CommunicationNode);
      }      
    }

    /// <summary>
    /// Message handling routine for inform message actions.
    /// </summary>
    protected override void HandleInformMessage()
    {
      if (post.Author is Operator)
        HandleInformMessage((Operator)post.Author);
      else if (post.Author is Controller)
        HandleInformMessage((Controller)post.Author, (ClientTask)post.Content);
      else if (post.Author is TransportAgent && post.Content is TransportTask)
        HandleInformMessage((TransportAgent)post.Author, (TransportTask)post.Content);
    }

    protected override void HandleRequestMessage()
    {
      // Do nothing. No agent in the system will make a request of the client agent
    }

    #endregion

    /// <summary>
    /// The client agent will need to keep track of the agents that it
    /// is coordinating with in order to minimise waste.
    /// </summary>
    protected override void Sensor()
    {
      // Check for the Controller
      RequestController();
      // Determine if more demand is required
      if (demand == 0)
      {
        demand = rnd.Next(MIN_DEMAND, MAX_DEMAND);
        Update(this, "Quantity", "Quantity: " + demand.ToString());
      }
      // If demand is required then send a request to the controller for a manufacturer
      // Only if the agents do not have a current manufacturer and the agent
      // knows who the controller is.
      if (demand > 0 && manager != null && assignedTask == null)
      {
        // Send a request to the controller to form a coordination group 
        // with the closest manufacturer.
        Message aMessage = new RequestMessage(this, demand);
        messageQueue.SendPost(manager, aMessage);
      }
    }

    public override string ToString()
    {
      return "Client Agent " + id.ToString();
    }
  }
}

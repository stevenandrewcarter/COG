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
  /// Manufacturer agents in the environment generate product from stock at the generation rate.
  /// Each Manufacturer in the environment provides the product. When considering a potential
  /// manufacturer two factors generate to the payoff result. 
  ///   Distance + Availablity = Payoff,
  ///  where distance is the straight line distance to between the agents and availablity
  ///  is the percentage amount of the product on hand. So for example
  ///    a distance agent with a lot of stock could be considered over a closer agent with
  ///    no product.
  /// </summary>
  public class ManufacturerAgent : Agent
  {
    private const int PRODUCT_MAX = 1000;
    private const int GENERATION_RATE = 1;

    private double stock;
    private double product;

    #region Constructor

    public ManufacturerAgent(ref Environment environment, ref MessageQueue messages, PointF spawnLocation, int agentID, Image image, Graphics g)
      : base(ref environment, ref messages, spawnLocation, agentID, image, g)
    {
      Reset();
      // Create a new broadcast message (Inform)
      Message aMessage = new InformMessage(this);
      messageQueue.Broadcast(aMessage);
      Text = "Manufacturer " + id.ToString();
      type = AGENT_TYPE.AGENT_MANUFACTURE;
      SelectedImageIndex = (int)type;
      ImageIndex = (int)type;
      stock = 0;
      product = 0;
    }
  
    #endregion

    public override void Reset()
    {      
    }

    public override void Kill()
    {
      env.UpdateStat(STATISTIC.PRODUCTPRODUCEDLOST, product);
      env.UpdateStat(STATISTIC.STOCKDELIVEREDLOST, stock);
      base.Kill();
    }

    protected override void Act()
    {
      if (stock > 0)
      {
        stock-=GENERATION_RATE;
        product+=GENERATION_RATE;
        env.UpdateStat(STATISTIC.PRODUCTPRODUCED, GENERATION_RATE);
        env.UpdateStat(STATISTIC.STOCKDELIVEREDUSED, GENERATION_RATE);
      }
    }

    #region Message Handling

    /// <summary>
    /// Handles the assignment from the controller agent. Updates the communication 
    /// graph to indicate the possible communication links.
    /// </summary>
    /// <param name="author">The systems controller agent.</param>
    /// <param name="content">The new manufacturing task for the current agent.</param>
    private void HandleInformMessage(Controller author, ManufacturerTask content)
    {
      coordinationNode.AddEdge(content.Client.CoordinationNode);
      communicationNode.AddEdge(content.Client.CommunicationNode);
      // Update the coordination information
      assignedTask = content;      
      manager = author;
      communicationNode.AddEdge(author.CommunicationNode);
    }

    /// <summary>
    /// Handles the request for a potential supplier for the manufacturer.
    /// </summary>
    /// <param name="author">Controller agent which sent the reply</param>
    /// <param name="content">A Supplier task with a potential supplier agent provided.</param>
    private void HandleInformMessage(Controller author, SupplierTask content)
    {
      coordinationNode.AddEdge(content.Agent.CoordinationNode);
      communicationNode.AddEdge(content.Agent.CommunicationNode);
      // Update the coordination information
      ((ManufacturerTask)assignedTask).Supplier = content.Agent;
    }

    /// <summary>
    /// Handle an inform message from the logistics agent.
    /// </summary>
    /// <param name="agent">Logistics agent which sent the inform message</param>
    /// <param name="content">Message contained in the message</param>
    protected void HandleInformMessage(TransportAgent agent, TransportTask content)
    {
      // If the manufacturer agent is the destination then it is a supply delivery
      if (content.Destination.Equals(this))
      {
        stock += content.Load;
        env.UpdateStat(STATISTIC.STOCKDELIVERED, content.Load);
      }
      else
      {
        // Transport agent has now collected the stock. The manufacturer agent
        // is free to handle other requests now.
        product -= content.Load;
        env.UpdateStat(STATISTIC.PRODUCTPRODUCEDUSED, content.Load);        
        assignedTask.Status = true;
        assignedTask = null;
      }
    }

    /// <summary>
    /// Handles the response for the transport request
    /// </summary>
    /// <param name="agent">Controller agent</param>
    /// <param name="content">The transport task the manufacturer requested</param>
    protected void HandleInformMessage(Controller agent, TransportTask content)
    {
      ((ManufacturerTask)assignedTask).Transport = content.Agent;
    }

    /// <summary>
    /// Handles inform messages sent to the Manufacturer.
    /// </summary>
    protected override void HandleInformMessage()
    {
      if (post.Author is Controller && post.Content is ManufacturerTask)
        HandleInformMessage((Controller)post.Author, (ManufacturerTask)post.Content);
      else if(post.Author is Controller && post.Content is SupplierTask)
        HandleInformMessage((Controller)post.Author, (SupplierTask)post.Content);
      else if(post.Author is Controller && post.Content is TransportTask)
        HandleInformMessage((Controller)post.Author, (TransportTask)post.Content);
      else if (post.Author is TransportAgent && post.Content is TransportTask)
        HandleInformMessage((TransportAgent)post.Author, (TransportTask)post.Content);
    }

    #endregion

    /// <summary>
    /// Manufacturer agents are biased towards closer agents.
    /// So availablity is an important factor, but not more important than distance.
    /// As such all availabity is capped at 1 and then divided by 2
    /// f(x) = d - (Min(1, a) / 2)
    /// </summary>
    /// <returns>Payoff result for the current agent</returns>
    protected override double CalculatePayoff(Task task)
    {
      double distance = (double)DetermineDirection(Point, task.Agent.Point).Normal();
      double available = Math.Min(1, stock / ((ClientAgent)((ClientTask)task).Agent).Demand) / 2;
      return distance - available;
    }

    /// <summary>
    /// Manufacturer agents can only handle a request for product availablity.
    /// </summary>
    protected override void HandleRequestMessage()
    {
      if (post.Content is ClientTask)
      {
        if (assignedTask == null)
        {
          // Calculate the payoff of the product
          double result = CalculatePayoff((ClientTask)post.Content);
          ((ClientTask)post.Content).RegisteredAgents.Add(new TaskComparer(result, this));
        }
      }      
    }
    
    /// <summary>
    /// When the manufacturer performs a sensor action it will determine the following.
    /// Is the Manufacturer part of a coordination group with a client agent
    ///    * If so it will determine if it has enough product on hand to supply the client agent
    ///    * If not a failure might have occured, ensure that the missing client is intentional
    /// If the manufacturer needs stock it will need to coordinate with a supplier, else
    /// if will need to coordinate with a logistics agent to deliver the product.
    /// </summary>
    protected override void Sensor()
    {
      // Check if the agent is part of a coordination group
      if (assignedTask != null)
      {
        // Check if the agent has enough product. If so send a request for a logistics
        // agent.
        if (product >= ((ManufacturerTask)assignedTask).Demand && ((ManufacturerTask)assignedTask).Transport == null)
        {
          // Request a logistics agent to collect the product for the client
          Task task = new TransportTask(this, ((ManufacturerTask)assignedTask).Client, ((ManufacturerTask)assignedTask).Demand);
          RequestMessage m = new RequestMessage(this, ref task);
          messageQueue.SendPost(manager, m);
        }
        else if (stock < ((ManufacturerTask)assignedTask).Demand && ((ManufacturerTask)assignedTask).Supplier == null)
        {
          // Request a supplier agent to deliver the stock for the manufacturer
          RequestMessage m = new RequestMessage(this, assignedTask);
          messageQueue.SendPost(manager, m);
        }
      }
    }

    public override string ToString()
    {
      return "Manufacturer Agent " + id.ToString();
    }
  }
}

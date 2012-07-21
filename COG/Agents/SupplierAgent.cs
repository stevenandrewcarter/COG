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
  public class SupplierAgent : Agent
  {
    // The following variables represent the Suppliers agent ability to provide in the
    // environment.
    private double supply;
    private const int SUPPLY_MAX = 100;
    private const int SUPPLY_RATE = 1;

    public SupplierAgent(ref Environment environment, ref MessageQueue messages, PointF spawnLocation, int agentID, Image image, Graphics g)
      : base(ref environment, ref messages, spawnLocation, agentID, image, g)
    {
      Reset();
      // Create a new broadcast message (Inform)
      Message aMessage = new InformMessage(this);
      messageQueue.Broadcast(aMessage);
      Text = "Supplier " + id.ToString();
      type = AGENT_TYPE.AGENT_SUPPLIER;
      SelectedImageIndex = (int)type;
      ImageIndex = (int)type;
      supply = 0;
    }

    public override void Reset()
    {    
    }

    protected override void Act()
    {
      if (assignedTask != null)
      {
        if (supply <= SUPPLY_MAX)
        {
          supply += SUPPLY_RATE;
          env.UpdateStat(STATISTIC.STOCKPRODUCED, SUPPLY_RATE);
        }
      }
    }

    public override void Kill()
    {
      base.Kill();
      env.UpdateStat(STATISTIC.STOCKLOST, supply);
    }

    /// <summary>
    /// Informs the supplier agent that it is now part of the coordination group
    /// </summary>
    /// <param name="author">Controller agent of the system</param>
    /// <param name="content">Supplier Task</param>
    protected void HandleInformMessage(Agent author, SupplierTask content)
    {
      coordinationNode.AddEdge(content.Manufacturer.CoordinationNode);
      communicationNode.AddEdge(content.Manufacturer.CommunicationNode);
      // Update the coordination information
      assignedTask = content;
      manager = author;      
    }

    /// <summary>
    /// Informs the Supplier agent that the transport request is completed.
    /// </summary>
    /// <param name="author">Controller agent</param>
    /// <param name="content">Transport Task request</param>
    protected void HandleInformMessage(Agent author, TransportTask content)
    {
      // Update the coordination information
      ((SupplierTask)assignedTask).Transport = content.RegisteredAgents[0].TaskAgent;
      communicationNode.AddEdge(content.RegisteredAgents[0].TaskAgent.CommunicationNode);
    }

    /// <summary>
    /// Handle an inform message from the logistics agent. The supplier will
    /// be free for another task after this.
    /// </summary>
    /// <param name="agent">Logistics agent which sent the inform message</param>
    /// <param name="content">Message contained in the message</param>
    protected void HandleInformMessage(TransportAgent agent, TransportTask content)
    {
      if (supply < content.Load)
        throw new Exception("Supplier can not supply a load when internal stock is less then the demand.");
      supply -= content.Load;
      env.UpdateStat(STATISTIC.STOCKSENT, content.Load);
      assignedTask.Status = true;
      assignedTask = null;
    }

    protected override void HandleInformMessage()
    {
      if (post.Author is Controller && post.Content is SupplierTask)
        HandleInformMessage(post.Author, (SupplierTask)post.Content);
      else if (post.Author is Controller && post.Content is TransportTask)
        HandleInformMessage(post.Author, (TransportTask)post.Content);
      else if(post.Author is TransportAgent && post.Content is TransportTask)
        HandleInformMessage((TransportAgent)post.Author, (TransportTask)post.Content);
    }
   
    /// <summary>
    /// Handles request messages from the system.
    /// </summary>
    protected override void HandleRequestMessage()
    {
      if (post.Content is ManufacturerTask)
      {
        // Only calculate the payoff if the supplier is not currently engaged in
        // a task. (This is an easy contraint to relax if need be)
        if (assignedTask == null)
        {
          // Calculate the payoff of the product
          double result = CalculatePayoff((ManufacturerTask)post.Content);
          ((ManufacturerTask)post.Content).RegisteredAgents.Add(new TaskComparer(result, this));
        }
      }       
    }

    /// <summary>
    /// Calculate the payoff for the current supplier agent. 
    /// The payoff is similar to the manufacturer agent in that
    ///   f(x) = d - Min(1, a) / 2
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    protected override double CalculatePayoff(Task task)
    {
      double distance = (double)DetermineDirection(Point, task.Agent.Point).Normal();
      double available = Math.Min(1, supply / ((ManufacturerTask)task).Demand) / 2;
      return distance - available;
    }
    
    /// <summary>
    /// The supplier will check if it has any current tasks that it
    /// needs to fufill.
    /// </summary>
    protected override void Sensor()
    {
      if (assignedTask != null)
      {
        // Check when the supplier has got enough stock on hand to deliver to the
        // manufacturer
        if (supply >= ((SupplierTask)assignedTask).OrderAmount && ((SupplierTask)assignedTask).Transport == null)
        {
          // Send a request for a logistics agent to come and collect the order
          Task task = new TransportTask(this, ((SupplierTask)assignedTask).Manufacturer, ((SupplierTask)assignedTask).OrderAmount);
          RequestMessage m = new RequestMessage(this, ref task);
          messageQueue.SendPost(manager, m);
        }
      }
    }

    public override string ToString()
    {
      return "Supplier Agent " + id.ToString();
    }
  }
}

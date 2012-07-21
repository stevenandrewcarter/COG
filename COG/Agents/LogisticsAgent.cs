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
  public class TransportAgent : Agent
  {
    #region Private Variables
    
    private Agent destination;            // The agent which the Logistics agent wishes to reach
    private Vector2 moveDirection;        // The direction in which the logistic agent will move. (Determined by the sensor)
    private float speed;                  // Speed of movement for the current agent
    private double load;                  // Amount of supply the agent is currently carrying    

    #endregion

    #region Constructor

    public TransportAgent(ref Environment environment, ref MessageQueue messages, PointF spawnLocation, int agentID, Image image, Graphics g)
      : base(ref environment, ref messages, spawnLocation, agentID, image, g)
    {      
      Reset();
      // Create a new broadcast message (Inform)
      Message aMessage = new InformMessage(this);
      messageQueue.Broadcast(aMessage);
      Text = "Logistics " + id.ToString();
      type = AGENT_TYPE.AGENT_LOGISTICS;
      SelectedImageIndex = (int)type;
      ImageIndex = (int)type;
      speed = 1.0f;
    }

    #endregion

    public override void Reset()
    {      
    }

    protected override void Act()
    {
      // Perform a move location call if required
      if (destination != null)
      {
        Move();
        if (destination.Intersect(new PointF(location.X + 4, location.Y + 4)))
        {
          // Perform a load action and send a message to the agent informing it of the
          // action
          if (((TransportTask)assignedTask).Load > load)
          {
            load = ((TransportTask)assignedTask).Load;
            InformMessage m = new InformMessage(this, assignedTask);
            messageQueue.SendPost(((TransportTask)assignedTask).Source, m);
          }
          else
          {
            load = 0;
            InformMessage m = new InformMessage(this, assignedTask);
            messageQueue.SendPost(((TransportTask)assignedTask).Destination, m);
            // Task complete clear the logistics agent for further tasks
            assignedTask = null;
            destination = null;
          }
        }
      }
    }

    /// <summary>
    /// Handles the request for a potential supplier for the manufacturer.
    /// </summary>
    /// <param name="author">Controller agent which sent the reply</param>
    /// <param name="content">A Supplier task with a potential supplier agent provided.</param>
    private void HandleInformMessage(Controller author, TransportTask content)
    {
      coordinationNode.AddEdge(content.Agent.CoordinationNode);
      communicationNode.AddEdge(content.Agent.CommunicationNode);
      assignedTask = content;
      manager = author;
    }

    protected override void HandleInformMessage()
    {
      if (post.Author is Controller && post.Content is TransportTask)
        HandleInformMessage((Controller)post.Author, (TransportTask)post.Content);      
    }

    protected override double CalculatePayoff(Task task)
    {
      double distance = (double)DetermineDirection(Point, ((TransportTask)task).Source.Point).Normal();
      double available = Math.Min(1, load / ((TransportTask)task).Load) / 2;
      return distance - available;
    }

    protected override void HandleRequestMessage()
    {
      if (post.Content is TransportTask)
      {
        // Only calculate the payoff if the supplier is not currently engaged in
        // a task. (This is an easy contraint to relax if need be)
        if (assignedTask == null)
        {
          // Calculate the payoff of the product
          double result = CalculatePayoff((TransportTask)post.Content);
          ((TransportTask)post.Content).RegisteredAgents.Add(new TaskComparer(result, this));
        }
      }    
    }

    /// <summary>
    /// Executes the logistics agent's sensor functionality.
    /// Determines the location of the destination agent. From the
    /// location the logistic agent can calculate the movement vector
    /// to its destinantion
    /// </summary>
    protected override void Sensor()
    {
      if (assignedTask != null)
      {
        // Check if the logistics agent has picked up the load
        if (((TransportTask)assignedTask).Load > load)
          destination = ((TransportTask)assignedTask).Source;
        else
          destination = ((TransportTask)assignedTask).Destination;
        // Calculate the movement unit vector to its destination.
        DetermineMoveDirection();
      }
    }

    private void DetermineMoveDirection()
    {
      moveDirection = DetermineDirection(Point, destination.Point).Normalise();
    }

    /// <summary>
    /// Move the agent towards it destination
    /// </summary>
    /// <param name="destination">Point in the world where the agent wants to get to</param>
    protected void Move()
    {
      // Check if the agent has detected somewhere to move
      if(moveDirection != null)
        // Make the new location the d * speed
        Point = new PointF(Point.X + (moveDirection.X * speed), Point.Y + (moveDirection.Y * speed));
    }

    public override string ToString()
    {
      return "Transport Agent " + id.ToString();
    }
  }
}

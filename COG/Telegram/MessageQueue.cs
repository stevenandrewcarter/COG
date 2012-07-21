using Clockwork.Agents;
using System;
using System.Collections.Generic;

namespace Clockwork.Telegram
{
  public class MessageEventArgs : EventArgs
  {
    private Message message;
    private Agent destination;

    public MessageEventArgs(Agent Destination, Message newMessage)
    {
      destination = Destination;
      message = newMessage;
    }

    public Agent Destination { get { return destination; } }

    public Message MailMessage { get { return message; } }
  }

  public class BroadcastMessageEventArgs : EventArgs
  {
    private Message message;

    public BroadcastMessageEventArgs(Message newMessage) { message = newMessage; }

    public Message BroadcastMessage { get { return message; } }
  }

  /// <summary>
  /// A global object that holds a list of messages in the Clockwork engine for the COG
  /// Model. Agents can access the message queue to read messages posted to them and also
  /// to place messages to be posted.
  /// </summary>
  public class MessageQueue
  {
    // Events
    public delegate void BroadcastMessageHandler(object sender, BroadcastMessageEventArgs e);
    public event BroadcastMessageHandler BroadcastEvent;

    public delegate void MessageHandler(object sender, MessageEventArgs e);
    public event MessageHandler MessageEvent;

    public MessageQueue()
    {

    }

    // Each agent has a post box in the message queues
    private Dictionary<Agent, Queue<Message>> postbox = new Dictionary<Agent, Queue<Message>>();

    public Message GetPost(Agent agent)
    {
      Message aMessage = null;
      // Check if a post box exists for this agent
      if (postbox.ContainsKey(agent))
      {
        if (postbox[agent].Count > 0)
        {
          // Post is in the post box
          // Remove this message from the post box
          aMessage = postbox[agent].Dequeue();
        }
      }
      return aMessage;
    }

    public void DeRegister(Agent agent)
    {
      if (postbox.ContainsKey(agent))
      {
        postbox.Remove(agent);
      }
    }

    public void Register(Agent agent)
    {
      if (!postbox.ContainsKey(agent))
      {
        postbox.Add(agent, new Queue<Message>());
      }
    }

    public void Broadcast(Message aMessage)
    {
      BroadcastEvent(this, new BroadcastMessageEventArgs(aMessage));
    }

    public void SendPost(Agent destination, Message aMessage)
    {
      // Check if the post box exists
      if (postbox.ContainsKey(destination))
      {
        // Post box exists place post into the box
        // postbox[destination].Enqueue(aMessage);
        MessageEvent(this, new MessageEventArgs(destination, aMessage));
      }
      else
      {
        // Throw exception indicating that the post box is not valid
        throw new Exception("No post box exists for that destination");
      }
    }

    public void SendPost(Agent destination, ref Message aMessage)
    {
      // Check if the post box exists
      if (postbox.ContainsKey(destination))
      {
        // Post box exists place post into the box
        // postbox[destination].Enqueue(aMessage);
        MessageEvent(this, new MessageEventArgs(destination, aMessage));
      }
      else
      {
        // Throw exception indicating that the post box is not valid
        throw new Exception("No post box exists for that destination");
      }
    }
  }
}

using System.Drawing;
using Clockwork.Execution.Tasks;
using Clockwork.GraphStructures;
using Clockwork.Telegram;
using Clockwork.Telegram.MessageTypes;

namespace Clockwork.Agents.ServiceAgents {
  public class Operator : Agent {
    private Graph communicationGraph = new Graph(); // Communication graph structure

    public Operator(ref Environment environment, ref MessageQueue messages, Image image, Graphics g)
      : base(ref environment, ref messages, new PointF(0, 0), 0, image, g) {
      Reset();
      // Log agent creation
      switchboard = this;
      messageQueue.BroadcastEvent += new MessageQueue.BroadcastMessageHandler(messageQueue_BroadcastEvent);
      ImageKey = "telephone.png";
      SelectedImageKey = "telephone.png";
      type = AGENT_TYPE.AGENT_OPERATOR;
    }

    void messageQueue_BroadcastEvent(object sender, BroadcastMessageEventArgs e) {
      Message broadcastMessage = e.BroadcastMessage;
      CommunicationGraphNode aNode = broadcastMessage.Author.CommunicationNode;
      // Add new agent to Communication Graph
      if (communicationGraph.Add(aNode)) {
        // Set the Authors node to the graph node 
        GraphEdge edge = new CommunicationGraphEdge(broadcastMessage.Author.CommunicationNode, communicationNode);
        if (!aNode.Edges.Contains(edge)) aNode.Edges.Add(edge);
        edge = new CommunicationGraphEdge(communicationNode, broadcastMessage.Author.CommunicationNode);
        if (!communicationNode.Edges.Contains(edge)) communicationNode.Edges.Add(edge);
        // Write a message to the agent informing it that the Operator is aware 
        // of its existance
        Message aMessage = new InformMessage(this);
        messageQueue.SendPost(broadcastMessage.Author, aMessage);
        // Also inform the controller if this agent is not a controller
        if ((broadcastMessage.Author is Controller)) {
          manager = broadcastMessage.Author;
        }
      }
      broadcastMessage = null;    // Clear the message from the queue
    }

    #region Abstract Methods

    protected override void Act() {
      // Do Nothing         
    }

    public override void Reset() {

    }

    protected override void HandleInformMessage() {

    }

    /// <summary>
    /// Handle a request from any agent for the current controllers reference
    /// </summary>
    protected void HandleRequestMessage(Agent destination, Controller request) {
      if (request == null) {
        Message m = new InformMessage(this, manager);
        messageQueue.SendPost(destination, m);
      }
    }

    /// <summary>
    /// Handles a request message from the Controller for agents which can
    /// help fulfill the task request. The Operator will send a request
    /// to all of the agents in the communication graph connected directly with
    /// the operator to request the participating agents payoff functions.
    /// </summary>
    /// <param name="destination">Controller agent which made the request</param>
    /// <param name="task">A Manufacturer request for supply. Required in order to calculate a realistic payoff function.</param>
    private void HandleRequestMessage(Agent destination, Task task) {
      // Step through each agent in the communication graph connected to the operator
      foreach (CommunicationGraphEdge e in communicationNode.Edges) {
        // Send a payoff request to the agent which is not the operator
        Agent a = e.DestinationNode.Value;
        RequestMessage r = new RequestMessage(this, ref task);
        messageQueue.SendPost(a, r);
      }
      if (task.RegisteredAgents.Count > 0)
        task.RegisteredAgents.Sort(task.RegisteredAgents[0]);
      // Send the results back to the controller
      InformMessage i = new InformMessage(this, task);
      messageQueue.SendPost(destination, i);
    }

    protected override void HandleRequestMessage() {
      // If the content is empty it an agent requesting
      // the controller agent in order to perform a coordination action.
      if (post.Content == null)
        HandleRequestMessage(post.Author, (Controller)post.Content);
      else if (post.Content is Task && post.Author is Controller)       // Controller agent requesting agents which can help with the Client request task
        HandleRequestMessage(post.Author, (Task)post.Content);
    }

    protected override void Sensor() {
      // Check agent graph
      /*for (int i = 0; i < communicationGraph.Nodes.Count; i++)
      {
        if (communicationGraph.Nodes[i].Value == null)
        {
          // Can remove the node from the communication graph
          // Message r = new InformMessage(this, communicationGraph.Nodes[i].Id);
          // messageQueue.SendPost(manager, r);
          // communicationGraph.Nodes.Remove(communicationGraph.Nodes[i]);
          //log.Write(new Clockwork.Logging.LogItem("Agent has left the system inform the controller! ", System.Drawing.Color.Red));
        }
      }*/
    }

    #endregion

    /// <summary>
    /// Operator agent can never decay from the environment.
    /// </summary>
    /// <returns>False. Operate agent cannot decay</returns>
    public override bool Decay() {
      return false;
    }

    public override string ToString() {
      return "Operator Agent";
    }
  }
}

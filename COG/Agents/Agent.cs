using System;
using System.Drawing;
using System.Windows.Forms;
using Clockwork.Execution.Tasks;
using Clockwork.GraphStructures;
using Clockwork.Telegram;
using Clockwork.Telegram.MessageTypes;

namespace Clockwork.Agents {
  public enum AGENT_TYPE {
    AGENT_LOGISTICS = 0,
    AGENT_SUPPLIER = 1,
    AGENT_MANUFACTURE = 2,
    AGENT_CLIENT = 3,
    AGENT_OPERATOR = 4,
    AGENT_CONTROLLER = 5
  }

  /// <summary>
  /// Abstract class of what an COG Agent should contain. 
  /// </summary>
  public abstract partial class Agent : TreeNode {
    protected AGENT_TYPE type;

    // Agent state variables
    protected int lifeCounter;                          // Indicates the amount of time the agent can exist in the environment
    protected const int MAX_LIFE_COUNTER = 1000;        // Maximum amount of time an agent can exist in the environment
    protected const int MIN_LIFE_COUNTER = 900;          // Minimum amount of time an agent can exist in the environment

    protected MessageQueue messageQueue;
    protected CommunicationGraphNode communicationNode; // Communication reference node
    protected CoordinationGraphNode coordinationNode;   // Current Coodination node for this agent    
    protected Task assignedTask;                        // Current task the agent was assigned   
    protected Clockwork.Telegram.Message post;          // Message from the postbox
    // All agents in the system must be aware of the Operator and Controller
    protected Agent switchboard;                        // Operator agent
    protected Agent manager;                            // Controller agent
    protected Environment env;
    protected int id;                                   // Represents the id of the agent    
    protected Random rnd;

    #region Constructor

    /// <summary>
    /// Default constructor. Sets all local variables to null
    /// </summary>
    public Agent(ref Environment environment, ref MessageQueue messages,
      PointF spawnLocation, int agentID, Image image, Graphics g) {
      // Intialise variables
      env = environment;
      // Create a communication node for the agent      
      messageQueue = messages;
      messageQueue.Register(this);
      messageQueue.MessageEvent += new MessageQueue.MessageHandler(messageQueue_MessageEvent);
      assignedTask = null;
      this.g = g;
      if (image != null) {
        this.image = image;
        location = spawnLocation;
      }
      coordinationNode = new CoordinationGraphNode(this);
      communicationNode = new CommunicationGraphNode(this);
      // Initialise Agent state variables      
      id = agentID;
      rnd = new Random(System.Environment.TickCount);
      lifeCounter = rnd.Next(MIN_LIFE_COUNTER, MAX_LIFE_COUNTER);
    }

    void messageQueue_MessageEvent(object sender, MessageEventArgs e) {
      if (e.Destination.Equals(this)) {
        post = e.MailMessage;
        HandlePost();
      }
    }

    #endregion

    #region Properties

    public AGENT_TYPE Type { get { return type; } }
    public CommunicationGraphNode CommunicationNode { get { return communicationNode; } }
    public CoordinationGraphNode CoordinationNode { get { return coordinationNode; } }
    public PointF Location { get { return location; } }
    public Task Task { get { return assignedTask; } }

    #endregion

    #region Abstract Methods

    // Agent Methods
    // Would be nice to use event handlers for Messages?
    protected abstract void Sensor();                 // Allows agent to determine aspects of the environment
    protected abstract void Act();                    // Calls the action method for this agent    
    protected abstract void HandleInformMessage();    // Inform messages
    protected abstract void HandleRequestMessage();   // Request messages    
    public abstract void Reset();                     // Resets the agent state. Used when the environment is setup for the next run.

    #endregion

    #region Methods

    /// <summary>
    /// Default function to Calculate the Payoff Function for an agent doing a
    /// particular task in the environment.
    /// </summary>
    /// <returns>A payoff value which indicates the potential to perform a task in the environment. 
    /// Default is 0 which means the agent has no ability to perform that particular task.</returns>
    protected virtual double CalculatePayoff(Task task) {
      return 0;
    }

    /// <summary>
    /// General Message handling call.
    /// </summary>
    protected void HandlePost() {
      // Can now read post that has arrived
      if (post != null) {
        if (post is InformMessage) {
          HandleInformMessage();
        } else if (post is RequestMessage) {
          HandleRequestMessage();
        }
      }
    }

    /// <summary>
    /// Agents in the Clockwork world slowly decay over time until they expire.
    /// The Decay function slowly counts down the time to live value for the agent,
    /// so that the world can remove the agent once its timer expires.
    /// </summary>
    /// <returns>Boolean value indicating if the agent has expired</returns>
    public virtual bool Decay() {
      if (lifeCounter > 0) {
        lifeCounter--;
        return false;
      } else
        return true;
    }

    /// <summary>
    /// Kills the agent in the environment. Cleans up the agent and clears the 
    /// drawing elements.
    /// </summary>
    public virtual void Kill() {
      communicationNode.Delete();
      coordinationNode.Delete();
    }

    public void Execute() {
      Sensor();
      Act();
    }

    /// <summary>
    /// Use this call to identify the Controller from the Operator
    /// </summary>
    protected void RequestController() {
      if (manager == null) {
        // Generate a new request message for the controller
        Clockwork.Telegram.Message m = new RequestMessage(this, manager);
        messageQueue.SendPost(switchboard, m);
      }
    }

    #endregion

    #region GUI Methods
    private delegate void UpdateCallback(Agent agent, string node, string text);

    /// <summary>
    /// Thread safe callback to update the treeview control.
    /// </summary>
    /// <param name="agent">Agent node to update</param>
    /// <param name="node">Child node to update</param>
    /// <param name="text">Text string to display in the node</param>
    protected void Update(Agent agent, string node, string text) {
      if (agent.TreeView.InvokeRequired) {
        UpdateCallback d = new UpdateCallback(Update);
        agent.TreeView.Invoke(d, new object[] { agent, node, text });
      } else {
        agent.Nodes[node].Text = text;
      }
    }

    #endregion

  }
}

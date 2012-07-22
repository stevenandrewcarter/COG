using Clockwork.Agents;

namespace Clockwork.Telegram {
  /// <summary>
  /// COG_Messages are used by agents to send messages to each other. Each
  /// message contains a Header allowing agents to be able to determine information
  /// regarding this message.
  /// </summary>
  public abstract class Message {
    protected object content;              // Message is contained as a object
    protected Agent author;                // Agent that sent this message

    /// <summary>
    /// Creates a message instance for the current agent
    /// </summary>
    /// <param name="aAgent">Agent that creates this message</param>        
    public Message(Agent Author) {
      author = Author;
    }

    #region Properties

    public Agent Author { get { return author; } }

    public object Content { get { return content; } set { content = value; } }

    #endregion

    /// <summary>
    /// Allows the agent to write the current message for future reading. This message
    /// has no destination so it is better suited for the broadcast action.
    /// </summary>
    /// <param name="aMessage">A message object</param>
    public void Write(object messageContents) {
      content = messageContents;
    }

    public override string ToString() {
      return "Unknown Message";
    }
  }
}

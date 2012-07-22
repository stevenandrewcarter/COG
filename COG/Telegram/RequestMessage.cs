using Clockwork.Agents;
using Clockwork.Execution.Tasks;

namespace Clockwork.Telegram.MessageTypes {
  public class RequestMessage : Message {

    public RequestMessage(Agent Author, ref Task messageContent)
      : base(Author) {
      content = messageContent;
    }

    public RequestMessage(Agent Author, object messageContent)
      : base(Author) {
      content = messageContent;
    }

    public override string ToString() {
      return "Request Message";
    }
  }
}

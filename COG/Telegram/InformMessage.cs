using Clockwork.Agents;
using Clockwork.Execution.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.Telegram.MessageTypes
{
    public class InformMessage : Message
    {
        public InformMessage(Agent Author)
            : base(Author)
        {
        }

        public InformMessage(Agent Author, Agent messageContent)
            : base(Author)
        {
            content = messageContent;
        }

        public InformMessage(Agent Author, object messageContent) : base(Author)
        {
            content = messageContent;
        }

        public override string ToString()
        {
            return "Inform Message";
        }
    }
}

using Clockwork.Agents;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Clockwork.GraphStructures
{
  public class CommunicationGraphNode : GraphNode
  {
    public CommunicationGraphNode(Agent aAgent)      
    {
      agent = aAgent;      
    }
  }
}

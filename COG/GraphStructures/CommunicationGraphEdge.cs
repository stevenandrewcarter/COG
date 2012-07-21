using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.GraphStructures
{
    public class CommunicationGraphEdge : GraphEdge
    {
      public CommunicationGraphEdge(GraphNode sourceNode, GraphNode destinationNode)
      {
        source = sourceNode;
        destination = destinationNode;
      }
    }
}

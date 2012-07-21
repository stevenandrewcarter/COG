using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.GraphStructures
{
  public class CoordinationGraphEdge : GraphEdge
  {
    public CoordinationGraphEdge(CoordinationGraphNode sourceNode, CoordinationGraphNode destinationNode)
    {
      source = sourceNode;
      destination = destinationNode;
    }
  }
}

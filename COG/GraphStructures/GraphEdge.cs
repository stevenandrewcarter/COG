using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.GraphStructures
{
  /// <summary>
  /// Abstract class that represents the edges in a graph
  /// </summary>
  public abstract class GraphEdge
  {
    protected GraphNode source;
    protected GraphNode destination;

    public GraphNode SourceNode { get { return source; } }
    public GraphNode DestinationNode { get { return destination; } }

    public override bool Equals(object obj)
    {
      if(((GraphEdge)obj).DestinationNode == destination && ((GraphEdge)obj).SourceNode == source)
        return true;
      return false;
    }
  }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.GraphStructures
{
  /// <summary>
  /// Allows actions to be performed on a graph.
  /// For example iterate or explore. Also ensures that the graph contains only
  /// unique nodes.
  /// </summary>
  public class Graph
  {
    private List<GraphNode> nodes = new List<GraphNode>();

    public Graph()
    {
      nodes.Clear();
    }

    #region Properties

    public List<GraphNode> Nodes
    {
      get
      {
        return nodes;
      }
    }

    #endregion

    public bool Contains(GraphNode aNode)
    {
      if (nodes.Contains(aNode))
      {
        return true;
      }
      return false;
    }

    public bool Add(GraphNode aNode)
    {
      if (!Contains(aNode))
      {
        nodes.Add(aNode);
        return true;
      }
      return false;
    }

    public bool Remove(GraphNode aNode)
    {
      if (Contains(aNode))
      {
        nodes.Remove(aNode);
        return true;
      }
      return false;
    }

    public bool Remove(Agents.Agent agent)
    {
      foreach (GraphNode gn in nodes)
      {
        if (gn.Value.Equals(agent))
        {
          nodes.Remove(gn);
          return true;
        }
      }
      return false;
    }

  }
}

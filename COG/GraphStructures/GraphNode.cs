using Clockwork.Agents;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Clockwork.GraphStructures
{
  public abstract class GraphNode
  {
    protected Agent agent;                  // Agent located at this graph node    
    protected List<GraphEdge> edges;        // List of edges to the current node    

    public GraphNode()
    {
      edges = new List<GraphEdge>();      
    }

    public void AddEdge(GraphNode destination)
    {
      GraphEdge e = new CommunicationGraphEdge(this, destination);
      if (!edges.Contains(e))
        edges.Add(e);       
    }

    public Agent Value { get { return agent; } set { agent = value; } }

    /// <summary>
    /// Remove the node from the system. Remove the Destinations nodes reference as well
    /// </summary>
    public void Delete()
    {
      for (int j = 0; j < edges.Count; j++)
      {
        GraphEdge e = edges[j];
        for (int i = 0; i < e.DestinationNode.Edges.Count; i++)
        {
          GraphEdge de = e.DestinationNode.Edges[i];
          if (de.DestinationNode == this)
            e.DestinationNode.Edges.Remove(e.DestinationNode.Edges[i]);
        }
      }
    }

    #region Properties
    public List<GraphEdge> Edges { get { return edges; } }
    public PointF Point { get { return agent.Location; } }
    #endregion

  }
}

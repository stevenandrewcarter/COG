using System;
using System.Drawing;
using System.Windows.Forms;
using Clockwork.GraphStructures;
using UtilityClasses;

namespace Clockwork.Agents {
  /// <summary>
  /// Represents the agent in the simulation world
  /// </summary>
  public abstract partial class Agent : TreeNode {
    // Drawing variables
    private Graphics g;                                 // Drawing device
    protected PointF location;                          // Location of the agent in the environment    
    protected int entityID;                             // Represents the id of the drawing entity
    private Image image;                                // Image used to represent the agent in the world
    private bool selected;

    #region Properties

    public PointF Point { get { return location; } set { location = value; } }
    public bool Selected { get { return selected; } set { selected = value; } }

    #endregion

    public void Show() {
      try {
        // Redraw the agent
        if (selected) {
          // Draw the Communication Edges
          if (communicationNode != null)
            foreach (GraphEdge e in communicationNode.Edges)
              g.DrawLine(new Pen(Color.FromArgb(100, 0, 0, 255)), new PointF(location.X + 8.0f, location.Y + 8.0f),
                  new PointF(e.DestinationNode.Point.X + 8.0f, e.DestinationNode.Point.Y + 8.0f));

          // Draw the Coordination Edges
          if (coordinationNode != null)
            foreach (GraphEdge e in coordinationNode.Edges)
              g.DrawLine(new Pen(Color.FromArgb(100, 255, 0, 0)), new PointF(location.X + 8.0f, location.Y + 8.0f),
                  new PointF(e.DestinationNode.Point.X + 8.0f, e.DestinationNode.Point.Y + 8.0f));

          g.DrawEllipse(new Pen(Color.Green), location.X + 0.5f, location.Y + 0.5f, image.Width - 2.0f, image.Height - 2.0f);
          SolidBrush b = new SolidBrush(Color.FromArgb(50, 0, 255, 0));
          g.FillEllipse(b, location.X + 0.5f, location.Y + 0.5f, image.Width - 2.0f, image.Height - 2.0f);
        }
        g.DrawImage(image, location);
      } catch (Exception) {
      }
    }

    public void Draw() {
      if (image != null) {
        Show();
      }
    }

    #region Standard Sensor calls

    /// <summary>
    /// Determines the vector between the source and the destination. Used as a standard
    /// sensor call for all of the agents in the environment.
    /// </summary>
    /// <param name="source">Origin to determine from</param>
    /// <param name="destination">Destination to determine to</param>
    /// <returns>A vector in the direction of the source to the destination</returns>
    public Vector2 DetermineDirection(PointF source, PointF destination) {
      // Create a direction vector towards the point
      Vector2 u = new Vector2(destination);
      Vector2 v = new Vector2(source);
      return u - v;
    }

    public bool Intersect(PointF p) {
      RectangleF bounds = new RectangleF(location, new SizeF(16.0f, 16.0f));
      return bounds.Contains(p);
    }

    #endregion
  }
}

using System;
using System.Drawing;

namespace UtilityClasses {
  public class Vector2 {
    private PointF p;

    public Vector2(float x, float y) {
      p = new PointF(x, y);
    }

    public Vector2(PointF point) {
      p = point;
    }

    public float X { get { return p.X; } }
    public float Y { get { return p.Y; } }

    public static Vector2 operator -(Vector2 u, Vector2 v) {
      return new Vector2(u.p.X - v.p.X, u.p.Y - v.p.Y);
    }

    public float Normal() {
      return (float)Math.Sqrt((double)((p.X * p.X) + (p.Y * p.Y)));
    }

    public Vector2 Normalise() {
      float l = (float)Math.Sqrt((double)((p.X * p.X) + (p.Y * p.Y)));
      return new Vector2(p.X / l, p.Y / l);
    }
  }
}

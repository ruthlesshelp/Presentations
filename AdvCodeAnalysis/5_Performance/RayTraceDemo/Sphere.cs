using System;

namespace RayTraceDemo
{
  class Sphere : ShapeBase
  {
    private readonly Vector myCenter;
    private readonly double myRadius;

    public Vector Center
    {
      get { return myCenter; }
    }

    public double Radius
    {
      get { return myRadius; }
    }

    public Sphere(Vector center, double radius)
    {
      myCenter = center;
      myRadius = radius;
    }

    public override IntersectionData? Intersect(Ray ray)
    {
      double t1;
      double t2;
      var origin = ray.Origin - myCenter;
      if (!MathUtil.SolveSquareEq(ray.Direction * ray.Direction, 
                             2.0 * origin * ray.Direction,
                             (origin * origin) - (myRadius * myRadius), out t1, out t2))
        return null;
      if (t1 < 0 && t2 < 0)
        return null;
      double t;
      if (t1 <= 0 && t2 > 0)
        t = t2;
      else if (t1 > 0 && t2 <= 0)
        t = t1;
      else
        t = Math.Min(t1, t2);

      return new IntersectionData(ray, t, (ray[t] - Center).Normalize());
    }

    public override Vector GetTextureCoords(Vector point)
    {
      var v = point - myCenter;

      return new Vector(GetAngle(v.Z, v.Y), GetAngle(v.X, v.Z), 0);
    }

    private double GetAngle(double x, double y)
    {
      if (Math.Abs(x) < MathUtil.Epsilon)
      {
        if (Math.Abs(y) < MathUtil.Epsilon)
          return 0;

        if (y > 0)
          return Math.PI / 2;
        if (y < 0)
          return 3 * Math.PI / 2;
      }

      if (x > 0 && y < 0)
        return Math.Atan(y / x) + Math.PI * 2;
      if (x < 0)
        return Math.Atan(y / x) + Math.PI;

      return Math.Atan(y / x);
    }
  }
}
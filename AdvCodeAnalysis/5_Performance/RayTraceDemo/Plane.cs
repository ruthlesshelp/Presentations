using System;

namespace RayTraceDemo
{
  public class Plane : ShapeBase
  {
    private readonly Vector myNormal;
    private readonly double myDistance;

    public Plane(Vector normal, double distance)
    {
      myNormal = normal;
      myDistance = distance;
    }

    public override IntersectionData? Intersect(Ray ray)
    {
      var t = (-myDistance - (ray.Origin * myNormal)) / (ray.Direction * myNormal);
      if (t < 0) return null;
      return new IntersectionData(ray, t, myNormal);
    }

    public override Vector GetTextureCoords(Vector point)
    {
      return Vector.Zero;
    }
  }
}
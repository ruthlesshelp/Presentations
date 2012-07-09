using System;
using System.Drawing;

namespace RayTraceDemo
{
  public abstract class ShapeBase : IShape
  {
    public ITexture Texture { get; set; }
    public double Diffuse { get; set; }
    public double Shineness { get; set; }
    public double Ambient { get; set; }
    public double Reflect { get; set; }
    public double Refract { get; set; }

    public double Specular { get; set; }

    public double RefractionCoeff { get; set; }

    public string Name { get; set; }

    protected ShapeBase()
    {
      Texture = new SolidTexture(ColorUtil.ToVector(System.Drawing.Color.White));
      Diffuse = 0.7;
      Specular = 1;
      Shineness = 20;
      Ambient = 0;
      Reflect = 0.5;
      Refract = 0.5;
      RefractionCoeff = 0.8;
      Name = GetType().Name;
    }

    public abstract IntersectionData? Intersect(Ray ray);
    public abstract Vector GetTextureCoords(Vector point);
  }
}
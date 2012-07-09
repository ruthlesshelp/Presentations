using System;

namespace RayTraceDemo
{
  public interface ITexture
  {
    Vector GetColor(double u, double v);
  }

  class SolidTexture : ITexture
  {
    private readonly Vector myColor;

    public SolidTexture(Vector color)
    {
      myColor = color;
    }

    public Vector GetColor(double u, double v)
    {
      return myColor;
    }
  }
}
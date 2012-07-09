using System.Drawing;

namespace RayTraceDemo
{
  public class SpotLight
  {
    private readonly Vector myPoint;
    private readonly Vector myColor;
    private readonly double myLuminosity;

    public double Luminosity
    {
      get { return myLuminosity; }
    }

    public Vector Point
    {
      get { return myPoint; }
    }

    public Vector Color
    {
      get { return myColor; }
    }

    public SpotLight(Vector point, Vector color, double luminosity)
    {
      myPoint = point;
      myLuminosity = luminosity;
      myColor = color;
    }
  }
}
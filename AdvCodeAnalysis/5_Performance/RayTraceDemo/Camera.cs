namespace RayTraceDemo
{
  public class Camera
  {
    private readonly Vector myOrigin;
    private readonly Vector myTop;
    private readonly Vector myRight;

    private readonly double myViewAngle;

    public Vector Origin
    {
      get { return myOrigin; }
    }

    public Vector Top
    {
      get { return myTop; }
    }

    public Vector Right
    {
      get { return myRight; }
    }

    public double ViewAngle
    {
      get { return myViewAngle; }
    }

    public Camera(Vector origin, Vector top, Vector right, double viewAngle)
    {
      myOrigin = origin;
      myViewAngle = viewAngle;
      myTop = top;
      myRight = right;
    }
  }
}
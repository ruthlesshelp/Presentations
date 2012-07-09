namespace RayTraceDemo
{
  public class Ray
  {
    private readonly Vector myOrigin;
    private readonly Vector myDirection;

    public Vector Origin
    {
      get { return myOrigin; }
    }

    public Vector Direction
    {
      get { return myDirection; }
    }

    public Vector this[double t]
    {
      get
      {
        return Origin + t * Direction;
      }
    }

    public Ray(Vector origin, Vector direction)
    {
      myOrigin = origin;
      myDirection = direction;
    }

    public override string ToString()
    {
      return string.Format("Origin: {0}, Direction: {1}", myOrigin, myDirection);
    }
  }
}
using System;

namespace RayTraceDemo
{
  public class Vector
  {
    public static readonly Vector Zero = new Vector(0, 0, 0);

    private readonly double myX;
    private readonly double myY;
    private readonly double myZ;

    public double X
    {
      get { return myX; }
    }

    public double Y
    {
      get { return myY; }
    }

    public double Z
    {
      get { return myZ; }
    }

    public double Length
    {
      get { return Math.Sqrt(this * this); }
    }

    public Vector(double x, double y, double z)
    {
      myX = x;
      myY = y;
      myZ = z;
    }

    public Vector Normalize()
    {
      return Normalize(1);
    }

    public Vector Normalize(double length)
    {
      var factor = length / Length;
      return new Vector(X * factor, Y * factor, Z * factor);
    }

    public Vector Cast(double max)
    {
      return new Vector(X > max ? max : X, Y > max ? max : Y, Z > max ? max : Z);
    }

    public bool Equals(Vector other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return other.myX.Equals(myX) && other.myY.Equals(myY) && other.myZ.Equals(myZ);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof (Vector)) return false;
      return Equals((Vector) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        int result = myX.GetHashCode();
        result = (result*397) ^ myY.GetHashCode();
        result = (result*397) ^ myZ.GetHashCode();
        return result;
      }
    }

    public override string ToString()
    {
      return string.Format("[{0}, {1}, {2}]", myX, myY, myZ);
    }

    /// <summary>
    /// Cross product
    /// </summary>
    public static Vector operator ^ (Vector a, Vector b)
    {
      return new Vector(a.Y * b.Z - - a.Z * b.Y, a.X * b.Z - a.Z * b.Y, a.X * b.Y - a.Y * b.X);
    }

    public static double operator & (Vector a, Vector b)
    {
      return (a * b) / (a.Length * b.Length);
    }

    public static double operator * (Vector a, Vector b)
    {
      return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    }

    public static Vector operator + (Vector a, Vector b)
    {
      return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vector operator - (Vector a, Vector b)
    {
      return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector operator * (Vector v, double m)
    {
      return new Vector(v.X * m, v.Y * m, v.Z * m);
    }

    public static Vector operator / (Vector v, double m)
    {
      return new Vector(v.X / m, v.Y / m, v.Z / m);
    }

    public static Vector operator * (double m, Vector v)
    {
      return new Vector(v.X * m, v.Y * m, v.Z * m);
    }

    public static Vector operator - (Vector v)
    {
      return new Vector(-v.X, -v.Y, -v.Z);
    }
  }
}
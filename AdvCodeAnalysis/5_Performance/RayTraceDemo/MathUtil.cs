using System;

namespace RayTraceDemo
{
  public static class MathUtil
  {
    public const double Epsilon = 1e-6;

    public static double Cast(double v)
    {
      return v < Epsilon ? 0 : v;
    }

    public static bool SolveSquareEq(double a, double b, double c, out double x1, out double x2)
    {
      double d = b * b - 4 * a * c;
      if (d < 0)
      {
        x1 = Double.NaN;
        x2 = Double.NaN;
        return false;
      }

      x1 = (-b + Math.Sqrt(d)) / (2 * a);
      x2 = (-b - Math.Sqrt(d)) / (2 * a);
      return true;
    }
  }
}
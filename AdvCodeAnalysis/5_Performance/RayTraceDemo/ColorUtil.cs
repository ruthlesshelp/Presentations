using System;
using System.Collections.Generic;
using System.Drawing;

namespace RayTraceDemo
{
  public static class ColorUtil
  {
    public static Vector ToVector(Color c)
    {
      return new Vector((double)c.R / 255, (double)c.G / 255, (double)c.B / 255);
    }

    public static Color ToColor(Vector v)
    {
      return Color.FromArgb(255, (int) (v.X * 255), (int) (v.Y * 255), (int) (v.Z * 255));
    }

    public static Color Add(IEnumerable<Color> colors)
    {
      int r = 0, g = 0, b = 0, c = 0;
      foreach (var color in colors)
      {
        r += color.R;
        g += color.G;
        b += color.B;
        c++;
      }

      if (c == 0)
        return Color.Black;

      if (r > 255) r = 255;
      if (g > 255) g = 255;
      if (b > 255) b = 255;

      return Color.FromArgb(255, r, g, b);
    }

    public static Color Multiply(Color c, double factor)
    {
      if (factor < 0 || factor > 1)
        throw new ArgumentOutOfRangeException("factor");

      return Color.FromArgb(255, (int) (c.R * factor), (int) (c.G * factor), (int) (c.B * factor));
    }

    public static Color Multiply(Color x, Color y)
    {
      var r = x.R * y.R;
      var g = x.G * y.G;
      var b = x.B * y.B;

      if (r > 255) r = 255;
      if (g > 255) g = 255;
      if (b > 255) b = 255;

      return Color.FromArgb(255, r, g, b);
    }

    public static Color Add(Color a, Color b, double proportion)
    {
      return Color.FromArgb(255,
                            (int) (a.R * proportion + b.R * (1 - proportion)),
                            (int) (a.G * proportion + b.G * (1 - proportion)),
                            (int) (a.B * proportion + b.B * (1 - proportion)));
    }
  }
}
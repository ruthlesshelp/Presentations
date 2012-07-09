using System;

namespace RayTraceDemo
{
  public class CheckeredTexture : ITexture
  {
    private readonly ITexture myBlackTexture;
    private readonly ITexture myWhiteTexture;
    private readonly double myCheckerSize;

    public CheckeredTexture(ITexture blackTexture, ITexture whiteTexture, double checkerSize)
    {
      myBlackTexture = blackTexture;
      myWhiteTexture = whiteTexture;
      myCheckerSize = checkerSize;
    }

    public Vector GetColor(double u, double v)
    {
      int x = (int) Math.Floor(u / myCheckerSize);
      int y = (int) Math.Floor(v / myCheckerSize);

      return (x + y) % 2 == 0 ? myBlackTexture.GetColor(u, v) : myWhiteTexture.GetColor(u, v);
    }
  }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RayTraceDemo
{
  public class RayTracer
  {
    public readonly object LockObject = new object();

    private readonly Bitmap myBitmap;
    private readonly List<IShape> myShapes = new List<IShape>();
    private readonly List<SpotLight> myLights = new List<SpotLight>();

    private int myTraceDepth = 0;

    public IList<IShape> Shapes
    {
      get { return myShapes; }
    }

    public List<SpotLight> Lights
    {
      get { return myLights; }
    }

    public RayTracer(Bitmap bitmap)
    {
      myBitmap = bitmap;
    }

    public int AntiAliasPasses { get; set; }

    public void RayTrace(Camera camera, StringBuilder[,] logs)
    {
      int width = myBitmap.Width;
      int height = myBitmap.Height;

      var forward = camera.Right ^ camera.Top;
      var xAngle = width > height ? camera.ViewAngle : camera.ViewAngle * width / height;
      var yAngle = height > width ? camera.ViewAngle : camera.ViewAngle * height / width;
      
      for (int i = 0; i < height; i++)
        for (int j = 0; j < width; j++)
        {
          lock (LockObject)
          {
            Vector color = Vector.Zero;

            for (int ii = 0; ii < AntiAliasPasses; ii++)
              for (int jj = 0; jj < AntiAliasPasses; jj++)
              {
                var x = (double) (j * AntiAliasPasses + jj) / (width * AntiAliasPasses) - 0.5;
                var y = (double) (i * AntiAliasPasses + ii) / (height * AntiAliasPasses) - 0.5;
                var direction = camera.Right * Math.Sin(x * xAngle) +
                                camera.Top * Math.Sin(y * yAngle) +
                                forward * (Math.Cos(x * camera.ViewAngle) + Math.Cos(y * camera.ViewAngle));

                var ray = new Ray(camera.Origin, direction);

                myTraceDepth = 0;
                color = color + TraceRay(ray, logs == null ? null : logs[j, height - 1 - i]);
              }

            myBitmap.SetPixel(j, height - 1 - i, ColorUtil.ToColor((color / (AntiAliasPasses * AntiAliasPasses))));
          }
        }
    }

    private bool IntersectRay(Ray ray, out IShape minShape, out IntersectionData mint)
    {
      mint = new IntersectionData(ray, double.PositiveInfinity, null);
      minShape = null;

      foreach (var shape in Shapes)
      {
        var t = shape.Intersect(ray);
        if (t == null) continue;

        if (t.Value.RayPoint < mint.RayPoint)
        {
          mint = t.Value;
          minShape = shape;
        }
      }

      return minShape != null;
    }

    private Vector Reflect(Vector vector, Vector normal)
    {
      return vector - 2 * (normal * (normal & vector));
    }

    private Vector TraceRay(Ray ray, StringBuilder log)
    {
      myTraceDepth++;
      if (myTraceDepth > 5)
        return Vector.Zero;

      if (log != null)
        log.AppendLine(string.Format("Incoming ray: {0}", ray));

      IShape shape;
      IntersectionData intersectionData;
      if (!IntersectRay(ray, out shape, out intersectionData))
        return Vector.Zero;

      var intersectionPoint = ray[intersectionData.RayPoint] + intersectionData.Normal.Normalize(MathUtil.Epsilon); 
      if (log != null)
      {
        log.AppendLine(string.Format("Intersection: {0}", intersectionPoint));
        log.AppendLine(string.Format("Normal: {0}", intersectionData.Normal));
        log.AppendLine(string.Format("Shape: {0}", shape.Name));
      }

      var texCoords = shape.GetTextureCoords(intersectionPoint);
      var color = shape.Texture.GetColor(texCoords.X, texCoords.Y) * shape.Ambient;
      foreach (var light in Lights)
      {
        var lightDirection = light.Point - intersectionPoint;
        IShape lightShape;
        IntersectionData lightIntersectionData;
        var rayToLight = new Ray(intersectionPoint, lightDirection);
        if (log != null)
          log.AppendLine(string.Format("Ray to light: {0}", rayToLight));
        if (IntersectRay(rayToLight, out lightShape, out lightIntersectionData))
          if (lightIntersectionData.RayPoint < 1)
            continue;

        var specular = ray.Direction & Reflect(lightDirection.Normalize(), intersectionData.Normal);
        if (specular > 0)
          specular = Math.Pow(specular, shape.Shineness) * shape.Specular;
        else
          specular = 0;

        color = color + (light.Color * light.Luminosity * shape.Diffuse * MathUtil.Cast(lightDirection & intersectionData.Normal)) + (light.Color * specular);
      }

      var reflectedDirection = Reflect(ray.Direction.Normalize(), intersectionData.Normal);

      var reflectedColor = TraceRay(new Ray(intersectionPoint, reflectedDirection), log);

      color = color + shape.Reflect * reflectedColor;

      return color.Cast(1);
    }
  }
}
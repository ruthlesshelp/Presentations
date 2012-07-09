namespace RayTraceDemo
{
  public interface IShape
  {
    ITexture Texture { get; set; }
    double Diffuse { get; set; }
    double Specular { get; set; }
    double Shineness { get; set; }
    double Ambient { get; set; }
    double Reflect { get; set; }
    double Refract { get; set; }
    double RefractionCoeff { get; set; }
    string Name { get; set; }

    IntersectionData? Intersect(Ray ray);
    Vector GetTextureCoords(Vector point);
  }

  public struct IntersectionData
  {
    public Ray Ray { get; private set; }
    public double RayPoint { get; private set; }
    public Vector Normal { get; private set; }

    public IntersectionData(Ray ray, double rayPoint, Vector normal) : this()
    {
      Ray = ray;
      RayPoint = rayPoint;
      Normal = normal;
    }
  }
}
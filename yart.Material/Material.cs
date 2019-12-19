using System.Numerics;
namespace yart
{
    public struct HitRecord
    {
        // Do I even need Motion Blur? Anyway lets not break the design, :P
        public float T;
        public Vector3 Position, Normal;
        public Material Mat;
    }
    public interface Material
    {
        bool Scatter(Ray r, HitRecord rec, ref Vector3 attenuation, ref Ray scattered);
    }
}
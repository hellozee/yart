using System.Numerics;
namespace yart
{
    public struct HitRecord
    {
        // Do I even need Motion Blur? Anyway lets not break the design, :P
        public float T;
        public Vector3 Position, Normal;
        public IMaterial Mat;
    }
    public interface IMaterial
    {
        bool Scatter(Ray r, HitRecord rec, ref Vector3 attenuation, ref Ray scattered);
        Vector3 Emit(float u, float v, Vector3 pos);
    }
}
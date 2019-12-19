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
    
    public interface IObject
    {
        bool Hit(Ray r, float tMin, float tMax, ref HitRecord record);
    }
}
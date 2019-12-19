using System.Numerics;

namespace yart
{
    public class HitRecord
    {
        // Do I even need Motion Blur? Anyway lets not break the design, :P
        public float T { get; set; }
        public Vector3 Position{ get; set; }
        public Vector3 Normal{ get; set; }
        
        public Material Mat { get; set; }

        public HitRecord()
        {
            Position = new Vector3();
            Normal = new Vector3();
            T = 0.0f;
        }
    }
    
    public interface IObject
    {
        bool Hit(Ray r, float tMin, float tMax, ref HitRecord record);
    }
}
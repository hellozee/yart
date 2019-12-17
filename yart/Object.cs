namespace yart
{
    public class HitRecord
    {
        public double T { get; set; }
        public Vec3 Position{ get; set; }
        public Vec3 Normal{ get; set; }

        public HitRecord()
        {
            Position = new Vec3();
            Normal = new Vec3();
            T = 0.0f;
        }
    }
    
    public interface IObject
    {
        bool Hit(Ray r, double tMin, double tMax, ref HitRecord record);
    }
}
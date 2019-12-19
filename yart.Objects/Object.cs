using System.Numerics;

namespace yart
{
    public interface IObject
    {
        bool Hit(Ray r, float tMin, float tMax, ref HitRecord record);
    }
}
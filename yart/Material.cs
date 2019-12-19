using System.Numerics;
namespace yart
{
    public interface Material
    {
        bool Scatter(Ray r, HitRecord rec, ref Vector3 attenuation, ref Ray scattered);
    }
}
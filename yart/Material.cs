namespace yart
{
    public interface Material
    {
        bool Scatter(Ray r, HitRecord rec, ref Vec3 attenuation, ref Ray scattered);
    }
}
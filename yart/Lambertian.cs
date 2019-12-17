using System;

namespace yart
{
    public class Lambertian : Material
    {
        private readonly Vec3 _albedo;
        private readonly Random _rnd;
        private Vec3 RandomPointInSphere()
        {
            Vec3 p;
            do
            {
                p = 2.0 * new Vec3(_rnd.NextDouble(), _rnd.NextDouble(), _rnd.NextDouble()) - new Vec3(1);
            } while (p.Magnitude() >= 1.0);

            return p;
        }

        public Lambertian(Vec3 albedo)
        {
            _albedo = albedo;
            _rnd = new Random(50);
        }
        
        public bool Scatter(Ray r, HitRecord rec, ref Vec3 attenuation, ref Ray scattered)
        {
            var target = rec.Position + rec.Normal + RandomPointInSphere();
            scattered = new Ray(rec.Position, target - rec.Position);
            attenuation = _albedo;
            return true;
        }
    }
}
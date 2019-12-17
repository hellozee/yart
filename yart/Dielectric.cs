using System;

namespace yart
{
    public class Dielectric : Material
    {
        private readonly double _refractiveIndex;
        private readonly Random _rnd;

        public static bool Refract(Vec3 v, Vec3 n, double refractiveIndex, ref Vec3 refracted)
        {
            var uv = v.Normalize();
            var dt = Vec3.Dot(uv, n);
            var d = 1.0 - refractiveIndex * refractiveIndex * (1 - dt * dt);

            if (d <= 0) return false;
            
            refracted = refractiveIndex * (uv - n * dt) - n * Math.Sqrt(d);
            return true;

        }

        public static double Schlick(double cosine, double refractiveIndex)
        {
            var r0 = (1 - refractiveIndex) / (1 + refractiveIndex);
            r0 *= r0;
            return r0 + (1 - r0) * Math.Pow(1 - cosine, 5);
        }
        
        public Dielectric(double refractiveIndex)
        {
            _refractiveIndex = refractiveIndex;
            _rnd = new Random(67);
        }
        
        public bool Scatter(Ray r, HitRecord rec, ref Vec3 attenuation, ref Ray scattered)
        {
            Vec3 outwardNormal;
            var reflected = Metal.Reflect(r.Direction(), rec.Normal);
            double refractiveIndex, cosine, reflectionFactor;
            attenuation = new Vec3(1.0, 1.0, 1.0);
            var refracted = new Vec3();

            if (Vec3.Dot(r.Direction(), rec.Normal) > 0)
            {
                outwardNormal = (-1) * rec.Normal;
                refractiveIndex = _refractiveIndex;
                cosine = refractiveIndex * Vec3.Dot(r.Direction(), rec.Normal) 
                         / r.Direction().Magnitude();
            }
            else
            {
                outwardNormal = rec.Normal;
                refractiveIndex = 1.0 / _refractiveIndex;
                cosine = -1 * Vec3.Dot(r.Direction(), rec.Normal) / r.Direction().Magnitude();
            }

            if (Refract(r.Direction(), outwardNormal, refractiveIndex, ref refracted))
            {
                reflectionFactor = Schlick(cosine, refractiveIndex);
            }
            else
            {
                reflectionFactor = 1.0;
            }

            scattered = _rnd.NextDouble() < reflectionFactor ? 
                new Ray(rec.Position, reflected) : new Ray(rec.Position, refracted);

            return true;
        }
    }
}
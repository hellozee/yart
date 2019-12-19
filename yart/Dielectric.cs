using System;
using System.Numerics;

namespace yart
{
    public class Dielectric : Material
    {
        private readonly float _refractiveIndex;
        private readonly Random _rnd;

        public static bool Refract(Vector3 v, Vector3 n, float refractiveIndex, ref Vector3 refracted)
        {
            var uv = Vector3.Normalize(v);
            var dt = Vector3.Dot(uv, n);
            var d = 1.0 - refractiveIndex * refractiveIndex * (1 - dt * dt);

            if (d <= 0) return false;
            
            refracted = refractiveIndex * (uv - n * dt) - n * (float) Math.Sqrt(d);
            return true;

        }

        public static float Schlick(float cosine, float refractiveIndex)
        {
            var r0 = (1 - refractiveIndex) / (1 + refractiveIndex);
            r0 *= r0;
            return (float) (r0 + (1 - r0) * Math.Pow(1 - cosine, 5));
        }
        
        public Dielectric(float refractiveIndex)
        {
            _refractiveIndex = refractiveIndex;
            _rnd = new Random(67);
        }
        
        public bool Scatter(Ray r, HitRecord rec, ref Vector3 attenuation, ref Ray scattered)
        {
            Vector3 outwardNormal;
            var reflected = Metal.Reflect(r.Direction(), rec.Normal);
            float refractiveIndex, cosine, reflectionFactor;
            attenuation = new Vector3(1.0f, 1.0f, 1.0f);
            var refracted = new Vector3();

            if (Vector3.Dot(r.Direction(), rec.Normal) > 0)
            {
                outwardNormal = (-1) * rec.Normal;
                refractiveIndex = _refractiveIndex;
                cosine = refractiveIndex * Vector3.Dot(r.Direction(), rec.Normal) 
                         / r.Direction().Length();
            }
            else
            {
                outwardNormal = rec.Normal;
                refractiveIndex = (float) (1.0 / _refractiveIndex);
                cosine = -1 * Vector3.Dot(r.Direction(), rec.Normal) / r.Direction().Length();
            }

            if (Refract(r.Direction(), outwardNormal, refractiveIndex, ref refracted))
            {
                reflectionFactor = Schlick(cosine, refractiveIndex);
            }
            else
            {
                reflectionFactor = 1.0f;
            }

            scattered = _rnd.NextDouble() < reflectionFactor ? 
                new Ray(rec.Position, reflected) : new Ray(rec.Position, refracted);

            return true;
        }
    }
}
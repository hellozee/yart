using System;
using System.Numerics;

namespace yart
{
    public class Lambertian : IMaterial
    {
        private readonly Vector3 _albedo;
        private readonly Random _rnd;
        private Vector3 RandomPointInHemiSphere(Vector3 normal)
        {
            Vector3 p;
            do
            {
                p = 2.0f * new Vector3((float) _rnd.NextDouble(), 
                        (float) _rnd.NextDouble(), (float) _rnd.NextDouble()) - new Vector3(1);
            } while (p.Length() >= 1.0 && Vector3.Dot(p, normal) >= 0);

            return p;
        }

        public Lambertian(Vector3 albedo)
        {
            _albedo = albedo;
            _rnd = new Random();
        }
        
        public bool Scatter(Ray r, HitRecord rec, ref Vector3 attenuation, ref Ray scattered)
        {
            var target = rec.Position + rec.Normal + RandomPointInHemiSphere(rec.Normal);
            scattered = new Ray(rec.Position, target - rec.Position);
            attenuation = _albedo;
            return true;
        }

        public Vector3 Emit(float u, float v, Vector3 pos)
        {
            return Vector3.Zero;
        }
    }
}
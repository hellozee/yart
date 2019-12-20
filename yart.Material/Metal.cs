using System.Numerics;

namespace yart
{
    public class Metal : IMaterial
    {
        private readonly Vector3 _albedo;

        public static Vector3 Reflect(Vector3 v, Vector3 n)
        {
            return v - 2 * Vector3.Dot(v, n) * n;
        }

        public Metal(Vector3 albedo)
        {
            _albedo = albedo;
        }
        public bool Scatter(Ray r, HitRecord rec, ref Vector3 attenuation, ref Ray scattered)
        {
            var reflected = Reflect(Vector3.Normalize(r.Direction), rec.Normal);
            scattered = new Ray(rec.Position, reflected);
            attenuation = _albedo;
            return (Vector3.Dot(scattered.Direction, rec.Normal) > 0);
        }

        public Vector3 Emit(float u, float v, Vector3 pos)
        {
            return Vector3.Zero;
        }
    }
}
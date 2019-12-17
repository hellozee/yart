namespace yart
{
    public class Metal : Material
    {
        private readonly Vec3 _albedo;

        public static Vec3 Reflect(Vec3 v, Vec3 n)
        {
            return v - 2 * Vec3.Dot(v, n) * n;
        }

        public Metal(Vec3 albedo)
        {
            _albedo = albedo;
        }
        public bool Scatter(Ray r, HitRecord rec, ref Vec3 attenuation, ref Ray scattered)
        {
            var reflected = Reflect(r.Direction().Normalize(), rec.Normal);
            scattered = new Ray(rec.Position, reflected);
            attenuation = _albedo;
            return (Vec3.Dot(scattered.Direction(), rec.Normal) > 0);
        }
    }
}
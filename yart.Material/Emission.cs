using System.Numerics;

namespace yart.Material
{
    public class Emission : IMaterial
    {
        private readonly Vector3 _albedo;
        private readonly float _intensity;

        public Emission(Vector3 albedo, float intensity)
        {
            _albedo = albedo;
            _intensity = intensity;
        }
        
        public bool Scatter(Ray r, HitRecord rec, ref Vector3 attenuation, ref Ray scattered)
        {
            return false;
        }

        public Vector3 Emit(float u, float v, Vector3 pos)
        {
            return _albedo * _intensity;
        }
    }
}
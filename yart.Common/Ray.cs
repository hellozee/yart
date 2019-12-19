using System.Numerics;

namespace yart
{
    public class Ray
    {
        private readonly Vector3 _origin, _direction;

        public Ray()
        {
            _origin = new Vector3();
            _direction = new Vector3();
        }
        public Ray(Vector3 origin, Vector3 direction)
        {
            _origin = origin;
            _direction = direction;
        }
        

        public Vector3 Origin() => _origin;

        public Vector3 Direction() => _direction;

        public Vector3 PointAt(float t) => _origin + t * _direction;
        
    }
}
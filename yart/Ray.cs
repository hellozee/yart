namespace yart
{
    public class Ray
    {
        private readonly Vec3 _origin, _direction;

        public Ray()
        {
            _origin = new Vec3();
            _direction = new Vec3();
        }

        public Ray(Vec3 origin, Vec3 direction)
        {
            _origin = origin;
            _direction = direction;
        }

        public Vec3 Origin() => _origin;

        public Vec3 Direction() => _direction;

        public Vec3 PointAt(double t) => _origin + t * _direction;
        
    }
}
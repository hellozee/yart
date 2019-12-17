namespace yart
{
    public class Camera
    {
        private readonly Vec3 _lowerLeft, _horizontal, _vertical, _origin;

        public Camera()
        {
            _lowerLeft = new Vec3(-2.0, -1.0, -1.0);
            _horizontal = new Vec3(4.0, 0.0, 0.0);
            _vertical = new Vec3(0.0, 2.0, 0.0);
            _origin = new Vec3(0.0, 0.0, 0.0);
        }

        public Ray GetRay(double u, double v)
        {
            return new Ray(_origin, _lowerLeft + u * _horizontal + v * _vertical - _origin);
        }
    }
}
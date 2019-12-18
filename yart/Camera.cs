using System;

namespace yart
{
    public class Camera
    {
        private readonly Vec3 _lowerLeft, _horizontal, _vertical, _origin;

        public Camera(Vec3 lookFrom, Vec3 lookAt, Vec3 upAxis, double verticalFoV, double aspectRatio)
        {
            var theta = verticalFoV * Math.PI / 180;
            var heightBy2 = Math.Tan(theta / 2);
            var widthBy2 = aspectRatio * heightBy2;
            _origin = lookFrom;
            var w = (lookFrom - lookAt).Normalize();
            var u = Vec3.Cross(upAxis, w).Normalize();
            var v = Vec3.Cross(w, u);
            _lowerLeft = _origin - widthBy2 * u - heightBy2 * v - w;
            _horizontal = 2 * widthBy2 * u;
            _vertical = 2 * heightBy2 * v;
        }

        public Ray GetRay(double u, double v)
        {
            return new Ray(_origin, _lowerLeft + u * _horizontal + v * _vertical - _origin);
        }
    }
}
using System;
using System.Numerics;

namespace yart
{
    public class Camera
    {
        private readonly Vector3 _lowerLeft, _horizontal, _vertical, _origin;

        public Camera(Vector3 lookFrom, Vector3 lookAt, Vector3 upAxis, float verticalFoV, float aspectRatio)
        {
            var theta = (float) (verticalFoV * Math.PI / 180);
            var heightBy2 = (float) Math.Tan(theta / 2);
            var widthBy2 = aspectRatio * heightBy2;
            _origin = lookFrom;
            var w = Vector3.Normalize(lookFrom - lookAt);
            var u = Vector3.Normalize(Vector3.Cross(upAxis, w));
            var v = Vector3.Cross(w, u);
            _lowerLeft = _origin - widthBy2 * u - heightBy2 * v - w;
            _horizontal = 2 * widthBy2 * u;
            _vertical = 2 * heightBy2 * v;
        }

        public Ray GetRay(float u, float v)
        {
            return new Ray(_origin, _lowerLeft + u * _horizontal + v * _vertical - _origin);
        }
    }
}
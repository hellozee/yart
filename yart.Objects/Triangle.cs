using System;
using System.Numerics;

namespace yart.Objects
{
    
    public class Triangle : IObject
    {
        private readonly Vector3 _a, _b, _c, _normal;
        private readonly IMaterial _mat;

        public Triangle(Vector3 a, Vector3 b, Vector3 c, Vector3 normal, IMaterial mat)
        {
            _a = a;
            _b = b;
            _c = c;
            _mat = mat;
            _normal = normal;
        }
        public bool Hit(Ray r, float tMin, float tMax, ref HitRecord record)
        {
            var dot = Vector3.Dot(_normal, r.Direction);
            if (dot >= 0)
                return false;
            
            var d = Vector3.Dot(_normal, _a);
            var t = -(Vector3.Dot(_normal, r.Origin) + d) / dot;
            if (t > tMax && t < tMin)
                return false;
            
            var pt = r.PointAt(t);
            
            var E1 = _b - _a;
            var E2 = _c - _b;
            var E3 = _a - _c;
            var C1 = pt - _a;
            var C2 = pt - _b;
            var C3 = pt - _c;

            if (Vector3.Dot(_normal, Vector3.Cross(E1, C1)) < 0 ||
                Vector3.Dot(_normal, Vector3.Cross(E2, C2)) < 0 ||
                Vector3.Dot(_normal, Vector3.Cross(E3, C3)) < 0)
                return false;

            record.Position = pt;
            record.Normal = _normal;
            record.Mat = _mat;
            record.T = t;
            return true;
        }
    }
}
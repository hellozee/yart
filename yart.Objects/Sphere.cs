using System;
using System.Numerics;

namespace yart
{
    public class Sphere : IObject
    {
        private readonly Vector3 _center;
        private readonly float _radius;
        private readonly IMaterial _material;

        public Sphere(Vector3 center, float radius, IMaterial material)
        {
            _center = center;
            _radius = radius;
            _material = material;
        }
        
        public bool Hit(Ray r, float tMin, float tMax, ref HitRecord record)
        {
            var oc = r.Origin - _center;
            var a = Vector3.Dot(r.Direction, r.Direction);
            var b = Vector3.Dot(oc, r.Direction);
            var c = Vector3.Dot(oc, oc) - _radius * _radius;
            var discriminant = b * b - a * c;

            if (discriminant > 0)
            {
                var temp = (float) (-b - Math.Sqrt(discriminant)) / a;
                if (temp < tMax && temp > tMin)
                {
                    record.T = temp;
                    record.Position = r.PointAt(temp);
                    record.Normal = (record.Position - _center) / _radius;
                    record.Mat = _material;
                    return true;
                }
                
                temp = (float) (-b + Math.Sqrt(discriminant)) / a;
                if (temp < tMax && temp > tMin)
                {
                    record.T = temp;
                    record.Position = r.PointAt(temp);
                    record.Normal = (record.Position - _center) / _radius;
                    record.Mat = _material;
                    return true;
                }
                
            }
            
            return false;
        }
    }
}
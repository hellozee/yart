using System;

namespace yart
{
    public class Sphere : IObject
    {
        private readonly Vec3 _center;
        private readonly double _radius;

        public Sphere(Vec3 center, double radius)
        {
            _center = center;
            _radius = radius;
        }
        
        public bool Hit(Ray r, double tMin, double tMax, ref HitRecord record)
        {
            var oc = r.Origin() - _center;
            var a = Vec3.Dot(r.Direction(), r.Direction());
            var b = Vec3.Dot(oc, r.Direction());
            var c = Vec3.Dot(oc, oc) - _radius * _radius;
            var discriminant = b * b - a * c;

            if (discriminant > 0)
            {
                var temp = (-b - Math.Sqrt(discriminant)) / a;
                if (temp < tMax && temp > tMin)
                {
                    record.T = temp;
                    record.Position = r.PointAt(temp);
                    record.Normal = (record.Position - _center) / _radius;
                    return true;
                }
                
                temp = (-b + Math.Sqrt(discriminant)) / a;
                if (temp < tMax && temp > tMin)
                {
                    record.T = temp;
                    record.Position = r.PointAt(temp);
                    record.Normal = (record.Position - _center) / _radius;
                    return true;
                }
                
            }
            
            return false;
        }
    }
}
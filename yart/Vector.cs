using System;

namespace yart
{
    public class Vec3
    {
        private readonly double _x, _y, _z;
        
        public Vec3()
        {
            _x = _y = _z = 0;
        }

        public Vec3(double val)
        {
            _x = _y = _z = val;
        }

        public Vec3(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public double Getx() => _x;
        
        public double Gety() => _y;
        
        public double Getz() => _z;
        
        public static Vec3 operator +(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.Getx() + v2.Getx(),
                v1.Gety() + v2.Gety(),
                v1.Getz() + v2.Getz());
        }

        public static Vec3 operator -(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.Getx() - v2.Getx(),
                v1.Gety() - v2.Gety(),
                v1.Getz() - v2.Getz());
        }

        public static Vec3 operator *(Vec3 v, double val)
        {
            return new Vec3(v.Getx() * val,
                v.Gety() * val,
                v.Getz() * val);
        }

        public static Vec3 operator *(double val, Vec3 v) => v * val;

        public static Vec3 operator *(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.Getx() * v2.Getx(),
                v1.Gety() * v2.Gety(),
                v1.Getz() * v2.Getz());
        }

        public static Vec3 operator /(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.Getx()/v2.Getx(),
                v1.Gety()/v2.Gety(),
                v1.Getz()/v2.Getz());
        }

        public static Vec3 operator /(Vec3 v, double val)
        {
            return new Vec3(v.Getx()/val,
                v.Gety()/val,
                v.Getz()/val);
        }

        public double Magnitude()
        {
            return Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }

        public Vec3 Normalize()
        {
            return this/this.Magnitude();
        }

        public static double Dot(Vec3 v1, Vec3 v2)
        {
            return v1.Getx() * v2.Getx() + v1.Gety() * v2.Gety() + v1.Getz() * v2.Getz();
        }

        public static Vec3 Cross(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.Gety() * v2.Getz() - v1.Getz() * v2.Gety(),
                v1.Getz() * v2.Getx() - v1.Getx() * v2.Getz(),
                v1.Getx() * v2.Gety() - v1.Gety() * v2.Getx());
        }
        
        public static bool operator ==(Vec3 v1, Vec3 v2)
        {
            return v1.Getx() == v2.Getx() && v1.Gety() == v2.Gety() && v1.Getz() == v2.Getz();
        }

        public static bool operator !=(Vec3 v1, Vec3 v2)
        {
            return !(v1 == v2);
        }

        public override string ToString()
        {
            return _x + " " + _y + " " + _z;
        }
    }
}
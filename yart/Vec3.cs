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

        public double Getx()
        {
            return _x;
        }
        
        public double Gety()
        {
            return _y;
        }

        public double Getz()
        {
            return _z;
        }


        public static bool operator ==(Vec3 v1, Vec3 v2)
        {
            return v1.Getx() == v2.Getx() && v1.Gety() == v2.Gety() && v1.Getz() == v2.Getz();
        }

        public static bool operator !=(Vec3 v1, Vec3 v2)
        {
            return !(v1 == v2);
        }
    }
}
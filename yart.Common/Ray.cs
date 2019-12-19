using System.Numerics;

namespace yart
{
    public struct Ray
    {
        public readonly Vector3 Origin, Direction;
        
        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
        }
        
        public Vector3 PointAt(float t) => Origin + t * Direction;
        
    }
}
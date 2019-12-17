using System.Collections.Generic;

namespace yart
{
    internal static class Program
    {
        private static Color color(Ray r, IObject world)
        {
            var rec = new HitRecord();

            if (world.Hit(r, 0.0, double.MaxValue, ref rec))
            {
                return new Color(0.5 * (rec.Normal + new Vec3(1.0f)));
            }
            
            var unitVec = r.Direction().Normalize();
            var t = 0.5f * (unitVec.Gety() + 1.0f);
            return new Color((1.0 - t) * new Vec3(1.0f) + 
                             t * new Vec3(0.5, 0.7, 1.0));
        }
        public static void Main(string[] args)
        {
            var size = new Size(800, 400);
            var lowerLeft = new Vec3(-2.0, -1.0, -1.0);
            var horizontal = new Vec3(4.0, 0.0, 0.0);
            var vertical = new Vec3(0.0, 2.0, 0.0);
            var origin = new Vec3(0.0, 0.0, 0.0);
            var img = new Image(size);
            
            var list = new List<IObject>();
            list.Add(new Sphere(new Vec3(0, 0, -1), 0.5));
            list.Add(new Sphere(new Vec3(0, -100.5, -1), 100));
            
            var world = new Scene(list);

            for (var i = 0; i < size.Height; i++)
            {
                for (var j = 0; j < size.Width; j++)
                {
                    var u = (double) j / (double) size.Width;
                    var v = (double) (size.Height - i -1) / (double) size.Height;
                    var r = new Ray(origin, lowerLeft + u*horizontal + v*vertical);
                    var c = color(r, world);
                    img.SetColor(i, j, c);
                }
            }
            
            img.Save("ding");
        }
    }
}
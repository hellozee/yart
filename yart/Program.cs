using System;
using System.Collections.Generic;

namespace yart
{
    internal static class Program
    {
        private static Vec3 color(Ray r, IObject world, int depth)
        {
            var rec = new HitRecord();

            if (world.Hit(r, 0.001, double.MaxValue, ref rec))
            {
                var scattered = new Ray();
                var attenuation = new Vec3();
                if (depth < 50 && rec.Mat.Scatter(r, rec, ref attenuation, ref scattered))
                {
                    var ret = attenuation * color(scattered, world, depth + 1);
                    return ret;
                }
                else
                {
                    return new Vec3();
                }
            }
            
            var unitVec = r.Direction().Normalize();
            var t = 0.5f * (unitVec.Gety() + 1.0f);
            return (1.0 - t) * new Vec3(1.0f) + t * new Vec3(0.5, 0.7, 1.0);
        }
        
        public static void Main(string[] args)
        {
            var size = new Size(800, 400);
            const int samples = 100;
            var img = new Image(size);
            var cam = new Camera();
            
            var list = new List<IObject>();
            list.Add(new Sphere(new Vec3(0, 0, -1), 0.5, 
                new Lambertian(new Vec3(0.8, 0.3, 0.3))));
            list.Add(new Sphere(new Vec3(0, -100.5, -1), 100, 
                new Lambertian(new Vec3(0.8, 0.8, 0))));
            list.Add(new Sphere(new Vec3(1, 0, -1), 0.5, 
                new Metal(new Vec3(0.8, 0.6, 0.2))));
            list.Add(new Sphere(new Vec3(-1, 0, -1), 0.5,
                new Metal(new Vec3(0.8, 0.8, 0.8))));
            
            var world = new Scene(list);

            for (var i = 0; i < size.Height; i++)
            {
                for (var j = 0; j < size.Width; j++)
                {
                    var col = new Vec3();
                    
                    for(var s=0; s<samples; s++){
                        var u = (double) ( j + new Random().NextDouble()) / (double) size.Width;
                        var v = (double) (size.Height - i -1 + new Random().NextDouble()) / (double) size.Height;
                        var r = cam.GetRay(u, v);
                        col += color(r, world, 0);
                    }
                    col /= samples;
                    col = new Vec3(Math.Sqrt(col.Getx()), Math.Sqrt(col.Gety()), Math.Sqrt(col.Getz()));
                    img.SetColor(i, j, new Color(col));
                }
            }
            
            img.Save("ding");
        }
    }
}
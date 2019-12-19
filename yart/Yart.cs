using System;
using System.Collections.Generic;
using System.Numerics;

namespace yart
{
    internal static class Yart
    {
        private static Vector3 color(Ray r, IObject world, int depth)
        {
            var rec = new HitRecord();

            if (world.Hit(r, 0.001f, float.MaxValue, ref rec))
            {
                var scattered = new Ray();
                var attenuation = new Vector3();
                if (depth < 50 && rec.Mat.Scatter(r, rec, ref attenuation, ref scattered))
                {
                    var ret = attenuation * color(scattered, world, depth + 1);
                    return ret;
                }
                else
                {
                    return new Vector3();
                }
            }
            
            var unitVec = Vector3.Normalize(r.Direction());
            var t = 0.5f * (unitVec.Y + 1.0f);
            return (1.0f - t) * new Vector3(1.0f) + t * new Vector3(0.5f, 0.7f, 1.0f);
        }
        
        public static void Main(string[] args)
        {
            var size = new Size(640, 360);
            const int samples = 50;
            var img = new Image(size);
            var cam = new Camera(new Vector3(-2, 2, 1), new Vector3(0, 0, -1),
                new Vector3(0, 1, 0), 50, (float) size.Width/size.Height);
            
            var list = new List<IObject>();
            list.Add(new Sphere(new Vector3(0, 0, -1), 0.5f, new Lambertian(new Vector3(0.8f, 0.3f, 0.3f))));
            list.Add(new Sphere(new Vector3(0, -100.5f, -1), 100, new Lambertian(new Vector3(0.8f, 0.8f, 0))));
            list.Add(new Sphere(new Vector3(1, 0, -1), 0.5f, new Metal(new Vector3(0.8f, 0.6f, 0.2f))));
            list.Add(new Sphere(new Vector3(-1, 0, -1), -0.45f, new Dielectric(1.5f)));
            
            var world = new Scene(list);
            var rnd = new Random(70);

            for (var i = 0; i < size.Height; i++)
            {
                for (var j = 0; j < size.Width; j++)
                {
                    var col = new Vector3();
                    
                    for(var s=0; s<samples; s++){
                        var u = (float) ( j + rnd.NextDouble()) / (float) size.Width;
                        var v = (float) (size.Height - i -1 + rnd.NextDouble()) / (float) size.Height;
                        var r = cam.GetRay(u, v);
                        col += color(r, world, 0);
                    }
                    col /= samples;
                    col = new Vector3((float) Math.Sqrt(col.X), (float) Math.Sqrt(col.Y), (float) Math.Sqrt(col.Z));
                    img.SetColor(i, j, col);
                }
            }
            
            img.Save("ding");
        }
    }
}
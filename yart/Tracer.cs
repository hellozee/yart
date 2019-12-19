using System;
using System.Numerics;
using System.Drawing;
using System.Drawing.Imaging;

namespace yart
{
    public static class Tracer
    {
        private static Vector3 GetColor(Ray r, IObject world, int depth)
        {
            var rec = new HitRecord();

            if (world.Hit(r, 0.001f, float.MaxValue, ref rec))
            {
                var scattered = new Ray();
                var attenuation = new Vector3();
                if (depth >= 50 || !rec.Mat.Scatter(r, rec, ref attenuation, ref scattered))
                    return Vector3.Zero;
                
                var ret = attenuation * GetColor(scattered, world, depth + 1);
                return ret;
            }

            return Vector3.One/10;
        }

        public static void Render(string fileName, Size size, int samples, Scene world)
        {
            var rnd = new Random();
            var picture = new Bitmap(size.Width, size.Height);

            for (var i = 0; i < size.Height; i++)
            {
                for (var j = 0; j < size.Width; j++)
                {
                    var col = new Vector3();
                    
                    for(var s=0; s<samples; s++){
                        var u = (float) ( j + rnd.NextDouble()) / size.Width;
                        var v = (float) ( i + rnd.NextDouble()) / size.Height;
                        var r = world.GetCamera().GetRay(u, v);
                        col += Tracer.GetColor(r, world, 0);
                    }
                    
                    col /= samples;
                    col = new Vector3((float) Math.Sqrt(col.X), (float) Math.Sqrt(col.Y), (float) Math.Sqrt(col.Z));
                    var red = (int)(col.X * 255.99);
                    var green = (int)(col.Y * 255.99);
                    var blue = (int)(col.Z * 255.99);
                    var c = Color.FromArgb(red, green, blue);
                    picture.SetPixel(j, i, c);
                }
            }
            
            picture.Save(fileName, ImageFormat.Png);
        }
    }
}
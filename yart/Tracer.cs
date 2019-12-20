using System;
using System.Numerics;
using System.Drawing;
using System.Drawing.Imaging;

namespace yart
{
    public class Tracer
    {
        private readonly Vector3 _ambientLight;
        private Vector3 GetColor(Ray r, IObject world, int depth)
        {
            var rec = new HitRecord();

            if (!world.Hit(r, 0.001f, float.MaxValue, ref rec)) return _ambientLight;
            var scattered = new Ray();
            var attenuation = new Vector3();
            var emitted = rec.Mat.Emit(0, 0, rec.Position);
            if (depth < 50 && rec.Mat.Scatter(r, rec, ref attenuation, ref scattered))
                return emitted + attenuation * this.GetColor(scattered, world, depth + 1);

            return emitted;

        }

        public Tracer()
        {
            _ambientLight = Vector3.Zero;
        }
        
        public Tracer(Vector3 ambientLight)
        {
            _ambientLight = ambientLight;
        }
        
        public void Render(string fileName, Size size, int samples, Scene world)
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
                        col += this.GetColor(r, world, 0);
                    }
                    
                    col /= samples;
                    col = new Vector3((float) Math.Sqrt(col.X), (float) Math.Sqrt(col.Y), (float) Math.Sqrt(col.Z));
                    var clamp = new Func<float, float>(val => val > 1.0f ? 1.0f : val < 0.0f ? 0.0f : val);
                    var clampVec3 = new Func<Vector3, Vector3>(vec => new Vector3(clamp(vec.X), clamp(vec.Y), clamp(vec.Z)));
                    col = clampVec3(col);
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
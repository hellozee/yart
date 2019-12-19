using System;
using System.Collections.Generic;
using System.Numerics;
using System.Drawing;
using System.Drawing.Imaging;

namespace yart
{
    internal static class Yart
    {
        public static void Main()
        {
            var size = new Size(640, 360);
            const int samples = 50;
            var cam = new Camera(new Vector3(-2, 2, 1), new Vector3(0, 0, -1),
                new Vector3(0, 1, 0), 50, (float) size.Width/size.Height);
            
            var list = new List<IObject>();
            list.Add(new Sphere(new Vector3(0, 0, -1), 0.5f, new Lambertian(new Vector3(0.8f, 0.3f, 0.3f))));
            list.Add(new Sphere(new Vector3(0, -100.5f, -1), 100, new Lambertian(new Vector3(0.8f, 0.8f, 0))));
            list.Add(new Sphere(new Vector3(1, 0, -1), 0.5f, new Metal(new Vector3(0.8f, 0.6f, 0.2f))));
            list.Add(new Sphere(new Vector3(-1, 0, -1), -0.45f, new Dielectric(1.5f)));
            
            var world = new Scene(list, cam);
            Tracer.Render("ding.png", size, samples, world);
        }
    }
}
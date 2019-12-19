using System.Numerics;
using yart.Objects;

namespace yart
{
    internal static class Yart
    {
        public static void Main()
        {
            var size = new System.Drawing.Size(640, 360);
            const int samples = 50;
            
            var cam = new Camera(new Vector3(0, 0, 5), new Vector3(0, 0, -1),
                new Vector3(0, 1, 0), 50, (float) size.Width/size.Height);
            
            var world = new Scene();
            world.AddObject(new Sphere(new Vector3(0, 0, -1), .5f, new Lambertian(new Vector3(.8f, .3f, .3f))));
            world.AddObject(new Sphere(new Vector3(1, 0, -1), .5f, new Metal(new Vector3(.8f, .6f, .2f))));
            world.AddObject(new Sphere(new Vector3(-1, 0, -1), -.45f, new Dielectric(1.5f)));
            world.AddObject(new Triangle(new Vector3(-0.75f,1,-1), new Vector3(0.5f,1,-0.5f), 
                new Vector3(0.75f,1,-1), Vector3.UnitY, new Lambertian(new Vector3(.4f, .5f, 1.0f))));
            world.SetCamera(cam);
            
            Tracer.Render("ding.png", size, samples, world);
        }
    }
}
namespace yart
{
    class Program
    {
        private static Color color(Ray r)
        {
            var unitVec = r.Direction().Normalize();
            var t = 0.5f * (unitVec.Gety() + 1.0f);
            return new Color((1.0 - t) * new Vec3(1.0f) + 
                             t * new Vec3(0.5, 0.7, 1.0));
        }
        public static void Main(string[] args)
        {
            var size = new Size(1920, 1080);
            var lowerLeft = new Vec3(-2.0, -1.0, -1.0);
            var horizontal = new Vec3(4.0, 0.0, 0.0);
            var vertical = new Vec3(0.0, 2.0, 0.0);
            var origin = new Vec3(0.0, 0.0, 0.0);
            var img = new Image(size);

            for (var i = size.Height - 1; i >= 0; i--)
            {
                for (var j = 0; j < size.Width; j++)
                {
                    var u = (double) j / size.Width;
                    var v = (double) i / size.Height;
                    var r = new Ray(origin, lowerLeft + u*horizontal + v*vertical);
                    var c = color(r);
                    img.SetColor(i, j, c);
                }
            }
            
            img.Save("ding");
        }
    }
}
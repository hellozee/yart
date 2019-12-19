using System;
using System.Numerics;
using System.IO;

namespace yart
{
    public class Size
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return Width + " " + Height;
        }
    }

    public class Image
    {
        private readonly Size _imageSize;
        private Vector3[,] _colorArray;
        
        public Image(Size s)
        {
            _imageSize = s;
            _colorArray = new Vector3[s.Height , s.Width];
        }

        public void Save(string fileName)
        {
            fileName = Path.ChangeExtension(fileName, ".ppm");
            using (var file = new System.IO.StreamWriter(fileName ?? throw new ArgumentNullException(nameof(fileName))))
            {
                file.WriteLine("P3");
                file.WriteLine(_imageSize.ToString());
                file.WriteLine("255");
                foreach (var color in _colorArray)
                {
                    file.WriteLine((int)(color.X * 255.99) + " " + 
                                   (int)(color.Y*255.99) + " " + (int)(color.Z*255.99));
                }
            }
        }
        
        public void SetColor(int x, int y, Vector3 c)
        {
            _colorArray[x, y] = c;
        }
    }
}
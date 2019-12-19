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

    public class Color
    {
        private float _red, _green, _blue;

        public Color()
        {
            _red = _green = _blue = 0;
        }

        public Color(float r, float g, float b)
        {
            _red = Clamp(r);
            _green = Clamp(g);
            _blue = Clamp(b);
        }

        public Color(Vector3 v)
        {
            _red = Clamp(v.X);
            _green = Clamp(v.Y);
            _blue = Clamp(v.Z);
        }

        private static float Clamp(float val)
        {
            return val > 1.0f ? 1.0f : val < 0.0f ? 0.0f : val;
        }

        public float Red()
        {
            return _red;
        }

        public float Green()
        {
            return _green;
        }

        public float Blue()
        {
            return _blue;
        }
        
        public void SetRed(int red)
        {
            _red = Clamp(red);
        }
        
        public void SetGreen(int green)
        {
            _green = Clamp(green);
        }

        public void SetBlue(int blue)
        {
            _blue = Clamp(blue);
        }

        public override string ToString()
        {
            return (int)(_red * 255.99) + " " + (int)(_green*255.99) + " " + (int)(_blue*255.99);
        }
    }
    
    public class Image
    {
        private readonly Size _imageSize;
        private Color[,] _colorArray;
        
        public Image(Size s)
        {
            _imageSize = s;
            _colorArray = new Color[s.Height , s.Width];
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
                    file.WriteLine(color.ToString());
                }
            }
        }

        public Size GetSize()
        {
            return _imageSize;
        }

        public Color GetColor(int x, int y)
        {
            return _colorArray[x, y];
        }

        public void SetColor(int x, int y, Color c)
        {
            _colorArray[x, y] = c;
        }
    }
}
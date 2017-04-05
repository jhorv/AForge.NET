using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace System.Drawing
{
    public struct Rectangle
    {
        readonly SKRectI _skRectI;

        public Rectangle(SKRectI rect)
        {
            _skRectI = rect;
        }

        public Rectangle(int x, int y, int width, int height)
        {
            _skRectI = new SKRectI(x, y, x + width, y + height);
        }

        public int Left => _skRectI.Left;
        public int Top => _skRectI.Top;
        public int Right => _skRectI.Right;
        public int Bottom => _skRectI.Bottom;

        public int X => _skRectI.Left;
        public int Y => _skRectI.Top;

        public int Width => _skRectI.Width;
        public int Height => _skRectI.Height;

        public bool Contains(int x, int y) => _skRectI.Contains(x, y);

        public void Inflate(int width, int height) => _skRectI.Inflate(width, height);

        public void Intersect(Rectangle rect) => _skRectI.Intersect(rect._skRectI);

        public static Rectangle Intersect(Rectangle a, Rectangle b)
        {
            return new Rectangle(SKRectI.Intersect(a._skRectI, b._skRectI));
        }
    }
}

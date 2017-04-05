using System;
using System.Collections.Generic;
using System.Linq;
using SkiaSharp;

namespace System.Drawing
{
    public struct Point
    {
        readonly SKPointI _skPoint;

        public Point(int x, int y)
        {
            _skPoint = new SKPointI(x, y);
        }

        public int X => _skPoint.X;
        public int Y => _skPoint.Y;
    }
}

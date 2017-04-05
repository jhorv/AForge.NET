using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace System.Drawing
{
    public struct Size
    {
        readonly SKSizeI _skSizeI;

        public Size(int width, int height)
        {
            _skSizeI = new SKSizeI(width, height);
        }

        public int Height => _skSizeI.Height;
        public int Width => _skSizeI.Width;
    }
}

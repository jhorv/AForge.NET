using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace SkiaSharp
{
    public static class SKColorTypeExtensions
    {
        public static PixelFormat ToPixelFormat(this SKColorType @this)
        {
            switch (@this)
            {
                case SKColorType.Unknown:
                    return PixelFormat.Undefined;
                case SKColorType.Alpha8:
                    return PixelFormat.Alpha;
                case SKColorType.Rgb565:
                    return PixelFormat.Format16bppRgb565;
                case SKColorType.Argb4444:
                    //return PixelFormat.Format16bppArgb1555;
                    throw new NotSupportedException();
                case SKColorType.Rgba8888:
                    return PixelFormat.Format32bppRgb;
                case SKColorType.Bgra8888:
                    throw new NotSupportedException();
                case SKColorType.Index8:
                    return PixelFormat.Format8bppIndexed;
                case SKColorType.Gray8:
                    return PixelFormat.Alpha;   // TODO - Totally guessing here.
                case SKColorType.RgbaF16:
                    throw new NotSupportedException();
                default:
                    throw new InvalidEnumArgumentException("Unhandled SKColorType", (int)@this, typeof(SKColorType));
            }
        }


    }
}

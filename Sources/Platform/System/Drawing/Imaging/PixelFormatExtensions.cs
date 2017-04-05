using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace System.Drawing.Imaging
{
    public static class PixelFormatExtensions
    {
        public static SKColorType ToSKColorType(this PixelFormat @this)
        {
            switch (@this)
            {
                case PixelFormat.Indexed:
                    throw new NotSupportedException();
                case PixelFormat.Gdi:
                    throw new NotSupportedException();
                case PixelFormat.Alpha:
                    return SKColorType.Alpha8;
                case PixelFormat.PAlpha:
                    throw new NotSupportedException();
                case PixelFormat.Extended:
                    throw new NotSupportedException();
                case PixelFormat.Canonical:
                    throw new NotSupportedException();
                case PixelFormat.Undefined:
                    return SKColorType.Unknown;
                case PixelFormat.Format1bppIndexed:
                    throw new NotSupportedException();
                case PixelFormat.Format4bppIndexed:
                    throw new NotSupportedException();
                case PixelFormat.Format8bppIndexed:
                    return SKColorType.Index8;
                case PixelFormat.Format16bppGrayScale:
                    throw new NotSupportedException();
                case PixelFormat.Format16bppRgb555:
                    throw new NotSupportedException();
                case PixelFormat.Format16bppRgb565:
                    throw new NotSupportedException();
                case PixelFormat.Format16bppArgb1555:
                    throw new NotSupportedException();
                case PixelFormat.Format24bppRgb:
                    throw new NotSupportedException();
                case PixelFormat.Format32bppRgb:
                    return SKColorType.Rgba8888;
                case PixelFormat.Format32bppArgb:
                    throw new NotSupportedException();
                case PixelFormat.Format32bppPArgb:
                    throw new NotSupportedException();
                case PixelFormat.Format48bppRgb:
                    throw new NotSupportedException();
                case PixelFormat.Format64bppArgb:
                    throw new NotSupportedException();
                case PixelFormat.Format64bppPArgb:
                    throw new NotSupportedException();
                case PixelFormat.Max:
                    throw new NotSupportedException();
                default:
                    throw new InvalidEnumArgumentException("Unhandled PixelFormat", (int)@this, typeof(PixelFormat));
            }
        }


    }
}

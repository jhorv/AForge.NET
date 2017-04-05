using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaSharp
{
    public static class SKBitmapExtensions
    {

        public static BitmapData LockBits(this SKBitmap @this, SKRectI region, object ignoredImageLockMode, PixelFormat ignoredPixelFormat)
        {
            @this.LockPixels();
            return new BitmapData()
            {
                Height = @this.Height,
                PixelFormat = @this.Info.ColorType.ToPixelFormat(),
                Scan0 = @this.GetPixels(),
                Stride = @this.RowBytes,
                Width = @this.Width
            };
        }

        public static void UnlockBits(this SKBitmap @this, BitmapData ignoredBitmapData)
        {
        }

        public static PixelFormat GetPixelFormat(this SKBitmap @this)
        {
            return @this.Info.ColorType.ToPixelFormat();
        }

    }
}

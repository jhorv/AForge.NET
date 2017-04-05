using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace System.Drawing
{
    public class Bitmap : SKBitmap
    {
        public Bitmap() : base() { }

        public Bitmap(SKImageInfo info) : base(info) { }

        public Bitmap(SKImageInfo info, int rowBytes) : base(info, rowBytes) { }

        public Bitmap(int width, int height, PixelFormat pixelFormat)
            : base(width, height, pixelFormat.ToSKColorType(), SKAlphaType.Unknown)
        {
        }

        public Bitmap(int width, int height, int stride, PixelFormat pixelFormat, IntPtr imageData)
            : base(new SKImageInfo(width, height, pixelFormat.ToSKColorType()), stride)
        {
            SetPixels(imageData);
        }

        public int HorizontalResolution => 0;
        public int VerticalResolution => 0;

        public ColorPalette Palette
        {
            get => _GetColorPalette();
            set => _SetColorPalette(value);
        }

        public PixelFormat PixelFormat => Info.ColorType.ToPixelFormat();

        public BitmapData LockBits(Rectangle region, object ignoredImageLockMode, PixelFormat ignoredPixelFormat)
        {
            LockPixels();
            return new BitmapData()
            {
                Height = Height,
                PixelFormat = Info.ColorType.ToPixelFormat(),
                Scan0 = GetPixels(),
                Stride = RowBytes,
                Width = Width
            };
        }

        public void UnlockBits(BitmapData ignoredBitmapData)
        {
        }

        public void SetResolution(int horizontalResolution, int verticalResolution)
        {
            throw new NotImplementedException();
        }


        #region Private Methods

        private ColorPalette _GetColorPalette()
        {
            throw new NotImplementedException();
            //int size = -1;

            //int status = SafeNativeMethods.Gdip.GdipGetImagePaletteSize(new HandleRef(this, nativeImage), out size);
            //// "size" is total byte size:
            //// sizeof(ColorPalette) + (pal->Count-1)*sizeof(ARGB)

            //if (status != SafeNativeMethods.Gdip.Ok)
            //{
            //    throw SafeNativeMethods.Gdip.StatusException(status);
            //}

            //ColorPalette palette = new ColorPalette(size);

            //// Memory layout is:
            ////    UINT Flags
            ////    UINT Count
            ////    ARGB Entries[size]

            //IntPtr memory = Marshal.AllocHGlobal(size);

            //status = SafeNativeMethods.Gdip.GdipGetImagePalette(new HandleRef(this, nativeImage), memory, size);

            //try
            //{
            //    if (status != SafeNativeMethods.Gdip.Ok)
            //    {
            //        throw SafeNativeMethods.Gdip.StatusException(status);
            //    }

            //    palette.ConvertFromMemory(memory);
            //}
            //finally
            //{
            //    Marshal.FreeHGlobal(memory);
            //}

            //return palette;
        }

        private void _SetColorPalette(ColorPalette palette)
        {
            throw new NotImplementedException();
            //IntPtr memory = palette.ConvertToMemory();

            //int status = SafeNativeMethods.Gdip.GdipSetImagePalette(new HandleRef(this, nativeImage), memory);

            //if (memory != IntPtr.Zero)
            //{
            //    Marshal.FreeHGlobal(memory);
            //}
            //if (status != SafeNativeMethods.Gdip.Ok)
            //{
            //    throw SafeNativeMethods.Gdip.StatusException(status);
            //}
        }

        #endregion


        public static Bitmap FromStream(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }

        /*
         * Return the pixel size for the specified format (in bits)
         */
        /// <include file='doc\Image.uex' path='docs/doc[@for="Image.GetPixelFormatSize"]/*' />
        /// <devdoc>
        ///    Returns the size of the specified pixel
        ///    format.
        /// </devdoc>
        public static int GetPixelFormatSize(PixelFormat pixfmt)
        {
            return (unchecked((int)pixfmt) >> 8) & 0xFF;
        }
    }
}

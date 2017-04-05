using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Drawing
{
    public abstract class Image
    {
        protected Image() { }


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

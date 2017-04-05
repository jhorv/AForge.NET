using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Drawing.Imaging
{
    public enum ImageLockMode
    {
        /// <include file='doc\ImageLockMode.uex' path='docs/doc[@for="ImageLockMode.ReadOnly"]/*' />
        /// <devdoc>
        ///    <para>
        ///       Specifies the image is read-only.
        ///    </para>
        /// </devdoc>
        ReadOnly = 0x0001,
        /// <include file='doc\ImageLockMode.uex' path='docs/doc[@for="ImageLockMode.WriteOnly"]/*' />
        /// <devdoc>
        ///    <para>
        ///       Specifies the image is
        ///       write-only.
        ///    </para>
        /// </devdoc>
        WriteOnly = 0x0002,
        /// <include file='doc\ImageLockMode.uex' path='docs/doc[@for="ImageLockMode.ReadWrite"]/*' />
        /// <devdoc>
        ///    <para>
        ///       Specifies the image is
        ///       read-write.
        ///    </para>
        /// </devdoc>
        ReadWrite = ReadOnly | WriteOnly,
        /// <include file='doc\ImageLockMode.uex' path='docs/doc[@for="ImageLockMode.UserInputBuffer"]/*' />
        /// <devdoc>
        ///    Indicates the image resides in a user input
        ///    buffer, to which the user controls access.
        /// </devdoc>
        UserInputBuffer = 0x0004,
    }
}

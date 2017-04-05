// AForge Image Processing Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © AForge.NET, 2005-2010
// contacts@aforgenet.com
//

namespace AForge.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Filters' collection to apply to an image in sequence.
    /// </summary>
    /// 
    /// <remarks><para>The class represents collection of filters, which need to be applied
    /// to an image in sequence. Using the class user may specify set of filters, which will
    /// be applied to source image one by one in the order user defines them.</para>
    /// 
    /// <para>The class itself does not define which pixel formats are accepted for the source
    /// image and which pixel formats may be produced by the filter. Format of acceptable source
    /// and possible output is defined by filters, which added to the sequence.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// // create filter, which is binarization sequence
    /// FiltersSequence filter = new FiltersSequence(
    ///     new GrayscaleBT709( ),
    ///     new Threshold( )
    /// );
    /// // apply the filter
    /// Bitmap newImage = filter.Apply( image );
    /// </code>
    /// </remarks>
    /// 
    public class FiltersSequence : /*CollectionBase,*/ IFilter, IList
	{
        readonly List<object> _list = new List<object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FiltersSequence"/> class.
        /// </summary>
        /// 
		public FiltersSequence( ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FiltersSequence"/> class.
        /// </summary>
        /// 
        /// <param name="filters">Sequence of filters to apply.</param>
        /// 
        public FiltersSequence( params IFilter[] filters )
		{
			_list.AddRange( filters );
		}

        /// <summary>
        /// Get filter at the specified index.
        /// </summary>
        /// 
        /// <param name="index">Index of filter to get.</param>
        /// 
        /// <returns>Returns filter at specified index.</returns>
        /// 
		public IFilter this[int index]
		{
			get { return ((IFilter) _list[index]); }
		}

        object IList.this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }

        public bool IsFixedSize => ((IList)_list).IsFixedSize;

        public bool IsReadOnly => ((IList)_list).IsReadOnly;

        public int Count => _list.Count;

        public bool IsSynchronized => ((IList)_list).IsSynchronized;

        public object SyncRoot => ((IList)_list).SyncRoot;

        /// <summary>
        /// Add new filter to the sequence.
        /// </summary>
        /// 
        /// <param name="filter">Filter to add to the sequence.</param>
        /// 
        public void Add( IFilter filter )
		{
			_list.Add( filter );
		}

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Apply filter to an image.
        /// </summary>
        /// 
        /// <param name="image">Source image to apply filter to.</param>
        /// 
        /// <returns>Returns filter's result obtained by applying the filter to
        /// the source image.</returns>
        /// 
        /// <remarks>The method keeps the source image unchanged and returns
        /// the result of image processing filter as new image.</remarks>
        /// 
        /// <exception cref="ApplicationException">No filters were added into the filters' sequence.</exception>
        ///
        public Bitmap Apply( Bitmap image )
		{
            Bitmap dstImage = null;
            // lock source bitmap data
            BitmapData imageData = image.LockBits(
                new Rectangle( 0, 0, image.Width, image.Height ),
                ImageLockMode.ReadOnly, image.PixelFormat );

            try
            {
                // apply the filter
                dstImage = Apply( imageData );
            }
            finally
            {
                // unlock source image
                image.UnlockBits( imageData );
            }

            return dstImage;
		}

        /// <summary>
        /// Apply filter to an image.
        /// </summary>
        /// 
        /// <param name="imageData">Source image to apply filter to.</param>
        /// 
        /// <returns>Returns filter's result obtained by applying the filter to
        /// the source image.</returns>
        /// 
        /// <remarks>The filter accepts bitmap data as input and returns the result
        /// of image processing filter as new image. The source image data are kept
        /// unchanged.</remarks>
        ///
        /// <exception cref="ApplicationException">No filters were added into the filters' sequence.</exception>
        ///
        public Bitmap Apply( BitmapData imageData )
        {
            // to increase performance the method passes execution to the method, which
            // operates with unmanaged images - this saves time, because redundant managed
            // locks/unlocks are eliminated

            // get result as an unmanaged image
            UnmanagedImage dstUnmanagedImage = Apply( new UnmanagedImage( imageData ) );
            // convert unmanaged image to managed
            Bitmap dstImage = dstUnmanagedImage.ToManagedImage( );
            // dispose unmanaged mage
            dstUnmanagedImage.Dispose( );

            return dstImage;
		}

        /// <summary>
        /// Apply filter to an image in unmanaged memory.
        /// </summary>
        /// 
        /// <param name="image">Source image in unmanaged memory to apply filter to.</param>
        /// 
        /// <returns>Returns filter's result obtained by applying the filter to
        /// the source image.</returns>
        /// 
        /// <remarks>The method keeps the source image unchanged and returns
        /// the result of image processing filter as new image.</remarks>
        /// 
        /// <exception cref="ApplicationException">No filters were added into the filters' sequence.</exception>
        ///
        public UnmanagedImage Apply( UnmanagedImage image )
        {
            int n = _list.Count;

            // check for empty sequence
            if ( n == 0 )
                throw new ApplicationException( "No filters in the sequence." );

            UnmanagedImage dstImg = null;
            UnmanagedImage tmpImg = null;

            // apply the first filter
            dstImg = ( (IFilter) _list[0] ).Apply( image );

            // apply other filters
            for ( int i = 1; i < n; i++ )
            {
                tmpImg = dstImg;
                dstImg = ( (IFilter)_list[i] ).Apply( tmpImg );
                tmpImg.Dispose( );
            }

            return dstImg;
        }

        /// <summary>
        /// Apply filter to an image in unmanaged memory.
        /// </summary>
        /// 
        /// <param name="sourceImage">Source image in unmanaged memory to apply filter to.</param>
        /// <param name="destinationImage">Destination image in unmanaged memory to put result into.</param>
        /// 
        /// <remarks><para>The method keeps the source image unchanged and puts result of image processing
        /// into destination image.</para>
        /// 
        /// <para><note>The destination image must have width, height and pixel format as it is expected by
        /// the final filter in the sequence.</note></para>
        /// </remarks>
        /// 
        /// <exception cref="ApplicationException">No filters were added into the filters' sequence.</exception>
        ///
        public void Apply( UnmanagedImage sourceImage, UnmanagedImage destinationImage )
        {
            int n = _list.Count;

            // check for empty sequence
            if ( n == 0 )
                throw new ApplicationException( "No filters in the sequence." );

            if ( n == 1 )
            {
                ( (IFilter)_list[0] ).Apply( sourceImage, destinationImage );
            }
            else
            {
                UnmanagedImage tmpImg1 = null;
                UnmanagedImage tmpImg2 = null;

                // apply the first filter
                tmpImg1 = ( (IFilter)_list[0] ).Apply( sourceImage );

                // apply other filters, except the last one
                n--;
                for ( int i = 1; i < n; i++ )
                {
                    tmpImg2 = tmpImg1;
                    tmpImg1 = ( (IFilter)_list[i] ).Apply( tmpImg2 );
                    tmpImg2.Dispose( );
                }

                ( (IFilter)_list[n] ).Apply( tmpImg1, destinationImage );
            }
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(object value)
        {
            return _list.Contains(value);
        }

        public void CopyTo(Array array, int index)
        {
            _list.CopyTo((object[])array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(object value)
        {
            return _list.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            _list.Insert(index, value);
        }

        public void Remove(object value)
        {
            _list.Remove(value);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
    }
}

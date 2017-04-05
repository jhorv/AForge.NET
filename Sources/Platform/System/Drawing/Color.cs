using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace System.Drawing
{
    public struct Color
    {
        readonly SKColor _skColor;

        public Color(SKColor color)
        {
            _skColor = color;
        }

        public Color(byte red, byte green, byte blue)
        {
            _skColor = new SKColor(red, green, blue);
        }

        public Color(byte alpha, byte red, byte green, byte blue)
        {
            _skColor = new SKColor(red, green, blue, alpha);
        }

        public byte A => _skColor.Alpha;
        public byte R => _skColor.Red;
        public byte G => _skColor.Green;
        public byte B => _skColor.Blue;

        public override bool Equals(object obj)
        {
            if (obj is Color right)
            {
                return _skColor.Equals(right._skColor);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _skColor.GetHashCode();
        }

        public int ToArgb()
        {
            int result =
                _skColor.Alpha << 24 |
                _skColor.Red << 16 |
                _skColor.Green << 8 |
                _skColor.Blue;
            return result;
        }

        public static Color FromArgb(int argb)
        {
            return new Color(
                (byte)((argb & 0xFF000000) >> 24),
                (byte)((argb & 0x00FF0000) >> 16),
                (byte)((argb & 0x0000FF00) >> 8),
                (byte)(argb & 0x000000FF)
                );
        }

        public static Color FromArgb(byte red, byte green, byte blue)
        {
            return new Color(red, green, blue);
        }

        public static Color FromArgb(byte alpha, byte red, byte green, byte blue)
        {
            return new Color(alpha, red, green, blue);
        }

        public static Color FromArgb(int red, int green, int blue)
        {
            return new Color((byte)red, (byte)green, (byte)blue);
        }


        public static readonly Color Black = new Color(SKColors.Black);
        public static readonly Color DarkBlue = new Color(SKColors.DarkBlue);
        public static readonly Color DarkGreen = new Color(SKColors.DarkGreen);
        public static readonly Color DarkCyan = new Color(SKColors.DarkCyan);
        public static readonly Color DarkRed = new Color(SKColors.DarkRed);
        public static readonly Color DarkMagenta = new Color(SKColors.DarkMagenta);
        public static readonly Color DarkKhaki = new Color(SKColors.DarkKhaki);
        public static readonly Color LightGray = new Color(SKColors.LightGray);
        public static readonly Color Gray = new Color(SKColors.Gray);
        public static readonly Color Blue = new Color(SKColors.Blue);
        public static readonly Color Green = new Color(SKColors.Green);
        public static readonly Color Cyan = new Color(SKColors.Cyan);
        public static readonly Color Red = new Color(SKColors.Red);
        public static readonly Color Magenta = new Color(SKColors.Magenta);
        public static readonly Color Yellow = new Color(SKColors.Yellow);
        public static readonly Color White = new Color(SKColors.White);


        //public static bool operator ==(Color left, Color right)
        //{
        //    if (Object.ReferenceEquals(left, right))
        //        return true;
        //    return left._skColor.Equals(right);
        //}

        public static bool operator ==(Color left, Color right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Color left, Color right)
        {
            return !(left == right);
        }

    }
}

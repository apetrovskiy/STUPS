// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.


namespace System.Windows
{
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Point : IFormattable
    {
        internal double _x;
        internal double _y;

        public static bool operator ==(Point point1, Point point2)
        {
            return ((point1.X == point2.X) && (point1.Y == point2.Y));
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1 == point2);
        }

        public static bool Equals(Point point1, Point point2)
        {
            return (point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y));
        }

        public override bool Equals(object o)
        {
            if ((o == null) || !(o is Point))
            {
                return false;
            }
            Point point = (Point)o;
            return Equals(this, point);
        }

        public bool Equals(Point value)
        {
            return Equals(this, value);
        }

        public override int GetHashCode()
        {
            return (this.X.GetHashCode() ^ this.Y.GetHashCode());
        }

        public double X
        {
            get
            {
                return this._x;
            }
            set
            {
                this._x = value;
            }
        }
        public double Y
        {
            get
            {
                return this._y;
            }
            set
            {
                this._y = value;
            }
        }
        public override string ToString()
        {
            return this.ConvertToString(null, null);
        }

        public string ToString(IFormatProvider provider)
        {
            return this.ConvertToString(null, provider);
        }

        string IFormattable.ToString(string format, IFormatProvider provider)
        {
            return this.ConvertToString(format, provider);
        }

        internal string ConvertToString(string format, IFormatProvider provider)
        {
            char numericListSeparator = ',';
            return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}", new object[] { numericListSeparator, this._x, this._y });
        }

        public Point(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        public void Offset(double offsetX, double offsetY)
        {
            this._x += offsetX;
            this._y += offsetY;
        }

        public static explicit operator Size(Point point)
        {
            return new Size(Math.Abs(point._x), Math.Abs(point._y));
        }
    }
}
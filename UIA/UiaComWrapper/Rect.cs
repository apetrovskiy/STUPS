// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.


namespace System.Windows
{
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Rect : IFormattable
    {
        internal double _x;
        internal double _y;
        internal double _width;
        internal double _height;

        private static readonly Rect s_empty = Rect.CreateEmptyRect();

        public static bool operator ==(Rect rect1, Rect rect2)
        {
            return ((((rect1.X == rect2.X) && (rect1.Y == rect2.Y)) && (rect1.Width == rect2.Width)) && (rect1.Height == rect2.Height));
        }

        public static bool operator !=(Rect rect1, Rect rect2)
        {
            return !(rect1 == rect2);
        }

        public static bool Equals(Rect rect1, Rect rect2)
        {
            if (rect1.IsEmpty)
            {
                return rect2.IsEmpty;
            }
            return (((rect1.X.Equals(rect2.X) && rect1.Y.Equals(rect2.Y)) && rect1.Width.Equals(rect2.Width)) && rect1.Height.Equals(rect2.Height));
        }

        public override bool Equals(object o)
        {
            if ((o == null) || !(o is Rect))
            {
                return false;
            }
            Rect rect = (Rect)o;
            return Equals(this, rect);
        }

        public bool Equals(Rect value)
        {
            return Equals(this, value);
        }

        public override int GetHashCode()
        {
            if (this.IsEmpty)
            {
                return 0;
            }
            return (((this.X.GetHashCode() ^ this.Y.GetHashCode()) ^ this.Width.GetHashCode()) ^ this.Height.GetHashCode());
        }

        public Rect(Point location, Size size)
        {
            if (size.IsEmpty)
            {
                this = s_empty;
            }
            else
            {
                this._x = location._x;
                this._y = location._y;
                this._width = size._width;
                this._height = size._height;
            }
        }

        public Rect(double x, double y, double width, double height)
        {
            if ((width < 0.0) || (height < 0.0))
            {
                throw new ArgumentException("Size_WidthAndHeightCannotBeNegative");
            }
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
        }

        public Rect(Point point1, Point point2)
        {
            this._x = Math.Min(point1._x, point2._x);
            this._y = Math.Min(point1._y, point2._y);
            this._width = Math.Max((double)(Math.Max(point1._x, point2._x) - this._x), (double)0.0);
            this._height = Math.Max((double)(Math.Max(point1._y, point2._y) - this._y), (double)0.0);
        }

        public Rect(Size size)
        {
            if (size.IsEmpty)
            {
                this = s_empty;
            }
            else
            {
                this._x = this._y = 0.0;
                this._width = size.Width;
                this._height = size.Height;
            }
        }

        public static Rect Empty
        {
            get
            {
                return s_empty;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return (this._width < 0.0);
            }
        }
        public Point Location
        {
            get
            {
                return new Point(this._x, this._y);
            }
            set
            {
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }
                this._x = value._x;
                this._y = value._y;
            }
        }
        public Size Size
        {
            get
            {
                if (this.IsEmpty)
                {
                    return Size.Empty;
                }
                return new Size(this._width, this._height);
            }
            set
            {
                if (value.IsEmpty)
                {
                    this = s_empty;
                }
                else
                {
                    if (this.IsEmpty)
                    {
                        throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                    }
                    this._width = value._width;
                    this._height = value._height;
                }
            }
        }
        public double X
        {
            get
            {
                return this._x;
            }
            set
            {
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }
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
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }
                this._y = value;
            }
        }
        public double Width
        {
            get
            {
                return this._width;
            }
            set
            {
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }
                if (value < 0.0)
                {
                    throw new ArgumentException("Size_WidthCannotBeNegative");
                }
                this._width = value;
            }
        }
        public double Height
        {
            get
            {
                return this._height;
            }
            set
            {
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }
                if (value < 0.0)
                {
                    throw new ArgumentException("Size_HeightCannotBeNegative");
                }
                this._height = value;
            }
        }
        public double Left
        {
            get
            {
                return this._x;
            }
        }
        public double Top
        {
            get
            {
                return this._y;
            }
        }
        public double Right
        {
            get
            {
                if (this.IsEmpty)
                {
                    return double.NegativeInfinity;
                }
                return (this._x + this._width);
            }
        }
        public double Bottom
        {
            get
            {
                if (this.IsEmpty)
                {
                    return double.NegativeInfinity;
                }
                return (this._y + this._height);
            }
        }
        public Point TopLeft
        {
            get
            {
                return new Point(this.Left, this.Top);
            }
        }
        public Point TopRight
        {
            get
            {
                return new Point(this.Right, this.Top);
            }
        }
        public Point BottomLeft
        {
            get
            {
                return new Point(this.Left, this.Bottom);
            }
        }
        public Point BottomRight
        {
            get
            {
                return new Point(this.Right, this.Bottom);
            }
        }
        public bool Contains(Point point)
        {
            return this.Contains(point._x, point._y);
        }

        public bool Contains(double x, double y)
        {
            if (this.IsEmpty)
            {
                return false;
            }
            return this.ContainsInternal(x, y);
        }

        public bool Contains(Rect rect)
        {
            if (this.IsEmpty || rect.IsEmpty)
            {
                return false;
            }
            return ((((this._x <= rect._x) && (this._y <= rect._y)) && ((this._x + this._width) >= (rect._x + rect._width))) && ((this._y + this._height) >= (rect._y + rect._height)));
        }

        public bool IntersectsWith(Rect rect)
        {
            if (this.IsEmpty || rect.IsEmpty)
            {
                return false;
            }
            return ((((rect.Left <= this.Right) && (rect.Right >= this.Left)) && (rect.Top <= this.Bottom)) && (rect.Bottom >= this.Top));
        }

        public void Intersect(Rect rect)
        {
            if (!this.IntersectsWith(rect))
            {
                this = Empty;
            }
            else
            {
                double num2 = Math.Max(this.Left, rect.Left);
                double num = Math.Max(this.Top, rect.Top);
                this._width = Math.Max((double)(Math.Min(this.Right, rect.Right) - num2), (double)0.0);
                this._height = Math.Max((double)(Math.Min(this.Bottom, rect.Bottom) - num), (double)0.0);
                this._x = num2;
                this._y = num;
            }
        }

        public static Rect Intersect(Rect rect1, Rect rect2)
        {
            rect1.Intersect(rect2);
            return rect1;
        }

        public void Union(Rect rect)
        {
            if (this.IsEmpty)
            {
                this = rect;
            }
            else if (!rect.IsEmpty)
            {
                double num2 = Math.Min(this.Left, rect.Left);
                double num = Math.Min(this.Top, rect.Top);
                if ((rect.Width == double.PositiveInfinity) || (this.Width == double.PositiveInfinity))
                {
                    this._width = double.PositiveInfinity;
                }
                else
                {
                    double num4 = Math.Max(this.Right, rect.Right);
                    this._width = Math.Max((double)(num4 - num2), (double)0.0);
                }
                if ((rect.Height == double.PositiveInfinity) || (this.Height == double.PositiveInfinity))
                {
                    this._height = double.PositiveInfinity;
                }
                else
                {
                    double num3 = Math.Max(this.Bottom, rect.Bottom);
                    this._height = Math.Max((double)(num3 - num), (double)0.0);
                }
                this._x = num2;
                this._y = num;
            }
        }

        public static Rect Union(Rect rect1, Rect rect2)
        {
            rect1.Union(rect2);
            return rect1;
        }

        public void Union(Point point)
        {
            this.Union(new Rect(point, point));
        }

        public static Rect Union(Rect rect, Point point)
        {
            rect.Union(new Rect(point, point));
            return rect;
        }

        public void Offset(double offsetX, double offsetY)
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Rect_CannotCallMethod");
            }
            this._x += offsetX;
            this._y += offsetY;
        }

        public static Rect Offset(Rect rect, double offsetX, double offsetY)
        {
            rect.Offset(offsetX, offsetY);
            return rect;
        }

        public void Inflate(Size size)
        {
            this.Inflate(size._width, size._height);
        }

        public void Inflate(double width, double height)
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Rect_CannotCallMethod");
            }
            this._x -= width;
            this._y -= height;
            this._width += width;
            this._width += width;
            this._height += height;
            this._height += height;
            if ((this._width < 0.0) || (this._height < 0.0))
            {
                this = s_empty;
            }
        }

        public static Rect Inflate(Rect rect, Size size)
        {
            rect.Inflate(size._width, size._height);
            return rect;
        }

        public static Rect Inflate(Rect rect, double width, double height)
        {
            rect.Inflate(width, height);
            return rect;
        }

        public void Scale(double scaleX, double scaleY)
        {
            if (!this.IsEmpty)
            {
                this._x *= scaleX;
                this._y *= scaleY;
                this._width *= scaleX;
                this._height *= scaleY;
                if (scaleX < 0.0)
                {
                    this._x += this._width;
                    this._width *= -1.0;
                }
                if (scaleY < 0.0)
                {
                    this._y += this._height;
                    this._height *= -1.0;
                }
            }
        }

        private bool ContainsInternal(double x, double y)
        {
            return ((((x >= this._x) && ((x - this._width) <= this._x)) && (y >= this._y)) && ((y - this._height) <= this._y));
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
            if (IsEmpty)
            {
                return "Empty";
            }

            char numericListSeparator = ',';
            return String.Format(provider,
                                 "{1:" + format + "}{0}{2:" + format + "}{0}{3:" + format + "}{0}{4:" + format + "}",
                                 numericListSeparator,
                                 _x,
                                 _y,
                                 _width,
                                 _height);
        }

        private static Rect CreateEmptyRect()
        {
            Rect rect = new Rect();
            rect._x = double.PositiveInfinity;
            rect._y = double.PositiveInfinity;
            rect._width = double.NegativeInfinity;
            rect._height = double.NegativeInfinity;
            return rect;
        }
    }
}
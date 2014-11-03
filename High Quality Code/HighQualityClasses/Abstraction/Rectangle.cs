namespace Abstraction
{
    using System;

    /// <summary>
    ///     Class that represent rectangle shape
    /// </summary>
    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height can not be negative number or 0.");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width can not be negative number or 0.");
                }

                this.width = value;
            }
        }

        /// <summary>
        ///     Calculate perimeter of rectangle
        /// </summary>
        /// <returns>Calculated rectangle perimeter</returns>
        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        /// <summary>
        ///     Calculate surface of rectangle
        /// </summary>
        /// <returns>Calculated rectangle surface</returns>
        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}

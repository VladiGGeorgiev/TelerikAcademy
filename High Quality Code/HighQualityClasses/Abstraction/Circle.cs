namespace Abstraction
{
    using System;

    /// <summary>
    ///     Class that represent Circle shape
    /// </summary>
    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius 
        { 
            get
            {
                return this.radius;
            }

            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius can not be negative number or 0!");
                }

                this.radius = value;
            } 
        }

        /// <summary>
        ///     Calculate surface of circle
        /// </summary>
        /// <returns>Calculated rectangle circle</returns>
        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        /// <summary>
        ///     Calculate surface of circle
        /// </summary>
        /// <returns>Calculated circle surface</returns>
        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}

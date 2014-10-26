namespace GeometricFigures
{
    using System;

    public class Circle : Shape
    {
        public Circle(double radius) : base(radius, radius)
        {
        }
         
        public override double CalculateSurface()
        {
            double surface = this.height * this.height * Math.PI;
            return surface;
        }
    }
}

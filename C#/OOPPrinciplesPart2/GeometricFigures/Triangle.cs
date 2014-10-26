namespace GeometricFigures
{
    public class Triangle : Shape
    {
        public Triangle(double width, double height)
            : base(width, height)
        { }

        public override double CalculateSurface()
        {
            double surface = (this.height * this.width) / 2;
            return surface;
        }
    }
}

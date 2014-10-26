namespace GeometricFigures
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height) : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            double surface = this.height * this.width;
            return surface;
        }
    }
}

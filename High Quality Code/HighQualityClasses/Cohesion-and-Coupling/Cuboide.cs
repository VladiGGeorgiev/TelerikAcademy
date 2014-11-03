namespace CohesionAndCoupling
{
    using System;

    public class Cuboide
    {
        public Cuboide(double width, double height, double depth)
        {
            if (width <= 0 || height <= 0 || depth <= 0)
            {
                throw new ArgumentException("Dimensions must be greater than 0!");
            }

            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Depth { get; set; }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = GeometryUtils.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}

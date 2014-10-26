namespace GeometricFigures
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Circle(5));
            shapes.Add(new Rectangle(4, 8));
            shapes.Add(new Triangle(3, 9));

            foreach (var shape in shapes)
            {
                Console.WriteLine("Surface is: " + shape.CalculateSurface());
            }
        }
    }
}

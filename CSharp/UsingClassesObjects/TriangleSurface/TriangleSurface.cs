/*Write methods that calculate the surface of a triangle by given:
Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.
*/

namespace TriangleSurface
{
    using System;

    public class TriangleSurface
    {
        public static void Main()
        {
            double a = 4;
            double b = 5;
            double c = 2;
            double ha = 3;
            short angle = 90;

            Console.WriteLine(FindTriangleSurface(a, b, c));
            Console.WriteLine(FindTriangleSurface(a, ha));
            Console.WriteLine(FindTriangleSurface(a, b, angle));
        }

        private static double FindTriangleSurface(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double surface = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return surface;
        }

        private static double FindTriangleSurface(double a, double ha)
        {
            double surface = (a * ha) / 2;
            return surface;
        }

        private static double FindTriangleSurface(double a, double b, short angle)
        {
            double surface = (b * a * Math.Sin(angle)) / 2;
            return surface;
        }
    }
}

namespace Methods
{
    using System;

    /// <summary>
    ///     Methods that calculates some geometry values
    /// </summary>
    public static class Geometry
    {
        /// <summary>
        ///     Calculate area of triangle with three sides lengths.
        /// </summary>
        /// <param name="a">Length of side 'a'</param>
        /// <param name="b">Length of side 'b'</param>
        /// <param name="c">Length of side 'c'</param>
        /// <returns>Area of triangle</returns>
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double semiParameter = (a + b + c) / 2;
            double triangleArea = Math.Sqrt(semiParameter * (semiParameter - a) * (semiParameter - b) * (semiParameter - c));

            return triangleArea;
        }

        /// <summary>
        ///     Calculate distance between two points with X and Y coordinates.
        /// </summary>
        /// <param name="x1">X coordinate of first point</param>
        /// <param name="y1">Y coordinate of first point</param>
        /// <param name="x2">X coordinate of second point</param>
        /// <param name="y2">Y coordinate of second point</param>
        /// <returns>Distance between points</returns>
        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        /// <summary>
        ///     Return is line horizontal.
        /// </summary>
        /// <param name="x1">X coordinate of first point</param>
        /// <param name="y1">Y coordinate of first point</param>
        /// <param name="x2">X coordinate of second point</param>
        /// <param name="y2">Y coordinate of second point</param>
        /// <returns>Is line horizontal</returns>
        public static bool IsLineHorizontal(double x1, double y1, double x2, double y2)
        { 
            bool isHorizontal = y1 == y2;
            return isHorizontal;
        }

        /// <summary>
        ///     Return is line vertical.
        /// </summary>
        /// <param name="x1">X coordinate of first point</param>
        /// <param name="y1">Y coordinate of first point</param>
        /// <param name="x2">X coordinate of second point</param>
        /// <param name="y2">Y coordinate of second point</param>
        /// <returns>Is line vertical</returns>
        public static bool IsLineVertical(double x1, double y1, double x2, double y2)
        {
            bool isVertical = x1 == x2;
            return isVertical;
        }
    }
}

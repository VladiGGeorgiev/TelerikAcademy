namespace CohesionAndCoupling
{
    using System;

    public class GeometryUtils
    {
        /// <summary>
        ///     Calculate distance between 2 points in 2D space.
        /// </summary>
        /// <param name="x1">X coordinate of first point</param>
        /// <param name="y1">Y coordinate of first point</param>
        /// <param name="x2">X coordinate of second point</param>
        /// <param name="y2">T coordinate of second point</param>
        /// <returns>Distance between points</returns>
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        /// <summary>
        ///     Calculate distance between two points in 3D space
        /// </summary>
        /// <param name="x1">X coordinate of first point</param>
        /// <param name="y1">Y coordinate of first point</param>
        /// <param name="z1">Z coordinate of first point</param>
        /// <param name="x2">X coordinate of second point</param>
        /// <param name="y2">Y coordinate of second point</param>
        /// <param name="z2">Z coordinate of second point</param>
        /// <returns>Distance between points</returns>
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }
    }
}

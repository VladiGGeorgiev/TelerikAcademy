namespace Point
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        private static readonly List<Point3D> points = new List<Point3D>();

        public static List<Point3D> Points
        {
            get { return Path.points; }
        } 

        public static void AddPoint(Point3D point)
        {
            points.Add(point);
        }
    }
}

namespace Point
{
    using System;

    public struct Point3D
    {
        private static Point3D startPoint = new Point3D(0, 0, 0);
        private int x;
        private int y;
        private int z;

        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point3D StartPoint
        {
            get { return startPoint; }
        }

        public int X 
        {
            get { return this.x; }
        }

        public int Y
        {
            get { return this.y; }
        }

        public int Z
        {
            get { return this.z; }
        }

        public override string ToString()
        {
            string result = string.Empty;
            result += "X = " + this.x + "\n";
            result += "Y = " + this.y + "\n";
            result += "Z = " + this.z;

            return result;
        }
    }
}

namespace Point
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        public static void SavePaths(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < Path.Points.Count; i++)
                {
                    writer.WriteLine(Path.Points[i]);
                    writer.WriteLine();
                }
            }
        }

        public static string LoadPaths(string path) 
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string allPoints = allPoints = reader.ReadToEnd();

                return allPoints;
            }
        }
    }
}

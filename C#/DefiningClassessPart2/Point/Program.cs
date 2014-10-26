namespace Point
{
    using System;

    [Version(1.5)]
    class Program
    {
        static void Main(string[] args)
        {
            Point3D myPoint = new Point3D(1, 2, 3);
            Path.AddPoint(myPoint);
            Path.AddPoint(new Point3D(2, 3, 7));
            Path.AddPoint(new Point3D(9, 2, 2));
            Path.AddPoint(new Point3D(2, 7, 1));

            PathStorage.SavePaths("../../text.txt");
            Console.WriteLine(PathStorage.LoadPaths("../../text.txt"));

            GenericList<int> array = new GenericList<int>(10);

            array.Add(4);
            array.Add(6);
            array.Add(8);
            array.Add(3);
            array.Add(7);
            array.Add(1);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            Console.WriteLine();
            array.Remove(2);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]); 
            }

            Console.WriteLine(new string('-', 20));

            Console.WriteLine("Max element is: " + array.Max());
            Console.WriteLine(new string('-', 20));

            Type type = typeof(Program);
            
            object[] allAttibutes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attribute in allAttibutes)
            {
                Console.WriteLine("Version is: " + attribute.Value);
            }
        }
    }
}

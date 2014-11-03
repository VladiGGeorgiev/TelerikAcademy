namespace Methods
{
    using System;

    /// <summary>
    ///     Demo class that test all methods in project.
    /// </summary>
    public class MethodsDemo
    {
        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
            Console.WriteLine(Geometry.CalculateTriangleArea(3, 4, 5));
            Console.WriteLine(Geometry.CalcDistance(3, -1, 3, 2.5));

            Console.WriteLine(Numbers.ConvertDigitToText(5));
            Console.WriteLine(Numbers.MaxElement(5, -1, 3, 2, 14, 2, 3));

            Numbers.PrintNumberWithPrecisionTwo(29);
            Numbers.PrintNumberWithAlignment(29);
            Numbers.PrintNumberAsPercent(29);

            var isLineHorizontal = Geometry.IsLineHorizontal(3, 5, 1, 2);
            var isLineVertical = Geometry.IsLineVertical(3, 5, 1, 2);
            Console.WriteLine("Horizontal? " + isLineHorizontal);
            Console.WriteLine("Vertical? " + isLineVertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = new PersonalInfo(new DateTime(1992, 3, 17), "Sofia");

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = new PersonalInfo(new DateTime(1993, 11, 03), "Vidin", "gamer");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}

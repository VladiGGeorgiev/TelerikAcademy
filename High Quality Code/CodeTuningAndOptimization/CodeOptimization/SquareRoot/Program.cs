namespace SquareRoot
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();

            Console.WriteLine(Environment.NewLine + "Square root:");
            #region Square root
            watch.Start();
            for (float i = 0; i < 100000; i++)
            {
                Math.Sqrt(i);
            }

            watch.Stop();
            Console.WriteLine("float: " + watch.Elapsed);
            watch.Reset();

            watch.Start();
            for (double i = 0; i < 100000; i++)
            {
                Math.Sqrt(i);
            }

            watch.Stop();
            Console.WriteLine("Double: " + watch.Elapsed);
            watch.Reset();

            watch.Start();
            for (decimal i = 0; i < 100000; i++)
            {
                Math.Sqrt((double)i);
            }

            watch.Stop();
            Console.WriteLine("decimal: " + watch.Elapsed);
            watch.Reset();
            #endregion

            #region Sinus
            Console.WriteLine(Environment.NewLine + "Sinus:");
            watch.Start();
            for (float i = 0; i < 100000; i++)
            {
                Math.Sin(i);
            }

            watch.Stop();
            Console.WriteLine("float: " + watch.Elapsed);
            watch.Reset();

            watch.Start();
            for (double i = 0; i < 100000; i++)
            {
                Math.Sin(i);
            }

            watch.Stop();
            Console.WriteLine("Double: " + watch.Elapsed);
            watch.Reset();

            watch.Start();
            for (decimal i = 0; i < 100000; i++)
            {
                Math.Sin((double)i);
            }

            watch.Stop();
            Console.WriteLine("decimal: " + watch.Elapsed);
            watch.Reset();
            #endregion

            #region Logarithm
            Console.WriteLine(Environment.NewLine + "Logarithm:");
            watch.Start();
            for (float i = 0; i < 100000; i++)
            {
                Math.Log(i);
            }

            watch.Stop();
            Console.WriteLine("float: " + watch.Elapsed);
            watch.Reset();

            watch.Start();
            for (double i = 0; i < 100000; i++)
            {
                Math.Log(i);
            }

            watch.Stop();
            Console.WriteLine("Double: " + watch.Elapsed);
            watch.Reset();

            watch.Start();
            for (decimal i = 0; i < 100000; i++)
            {
                Math.Log((double)i);
            }

            watch.Stop();
            Console.WriteLine("decimal: " + watch.Elapsed);
            watch.Reset();
            #endregion
        }
    }
}

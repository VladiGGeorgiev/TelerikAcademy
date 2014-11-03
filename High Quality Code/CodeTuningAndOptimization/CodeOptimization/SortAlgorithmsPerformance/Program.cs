namespace SortAlgorithmsPerformance
{
    using System;
    using System.Diagnostics;

    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            var array = new int[20000];
            for (int i = 0; i < array.Length; i++)
			{
			    array[i] = rand.Next(0, 1000);
			}


            Stopwatch sw = new Stopwatch();
            sw.Start();
            Sort.QuickSort(array);
            sw.Stop();
            Console.WriteLine("Quick sort: " + sw.Elapsed);

            sw.Start();
            Sort.InsertionSort(array);
            sw.Stop();
            Console.WriteLine("InsertionSort: " + sw.Elapsed);

            sw.Start();
            Sort.Selection(array);
            sw.Stop();
            Console.WriteLine("Selection: " + sw.Elapsed);
        }
    }
}

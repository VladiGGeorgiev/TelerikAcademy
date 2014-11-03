using System;
using System.Text;
using Wintellect.PowerCollections;

namespace ReadLargeProductsCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedBag<Product> bag = new OrderedBag<Product>();

            for (int i = 0; i < 500000; i++)
            {
                bag.Add(new Product("Pesho" + i, (i + 10) / (decimal)3));
            }

            var range = bag.Range(
                new Product("pesho", 1000), true, 
                new Product("GOsho", 4333), true);
            

            StringBuilder sb = new StringBuilder();
            foreach (var item in range)
            {
                sb.AppendLine(item.ToString());
            }
            Console.WriteLine(sb);
            Console.WriteLine("Number of results: " + range.Count);
        }
    }
}

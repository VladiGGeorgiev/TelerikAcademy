using System;

namespace BiDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            BiDictionary<string, int, string> collection = new BiDictionary<string, int, string>();
            collection.Add("Pesho", 1, "Zagorka");
            collection.Add("Mincho", 2, "Astika");
            collection.Add("Minka", 2, "Grozde");
            collection.Add("Gosho", 1, "Heineken");
            collection.Add("Pesho", 3, "HB");
            collection.Add("Doncho", 1, "Dubel");

            var find = collection.FindBySecondKey(1);
            foreach (var item in find)
            {
                Console.WriteLine(item);
            }
        }
    }
}

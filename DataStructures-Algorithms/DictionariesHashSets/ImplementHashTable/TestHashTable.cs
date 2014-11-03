using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementHashTable
{
    class TestHashTable
    {
        static void Main(string[] args)
        {
            HashTable<string, int> table = new HashTable<string, int>();

            table.Add("Pesho", 5);
            table.Add("Misho", 6);
            table.Add("Gosho", 4);
            table.Add("Acho", 3);
            table.Remove("Pesho");
            table["Pisch"] = 5;

            foreach (var item in table)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}

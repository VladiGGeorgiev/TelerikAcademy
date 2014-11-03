using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableSample
{
    class Sample
    {
        static void Main(string[] args)
        {
            HashTable<int, string> table = new HashTable<int, string>();

            for (int i = 0; i < 17; i++)
            {
                table.Add(i, (i + 1).ToString());
            }

            Console.WriteLine(table[15]);

            table.Clear();

            for (int i = 0; i < 3000; i++)
            {
                table.Add(i, (i + 1).ToString());
            }

            Console.WriteLine(table[1456]);
        }
    }
}

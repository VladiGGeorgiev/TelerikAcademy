using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayOfStrings
{
    class SortArrayOfStrings
    {
        private class NamesComparer:IComparer<string>
        { 
            public int Compare(string x, string y)
            {
                return (x.Length).CompareTo(y.Length);
            }
        }

        static void Main(string[] args)
        {
            string[] array = { "Pesho", "Angel", "Osmancho", "Margarita", "Stavri", "Stoqn", "Gosho", "Mitko", "Bibka", "Suzi" };

            Array.Sort(array, new NamesComparer());
            //Array.Sort(array, (x, y) => x.Length.CompareTo(y.Length));

            Console.WriteLine(string.Join(", ", array));
        }
    }
}

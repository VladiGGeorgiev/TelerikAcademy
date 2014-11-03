using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementHashSet
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("Pesho");
            set.Add("Misho");
            set.Add("Gosho");
            set.Add("Acho");
            set.Remove("Pesho");
                        
            Console.WriteLine();
        }
    }
}

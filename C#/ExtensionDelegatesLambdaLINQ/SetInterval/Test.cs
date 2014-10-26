using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SetInterval
{
    internal class Test
    {
        public static void PrintName(string name)
        {
            Console.WriteLine("Name: {0}", name);
        }

        internal static void Main(string[] args)
        {
            Timer pesho = new Timer(300);
            pesho.Run();
        }
    }
}
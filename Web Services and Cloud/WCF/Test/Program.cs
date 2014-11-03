using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ServiceReference;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DayOfWeekServiceClient client = new DayOfWeekServiceClient();
            string day = client.GetDay(DateTime.Now);
            Console.WriteLine(day);
        }
    }
}

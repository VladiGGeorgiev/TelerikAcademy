using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEntity.Data;
using System.Data.Linq;

namespace InheritingEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwndEntities context = new NorthwndEntities();
            foreach (var item in context.Employees)
            {
                Console.WriteLine(item.Teritories.First());
            }
        }
    }
}

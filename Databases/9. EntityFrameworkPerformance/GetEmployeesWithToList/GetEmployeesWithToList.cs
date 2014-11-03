using System;
using System.Collections.Generic;
using System.Linq;
using TelerikAcademy.Data;

namespace GetEmployeesWithToList
{
    class GetEmployeesWithToList
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();
            SlowQuery(context);
            //FastQuery(context);
        }
  
        private static void SlowQuery(TelerikAcademyEntities context)
        {
            using (context)
            {
                List<Town> towns = context.Employees
                                          .ToList()
                                          .Select(x => x.Address)
                                          .ToList()
                                          .Select(x => x.Town)
                                          .ToList()
                                          .Where(x => x.Name == "Sofia")
                                          .ToList();

                foreach (var town in towns)
                {
                    Console.WriteLine("Name: {0}", town.Name);
                }
            }
        }

        private static void FastQuery(TelerikAcademyEntities context)
        {
            using (context)
            {
                List<Town> towns = context.Employees                                          
                                          .Select(x => x.Address)
                                          .Select(x => x.Town)
                                          .Where(x => x.Name == "Sofia")
                                          .ToList();

                foreach (var town in towns)
                {
                    Console.WriteLine("Name: {0}", town.Name);
                }
            }
        }
    }
}

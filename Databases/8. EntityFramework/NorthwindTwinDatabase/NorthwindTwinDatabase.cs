using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTwinDatabase
{
    class NorthwindTwinDatabase
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\..\NorthwindEntity.Data\Northwind.edmx.sql");
            string query = string.Empty;
            using (reader)
            {
                query = reader.ReadToEnd();
            }

            Console.WriteLine(query);
        }
    }
}

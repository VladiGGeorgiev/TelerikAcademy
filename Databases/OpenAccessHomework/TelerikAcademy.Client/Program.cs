
//------------FOR Task 1 see Frameworks.cs and NorthWind.Data---------------------------------
//------------FOR Task 2 and Task 3 see TelerikAcademy.Client and TelerikAcademy.Data---------
//------------FOR Task 4 and Task 5 see the apropriate projects-------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.Data;
using Telerik.OpenAccess;
using System.Diagnostics;

namespace TelerikAcademy.Client
{
    class Program
    {
        static void Main()
        {
            //DeleteComparer dc = new DeleteComparer();

            ////-------first add 100 000  rows in the table
            //dc.Insert100000EntitiesInDB();

            //Stopwatch sw = new Stopwatch();

            //sw.Start();
            //dc.BulkDelete();
            //sw.Stop();
            //Console.WriteLine("Bulk delete time: " + sw.Elapsed);

            ////----------------Bulk delete result:  
            ////----------------PROFILER: 26 rows; 
            ////----------------TIME: 00.00.04.6631869
            
            //sw.Reset();

            ////------ add again 100 000  rows in the table
            //dc.Insert100000EntitiesInDB();


            //sw.Start();
            //dc.NormalDelete();
            //sw.Stop();
            //Console.WriteLine("Normal delete time: " + sw.Elapsed);

            ////----------------Normal delete result:  
            ////----------------PROFILER: 3356 rows; 
            ////----------------TIME: 00.00.07.0632293


            Serializator serializator = new Serializator();
            serializator.SerializeDeserialize("Guy");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEntity.Data;

namespace OpenTwoContexts
{
    /// <summary>
    /// Try to open two different data contexts and perform concurrent changes on the same records. 
    /// What will happen at SaveChanges()? How to deal with it?
    /// </summary>
    class OpenTwoContexts
    {
        static void Main(string[] args)
        {
            NorthwndEntities context = new NorthwndEntities();
            NorthwndEntities context2 = new NorthwndEntities();

            //One time the the city of customer is Sofia,  one time is Kaspichan! This is not correct!
            using (context)
            {
                using (context2)
                {
                    Customer customer1 = context.Customers.Find("BLAUS");
                    Customer customer2 = context2.Customers.Find("BLAUS");

                    customer1.City = "Sofia";
                    customer2.City = "Kaspichan";

                    context2.SaveChanges();
                    context.SaveChanges();
                }
            }
        }
    }
}

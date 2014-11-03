using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEntity.Data;
using System.Collections;


namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                CustomerID = "MINIV",
                Address = "Student city",
                City = "Sofia",
                CompanyName = "Telerik",
                ContactName = "Minka Ivanova",
                ContactTitle = "Owner",
                Country = "Bulgaria",
                Phone = "0711-020364",
                PostalCode = "51104"
            };

            DAO.UpdateCustomer(new Customer { CustomerID = "WOLZA" }, customer);
            
            //3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada
            FindCustomers("Canada", 1997);
            Console.WriteLine();
            
            //4. Implement previous by using native SQL query and executing it through the DbContext
            FindCustomersSqlQuery("Canada", 1997);

            //5. Write a method that finds all the sales by specified region and period (start / end dates).
            Console.WriteLine(Environment.NewLine + "Orders:");
            FindSalesByRegionAndPeriod("SP", new DateTime(1997, 6, 25), new DateTime(1998, 6, 25));
        }

        /// <summary>
        ///     3.Write a method that finds all customers who have 
        ///     orders made in 1997 and shipped to Canada.
        /// </summary>
        static void FindCustomers(string country, int year)
        {
            NorthwndEntities context = new NorthwndEntities();
            using (context)
            {
                var customers =
                    context.Customers.Join(context.Orders,
                    (c => c.CustomerID),
                    (o => o.CustomerID),
                    (c, o) => new
                    {
                        Customer = c.ContactName,
                        ShipCountry = o.ShipCountry,
                        OrderDate = o.OrderDate
                    }).Where(o => o.ShipCountry == country && o.OrderDate.Value.Year == year);

                //var customers =
                //    from customer in context.Customers
                //    join order in context.Orders
                //    on customer.CustomerID equals order.CustomerID
                //    where order.ShipCountry == country && order.OrderDate.Value.Year == year
                //    select customer.ContactName;
                    

                foreach (var customer in customers)
                {
                    Console.WriteLine("Name: {0}", customer.Customer);		 
                }
            }
        }

        /// <summary>
        ///     4.Implement previous by using native SQL query 
        ///     and executing it through the DbContext.
        /// </summary>
        static void FindCustomersSqlQuery(string country, int year)
        {
            NorthwndEntities context = new NorthwndEntities();

            using (context)
            {
                string query = 
                    "SELECT ContactName FROM Customers c " + 
                    "JOIN Orders o ON c.CustomerId = o.CustomerId " +
                    "WHERE o.ShipCountry = {0} AND YEAR(o.OrderDate) = {1}";
                object[] parameters = { country, year };
                var customers = context.Database.SqlQuery<string>(query, parameters);

                foreach (var customer in customers)
                {
                    Console.WriteLine("Name: {0}", customer);	
                }
            }
        }

        /// <summary>
        ///     Write a method that finds all the sales by specified region 
        ///     and period (start / end dates).
        /// </summary>
        static void FindSalesByRegionAndPeriod(string region, DateTime startDate, DateTime endDate)
        {
            NorthwndEntities context = new NorthwndEntities();
            using (context)
            {
                var orders = context.Orders
                    .Where(x => x.ShipRegion == region && x.OrderDate > startDate && x.OrderDate < endDate)
                    .Select(x => x.ShipName);

                foreach (var order in orders)
                {
                    Console.WriteLine(order);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.Data;

namespace AllEmployees
{
    /// <summary>
    /// Using Entity Framework write a SQL query to select all employees from the Telerik Academy database
    /// and later print their name, department and town. Try the both variants: with and without .
    /// Include(…). Compare the number of executed SQL statements and the performance.
    /// </summary>
    class AllEmployees
    {     
        static void Main(string[] args)
        {
            var context = new TelerikAcademyEntities();

            //Makes 342 queries
            GetEmployeesWithoutInclude(context);

            //Makes 36 queries
            GetEmployeesWithInclude(context);

            //Makes 1 query
            GetEmployeesWithExtraInclude(context);
        }

        /// <summary>
        ///     With this include the EF makes 342 query
        /// </summary>
        /// <param name="context">Telerik Academy DBContext</param>
        private static void GetEmployeesWithoutInclude(TelerikAcademyEntities context)
        {
            using (context)
            {
                foreach (var employee in context.Employees)
                {
                    string fullName = employee.FirstName + " " + employee.LastName;
                    string department = employee.Department.Name;
                    string town = employee.Address.Town.Name;

                    Console.WriteLine("Name: {0}, Department: {1}, Town: {2}", fullName, department, town);
                }
            }
        }

        /// <summary>
        ///     With this include the EF makes 36 query
        /// </summary>
        /// <param name="context">Telerik Academy DBContext</param>
        private static void GetEmployeesWithInclude(TelerikAcademyEntities context)
        {
            using (context)
            {
                foreach (var employee in context.Employees
                    .Include("Department").Include("Address"))
                {
                    string fullName = employee.FirstName + " " + employee.LastName;
                    string department = employee.Department.Name;
                    string town = employee.Address.Town.Name;

                    Console.WriteLine("Name: {0}, Department: {1}, Town: {2}", fullName, department, town);
                }
            }
        }

        /// <summary>
        ///     With this include the EF makes 1 query
        /// </summary>
        /// <param name="context">Telerik Academy DBContext</param>
        private static void GetEmployeesWithExtraInclude(TelerikAcademyEntities context)
        {
            using (context)
            {
                foreach (var employee in context.Employees
                    .Include("Department").Include("Address.Town"))
                {
                    string fullName = employee.FirstName + " " + employee.LastName;
                    string department = employee.Department.Name;
                    string town = employee.Address.Town.Name;

                    Console.WriteLine("Name: {0}, Department: {1}, Town: {2}", fullName, department, town);
                }
            }
        }
    }
}

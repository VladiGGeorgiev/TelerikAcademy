using System;
using System.Collections.Generic;

namespace Algo_Graphs_Salaries
{
    class Program
    {
        static HashSet<int> visitedEmplyees = new HashSet<int>();
        static void Main(string[] args)
        {
            int employeeCount = int.Parse(Console.ReadLine());
            
            //Initialize employees
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
            for (int i = 0; i < employeeCount; i++)
            {
                employees.Add(i, new Employee(i));
            }

            //Make employees connections
            for (int i = 0; i < employeeCount; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                    {
                        employees[i].AddSubordinate(employees[j]);
                    }
                }
            }

            long allSalaries = 0;
            foreach (var employee in employees)
            {
                CalculateSalary(employee.Value);
                allSalaries += employee.Value.Salary;
            }
            Console.WriteLine(allSalaries);
        }

        private static void CalculateSalary(Employee employee)
        {
            if (visitedEmplyees.Contains(employee.Id))
            {
                return;
            }

            if (employee.Subordinates.Count == 0)
            {
                employee.Salary = 1;
                return;
            }

            visitedEmplyees.Add(employee.Id);

            foreach (var subordinate in employee.Subordinates)
            {
                CalculateSalary(subordinate);
                employee.Salary += subordinate.Salary;
            }
        }
    }
}
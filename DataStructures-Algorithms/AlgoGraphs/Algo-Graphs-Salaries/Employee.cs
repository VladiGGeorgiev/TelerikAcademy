namespace Algo_Graphs_Salaries
{
    using System;
    using System.Collections.Generic;

    class Employee
    {
        public Employee(int id)
        {
            this.Id = id;
            this.Salary = 0;
            this.Subordinates = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public HashSet<Employee> Subordinates { get; set; }

        public long Salary { get; set; }

        public void AddSubordinate(Employee employee)
        {
            this.Subordinates.Add(employee);
        }
    }
}

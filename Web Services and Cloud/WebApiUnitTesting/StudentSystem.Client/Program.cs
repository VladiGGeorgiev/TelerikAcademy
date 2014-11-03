using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;
using StudentSystem.Models;

namespace StudentSystem.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StudentSystemContext,
                    Data.Migrations.Configuration>());

            StudentSystemContext context = new StudentSystemContext();
            context.Students.Add(new Student() {FirstName = "Test",LastName = "Student"});
            context.SaveChanges();
        }
    }
}

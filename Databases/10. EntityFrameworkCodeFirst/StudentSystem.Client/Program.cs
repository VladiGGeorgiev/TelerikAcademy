namespace StudentSystem.Client
{
    using System;
    using System.Linq;
    using StudentSystem.Model;
    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;
    using System.Data.Entity;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            StudentSystemContext db = new StudentSystemContext();
            DatabaseInitialize(db);
        }
          
        private static void DatabaseInitialize(StudentSystemContext db)
        {
            using (db)
            {
                #region Initialize data
                
                Student student = new Student
                {
                    Name = "Pesho Peshev",
                    Number = 1,
                    Age = 20,
                };
                
                Student student2 = new Student
                {
                    Name = "Stoyan Georgiev",
                    Number = 1,
                    Age = 22,
                };
                
                Student student3 = new Student
                {
                    Name = "Georgi Petrov",
                    Number = 1,
                    Age = 25,
                };
                
                Course course = new Course
                {
                    Name = "HTML",
                    Description = "HyperText Markup Language",
                };
                
                Course course2 = new Course
                {
                    Name = "C#",
                    Description = "Programming language",
                    Students = new List<Student>() { student2, student3 }
                };
                
                Course course3 = new Course
                {
                    Name = "OOP",
                    Description = "Object-oriented Programming",
                    Students = new List<Student>() { student, student2 }
                };

                student.Courses.Add(course);
                student.Courses.Add(course2);
                student3.Courses.Add(course2);
                student3.Courses.Add(course3);
                student2.Courses.Add(course);

                Homework homework = new Homework
                {
                    Course = course,
                    Student = student,
                    Content = "Watch all videos in msdn",
                    TimeSent = new DateTime(2013, 08, 15)
                };

                Homework homework2 = new Homework
                {
                    Course = course2,
                    Student = student3,
                    Content = "Implement priority queue",
                    TimeSent = new DateTime(2013, 08, 12)
                };

                Homework homework3 = new Homework
                {
                    Course = course3,
                    Student = student2,
                    Content = "Create university classes",
                    TimeSent = new DateTime(2013, 08, 20)
                };

                #endregion
                
                db.Courses.Add(course);
                db.Courses.Add(course2);
                db.Courses.Add(course3);
                
                db.Students.Add(student);
                db.Students.Add(student2);
                db.Students.Add(student3);

                db.Homeworks.Add(homework);
                db.Homeworks.Add(homework2);
                db.Homeworks.Add(homework3);
                
                db.SaveChanges();
            }
        }
    }
}

using System;
using System.Linq;

namespace FindInArray
{
    internal class Test
    {
        internal static void Main(string[] args)
        {
            Student pesho = new Student("Peter", "Ivanov", 18);
            Student minka = new Student("Minka", "Svirkata", 23);
            Student gogo = new Student("Gosho", "Minkov", 26);
            Student vlado = new Student("Vladimir", "Georgiev", 24);
            Student cecka = new Student("Cecka", "Cacheva", 24);
            Student boiko = new Student("Boiko", "Borisov", 24);
            Student zlatan = new Student("Zlatan", "Arnaudov", 24);

            Student[] students = { pesho, gogo, minka, vlado, cecka, boiko, zlatan };

            /* 3 task - Write a method that from a given array of students finds all students 
             * whose first name is before its last name alphabetically. Use LINQ query operators.
            */
            PrintSomeStudentsByNames(students);

            /* 4 task - Write a LINQ query that finds the first name and last name of 
             * all students with age between 18 and 24.
            */

            Console.WriteLine(new string('-', 50));

            var sortedStudents =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select student;

            foreach (var item in sortedStudents)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            /* 5 task - Using the extension methods OrderBy() and ThenBy() with lambda expressions 
             * sort the students by first name and last name in descending order. 
             * Rewrite the same with LINQ.
            */

            Console.WriteLine(new string('-', 50));

            //Lambda
            var array = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

            foreach (var student in array)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            //LINQ
            Console.WriteLine(new string('-', 50));

            var arrayLinq = 
                from student in students
                orderby student.FirstName descending
                select student;

            foreach (var student in arrayLinq)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }

        private static void PrintSomeStudentsByNames(Student[] students)
        {
            var sortedArray =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            foreach (var item in sortedArray)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
    }
}

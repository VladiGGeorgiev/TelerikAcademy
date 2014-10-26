using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student("Pesho", "Kirkov", 4),
                new Student("Minka", "Georgieva", 1), 
                new Student("Kichka", "Stankova", 3), 
                new Student("Stamat", "Mihov", 2), 
                new Student("Dida", "Petkova", 1), 
                new Student("Iliana", "Malcheva", 2), 
                new Student("Dido", "Poryazov", 3), 
                new Student("Kaloyan", "Manchev", 4), 
                new Student("Zlatan", "Kirov", 3), 
                new Student("Penka", "Bodurova", 4), 
            };

            var sortedStudents = students.OrderBy(student => student.Grade);

            /*
             * LINQ method to sort students
             * 
            var sortedLinqStudents = 
                from student in students
                orderby student.Grade
                select student;
            */

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " - grade: " + student.Grade);
            }

            ////Workers
            List<Worker> workers = new List<Worker>() 
            {
                new Worker("Georgi", "Dimitrov", 500, 30),
                new Worker("Petyr", "Georgiev", 400, 30),
                new Worker("Dimityr", "Enchev", 600, 25), 
                new Worker("Angel", "Jelyazkov", 550, 28), 
                new Worker("Stefka", "Karamfilova", 450, 25), 
                new Worker("Ognqn", "Arhangelov", 650, 30), 
                new Worker("Ilhan", "Bahnev", 300, 20), 
                new Worker("Dancho", "Lalev", 300, 15), 
                new Worker("Stanislav", "Marchev", 400, 20), 
                new Worker("Nikolay", "Dryanov", 450, 30), 
            };

            var sortedWorkers = workers.OrderByDescending(worker => worker.MoneyPerHour());
            Console.WriteLine();
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine("{0} {1} - {2:f2} $/hour", worker.FirstName, worker.LastName, worker.MoneyPerHour());
            }

            ////Merging the lists
            IEnumerable<Human> people = workers.Concat<Human>(students);

            var sortedPeople = people.OrderBy(human => human.FirstName).ThenBy(human => human.LastName);

            Console.WriteLine();
            foreach (var human in sortedPeople)
            {
                Console.WriteLine(human.FirstName + " " + human.LastName);
            }
        }
    }
}

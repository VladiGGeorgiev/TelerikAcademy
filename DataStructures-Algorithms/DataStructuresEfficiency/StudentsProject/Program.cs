using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace StudentsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<Student>> courses = ReadInput("../../students.txt");

            foreach (var course in courses)
            {
                Console.Write(course.Key + ": ");

                foreach (var student in course.Value)
                {
                    Console.Write(student + ", ");
                }
                Console.WriteLine();
            }
        }

        public static SortedDictionary<string, SortedSet<Student>> ReadInput(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);

            SortedDictionary<string, SortedSet<Student>> students = new SortedDictionary<string, SortedSet<Student>>();
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] tokens = line.Split('|');
                string fName = tokens[0].Trim();
                string lName = tokens[1].Trim();
                string course = tokens[2].Trim();
                if (!students.ContainsKey(course))
                {
                    students.Add(course, new SortedSet<Student>());
                }
                
                students[course].Add(new Student(fName, lName));

                line = reader.ReadLine();
            }

            return students;
        }
    }
}

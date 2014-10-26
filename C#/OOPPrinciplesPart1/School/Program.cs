using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            School penchoSlaveikov = new School("Pencho Slaveikov");

            Class mathClass = new Class("12A");
            penchoSlaveikov.AddClass(mathClass);
            Class artClass = new Class("12B");
            penchoSlaveikov.AddClass(artClass);

            #region All Students
            Student[] students = 
            {
                new Student("Pesho", 1),  
                new Student("Minka", 2),
                new Student("Goshko", 3),
                new Student("Stavri", 4),
                new Student("Penka", 5),
                new Student("Slavka", 6),
                new Student("Dimcho", 7),
                new Student("Pencho", 8),
                new Student("Simo", 9),
                new Student("Giga", 10),
                new Student("Aishe", 11),
            };
            #endregion

            #region All Disciplines
            Discipline mathematics = new Discipline("Mathematics", 3, 10);
            Discipline physics = new Discipline("Physics", 5, 15);
            Discipline geography = new Discipline("Geography", 2, 8);
            Discipline music = new Discipline("Music", 3, 6);
            Discipline english = new Discipline("English", 6, 12);
            Discipline drawing = new Discipline("Drawing", 2, 4);
            Discipline chemistry = new Discipline("Chemistry", 4, 8);
            #endregion

            #region All Teachers
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher("Georgiev"),
                new Teacher("Minkov"),
                new Teacher("Ivanov"),
                new Teacher("Panaiotoa"),
                new Teacher("Ignatova")
            };
            #endregion

            teachers[0].AddDiscipline(mathematics);
            teachers[0].AddDiscipline(physics);
            teachers[1].AddDiscipline(chemistry);
            teachers[1].AddDiscipline(physics);
            teachers[2].AddDiscipline(english);
            teachers[3].AddDiscipline(geography);
            teachers[4].AddDiscipline(music);
            teachers[4].AddDiscipline(drawing);

            mathClass.AddStudents(new List<Student>() 
            { 
                students[0], students[1], students[2], students[3], students[4], students[5] 
            });

            artClass.AddStudents(new List<Student>() 
            { 
                students[6], students[7], students[8], students[9], students[10] 
            });

            mathClass.AddTeachers(new List<Teacher>() { teachers[0], teachers[1], teachers[2] });
            artClass.AddTeachers(new List<Teacher>() { teachers[2], teachers[3], teachers[4] });

            #region Print on console
            Console.WriteLine("School: " + penchoSlaveikov);
            Console.Write("Classes: ");
            foreach (var clas in penchoSlaveikov.Classes)
            {
                Console.Write(clas + " ");
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Teachers in " + mathClass.UniqueId + ":");
            foreach (var teacher in mathClass.Teachers)
            {
                Console.WriteLine(teacher + " - teaches: " + teacher.Disciplines);
            }

            Console.WriteLine();
            Console.WriteLine("Teachers in " + artClass.UniqueId + ":");
            foreach (var teacher in artClass.Teachers)
            {
                Console.WriteLine(teacher + " - teaches: " + teacher.Disciplines);
            }

            Console.WriteLine();
            Console.WriteLine("Students in " + mathClass.UniqueId + ":");
            foreach (var student in mathClass.Students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
            Console.WriteLine("Students in " + artClass.UniqueId + ":");
            foreach (var student in artClass.Students)
            {
                Console.WriteLine(student);
            }
            #endregion
        }
    }
}

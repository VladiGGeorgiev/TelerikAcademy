namespace StudentClass
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Person pesho = new Person("Peter");

            Console.WriteLine(pesho);

            var mincho = new Student(
                "Mincho",
                "Hristov",
                "Petrov",
                323453,
                "Sofia",
                0888888888,
                "mhp@do.it",
                2,
                Specialty.Engines,
                University.TUSofia,
                Faculty.ComputerScience);

            var penka = new Student(
                "Penka",
                "Slavova",
                "Litova",
                323453,
                "Varna",
                0888123456,
                "psl@do.it",
                2,
                Specialty.PlasticSurgery,
                University.MedicalUniversity,
                Faculty.Chemistry);

            Student pencho = new Student(
                "Mincho",
                "Hristov",
                "Petrov",
                323453,
                "Sofia",
                0888765488,
                "mhp@do.it",
                5,
                Specialty.HumanBehavior,
                University.UniSofia,
                Faculty.Psychology);

            Console.WriteLine("Mincho equals pencho: " + mincho.Equals(pencho));
            Console.WriteLine("Mincho == pencho: " + (mincho == pencho));
            Console.WriteLine("Mincho != pencho: " + (mincho != pencho));

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(pencho);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(mincho);

            Console.WriteLine(Environment.NewLine);
            var tempStudent = mincho.Clone() as Student;
            Console.WriteLine("Reference equals tempStudent and mincho: " + object.ReferenceEquals(tempStudent.MiddleName, mincho.MiddleName));

            tempStudent.MiddleName = "Gosho";
            mincho.MiddleName = "Mincho 2";
            Console.WriteLine(tempStudent.MiddleName);
            Console.WriteLine(mincho.MiddleName); 

            Console.WriteLine(pencho.CompareTo(mincho));
        }
    }
}
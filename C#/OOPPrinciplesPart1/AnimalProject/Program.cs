using System;

namespace AnimalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = 
            {
                new Dog("Mincho", 4, SexEnum.Male),
                new Dog("Georgi", 6, SexEnum.Female),
                new Cat("Macka", 3, SexEnum.Female),
                new Cat("Mat", 4, SexEnum.Male),
                new Frog("Duda", 2, SexEnum.Female),
                new Frog("Cucka", 5, SexEnum.Female),
                new Kitten("Gigi", 1),
                new Kitten("Kichka", 1),
                new Tomcat("Mike", 1),
                new Tomcat("Tom", 2),
            };

            Console.WriteLine("Average age of different objects in list of animals:");
            Animal.AverageAge(animals);

            Animal[] otherAnimals = 
            {
                new Dog("Pesho", 4, SexEnum.Male),
                new Dog("Virka", 6, SexEnum.Female),
                new Cat("Cuca", 3, SexEnum.Female),
                new Cat("Mop", 4, SexEnum.Male),
                new Frog("Dodo", 2, SexEnum.Male),
                new Frog("Tosho", 5, SexEnum.Male),
                new Kitten("Pupi", 1),
                new Kitten("Mini", 1),
                new Tomcat("Hop", 2),
                new Tomcat("Mit", 2),
            };

            Console.WriteLine();
            Console.WriteLine("Average age of different objects in list of other animals:");
            Animal.AverageAge(otherAnimals);
        }
    }
}

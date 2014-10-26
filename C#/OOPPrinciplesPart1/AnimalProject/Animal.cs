namespace AnimalProject
{
    using System;
    using System.Linq;

    public enum SexEnum { Male, Female };

    public abstract class Animal
    {
        public string Name { get; private set; }
        public byte Age { get; private set; }
        public SexEnum Sex;

        public Animal(string name, byte age, SexEnum sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public static void AverageAge(Animal[] animals)
        {
            var animalsByType = animals.GroupBy(x => x.GetType());

            foreach (var animal in animalsByType)
            {
                Console.WriteLine(animal.Key + " average age: " + animal.Average(x => x.Age)); 
            }
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} and is {2} years old", this.Name, this.Sex, this.Age);
        }
    }
}

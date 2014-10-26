using System;
using System.Linq;

namespace AnimalProject
{
    public class Cat : Animal, ISound
    {
        public SexEnum Sex { get; private set; }

        public Cat(string name, byte age, SexEnum sex)
            : base(name, age, sex)
        {
        }

        public string MakeSound()
        {
            return "MIaaaauuuu"; 
        }
    }
}

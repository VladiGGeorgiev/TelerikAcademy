namespace AnimalProject
{
    public class Dog : Animal, ISound
    {
        public Dog(string name, byte age, SexEnum sex) : base(name, age, sex)
        {
        }

        public string MakeSound()
        {
            return "Bark";
        }
    }
}

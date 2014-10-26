namespace AnimalProject
{
    public class Frog : Animal, ISound
    {
        public Frog(string name, byte age, SexEnum sex) : base(name, age, sex)
        {
        }

        public string MakeSound()
        {
            return "CraCraCra";
        }
    }
}

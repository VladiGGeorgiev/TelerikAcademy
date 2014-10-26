namespace AnimalProject
{
    public class Kitten : Cat, ISound
    {
        public Kitten(string name, byte age) : base(name, age, SexEnum.Female)
        {
        }
    }
}

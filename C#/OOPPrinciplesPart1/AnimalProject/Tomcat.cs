namespace AnimalProject
{
    public class Tomcat : Cat, ISound
    {
        public Tomcat(string name, byte age) : base(name, age, SexEnum.Male)
        {
        }
    }
}

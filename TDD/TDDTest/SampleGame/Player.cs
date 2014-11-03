namespace SampleGame
{
    public class Player
    {
        public string Name { get; protected set; }
        public string ID { get; protected set; }

        public Player(string name, string id)
        {
            this.Name = name;
            this.ID = id;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void ChangeID(string id)
        {
            this.ID = id;
        }
    }
}

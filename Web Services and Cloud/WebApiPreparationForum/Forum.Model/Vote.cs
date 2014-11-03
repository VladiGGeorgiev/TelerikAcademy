namespace Forum.Model
{
    public class Vote
    {
        public int VoteId { get; set; }

        public int Value { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}

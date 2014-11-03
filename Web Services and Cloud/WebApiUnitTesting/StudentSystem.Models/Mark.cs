namespace StudentSystem.Models
{
    public class Mark
    {
        public int MarkId { get; set; }

        public string Subject { get; set; }

        public double Value { get; set; }

        public Student Student { get; set; }
    }
}

namespace HumanProject
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
    }
}

namespace BankProject
{
    class Company : Customer
    {
        public long Bulstat { get; private set; }
        public Company(string name, long bulstat) : base(name)
        {
            this.Bulstat = bulstat;
        }
    }
}

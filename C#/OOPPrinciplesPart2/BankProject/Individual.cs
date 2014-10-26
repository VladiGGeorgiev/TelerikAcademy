namespace BankProject
{
    class Individual : Customer
    {
        uint personalCardNumber;
        public Individual(string name, uint personalCardNumber) : base(name)
        {
            this.personalCardNumber = personalCardNumber;
        }
    }
}

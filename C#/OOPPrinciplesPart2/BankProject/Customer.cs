namespace BankProject
{
    class Customer
    {
        public string Name { get; protected set; }

        public Customer(string name)
        {
            this.Name = name;
        }
    }
}

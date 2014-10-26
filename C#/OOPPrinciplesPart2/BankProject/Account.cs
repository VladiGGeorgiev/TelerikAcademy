namespace BankProject
{
    abstract class Account : IDeposible
    {
        Customer customer;
        decimal balance;
        decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.customer = customer;
            this.balance = balance;
            this.interestRate = interestRate;
        }

        public abstract void MakeDeposit(decimal money);

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                this.balance = value;
            }
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }

            set
            {
                this.customer = value;
            }
        }

        public virtual decimal CalculateInterestAmount(int months)
        {
            decimal interestAmount = months * this.interestRate;

            return interestAmount;
        }
    }
}

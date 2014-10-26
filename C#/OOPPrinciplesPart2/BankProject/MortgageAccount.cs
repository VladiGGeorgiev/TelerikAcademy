namespace BankProject
{
    class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        { 
        }

        public override void MakeDeposit(decimal money)
        {
            this.Balance += money;
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (months > 12 && this.Customer is Company)
            {
                return this.InterestRate * months;
            }
            else if (months > 6 && this.Customer is Individual)
            {
                return this.InterestRate * months;
            }
            else
            {
                return 0;
            }
        }
    }
}

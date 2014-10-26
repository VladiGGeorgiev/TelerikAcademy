namespace BankProject
{
    class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override void MakeDeposit(decimal money)
        {
            this.Balance += money;
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (months <= 3 && this.Customer is Individual)
            {
                return 0;
            }
            else if (months <= 2 && this.Customer is Company)
            {
                return 0;
            }
            else
            {
                return this.InterestRate * months;
            }
        }
    }
}

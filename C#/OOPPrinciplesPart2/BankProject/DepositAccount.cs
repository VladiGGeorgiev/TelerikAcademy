namespace BankProject
{
    using System;

    class DepositAccount : Account, IWithDrawable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override void MakeDeposit(decimal money)
        {
            this.Balance += money;
        }

        public void MakeWithDraw(decimal money)
        {
            throw new NotImplementedException();
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Balance > 1000)
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

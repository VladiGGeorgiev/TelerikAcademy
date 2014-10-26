namespace BankProject
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Individual("Mincho", 3123123123));
            customers.Add(new Individual("Penka", 929493172));
            customers.Add(new Company("Telerik", 9999));
            customers.Add(new Company("SAP", 1212));
            customers.Add(new Company("VMWare", 12312344));

            List<Account> accountsList = new List<Account>();
            accountsList.Add(new DepositAccount(customers[0], 33333, 3));
            accountsList.Add(new DepositAccount(customers[1], 21323, 5));
            accountsList.Add(new DepositAccount(customers[2], 1111, 4));
            accountsList.Add(new LoanAccount(customers[3], 1000, 0.06m));
            accountsList.Add(new MortgageAccount(customers[4], 800, 0.06m));

            foreach (var account in accountsList)
            {
                Console.WriteLine("Customer: {0} InterestRate: {1}", account.Customer.Name, account.CalculateInterestAmount(6));
                account.MakeDeposit(2000);
            }
        }
    }
}

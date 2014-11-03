using NorthwindEntity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    //insert, update, delete
    public static class DAO
    {
        public static void InsertCustomer(Customer customer)
        {
            NorthwndEntities database = new NorthwndEntities();
            using (database)
            {
                database.Customers.Add(customer);
                database.SaveChanges();
            }
        }

        public static void UpdateCustomer(Customer oldCustomer, Customer newCustomer)
        {
            NorthwndEntities database = new NorthwndEntities();
            using (database)
            {
                var customer = database.Customers.Find(oldCustomer.CustomerID);
                customer.Address = newCustomer.Address;
                customer.City = newCustomer.City;
                customer.CompanyName = newCustomer.CompanyName;
                customer.ContactName = newCustomer.ContactName;
                customer.ContactTitle = newCustomer.ContactTitle;
                customer.Country = newCustomer.Country;
                customer.CustomerDemographics = newCustomer.CustomerDemographics;
                customer.Fax = newCustomer.Fax;
                customer.Orders = newCustomer.Orders;
                customer.Phone = newCustomer.Phone;
                customer.PostalCode = newCustomer.PostalCode;
                customer.Region = newCustomer.Region;
                database.SaveChanges();
            }
        }

        public static void DeleteCustomer(Customer customer)
        {
            NorthwndEntities database = new NorthwndEntities();
            using (database)
            {
                var cust = database.Customers.Find(customer.CustomerID);
                database.Customers.Remove(cust);
                database.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Data;
using System.Data;

namespace ContactBook.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var contactsRepository = new GenericRepository<Contact>();

            contactsRepository.Delete(5);

            //for (int i = 0; i < 1000; i++)
            //{
            //    var currentContact = new Contact();
            //    currentContact.FirstName = "ContactFirstName" + i;
            //    currentContact.LastName = "ContactLastName" + i;

            //    if (i % 3 == 0)
            //    {
            //        currentContact.Sex = Sex.Male;
            //        currentContact.Status = Status.Active;
            //    }
            //    else if (i % 3 == 1)
            //    {
            //        currentContact.Sex = Sex.Female;
            //        currentContact.Status = Status.Inactive;
            //    }
            //    else
            //    {
            //        currentContact.Sex = Sex.Other;
            //        currentContact.Status = Status.Deleted;
            //    }

            //    Random rand = new Random();
            //    currentContact.Telephone = rand.Next(1000000000, 2000000000).ToString();

            //    contactsRepository.Add(currentContact);
            //}
        }
    }
}

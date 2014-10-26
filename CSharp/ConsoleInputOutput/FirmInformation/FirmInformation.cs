/* 3.A company has name, address, phone number, fax number, web site and manager.
 * The manager has first name, last name, age and a phone number. 
 * Write a program that reads the information about a company and 
 * its manager and prints them on the console.
*/
using System;

class FirmInformation
{
    static void Main()
    {
        Console.Write("Insert firm name: ");
        string name = Console.ReadLine();
        Console.Write("Insert adress: ");
        string adress = Console.ReadLine();
        Console.WriteLine("Insert website: ");
        string webSite = Console.ReadLine();

        Console.WriteLine("Insert phone number: ");
        uint number = uint.Parse(Console.ReadLine());
        Console.WriteLine("Insert fax number: ");
        uint faxNumber = uint.Parse(Console.ReadLine());

        Console.WriteLine("Insert manager First name: ");
        string managerFirstName = Console.ReadLine();
        Console.WriteLine("Insert manager Last name: ");
        string managerLastName = Console.ReadLine();
        Console.WriteLine("Insert manager phone number: ");
        int managerNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("The name of the firm is {0}. Location is {1}. You can find us in WEB at: {2}.", name, adress, webSite);
        Console.WriteLine("Phone number of the firm is {0} with {1} faks number", number, faxNumber);
        Console.WriteLine("The name of the manager is: {0} {1} \r\nAnd his number is: {2}", managerFirstName, managerLastName, managerNumber);
    }
}
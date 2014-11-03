using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryPasswords
{
    class BinaryPasswords
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            int missingDigits = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == '*')
                {
                    missingDigits++;
                }
            }

            long possiblePasswords = 1;
            for (int i = 0; i < missingDigits; i++)
            {
                possiblePasswords *= 2;
            }

            Console.WriteLine(possiblePasswords);
        }
    }
}

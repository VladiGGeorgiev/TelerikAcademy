using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int firstPosition = 0;
            int secondPosition = number - 1;
            for (int row = 0; row < number / 2; row++)
            {
                for (int col = 0; col < number; col++)
                {
                    if (col == (number / 2))
                    {
                        Console.Write("|");
                    }
                    else if (col == firstPosition)
                    {
                        Console.Write("\\");
                    }
                    else if (col == secondPosition)
                    {
                        Console.Write("/");
                    }

                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();

                firstPosition++;
                secondPosition--;

            }
            Console.Write(new string('-', (number / 2)));
            Console.Write(new string('*', 1));
            Console.Write(new string('-', (number / 2)));
            Console.WriteLine();

            firstPosition = number / 2 + 1;
            secondPosition = number / 2 - 1;
            for (int row = 0; row < number / 2; row++)
            {
                for (int col = 0; col < number; col++)
                {
                    if (col == (number / 2))
                    {
                        Console.Write("|");
                    }
                    else if (col == firstPosition)
                    {
                        Console.Write("\\");
                    }
                    else if (col == secondPosition)
                    {
                        Console.Write("/");
                    }

                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();

                firstPosition++;
                secondPosition--;

            }

        }
    }
}

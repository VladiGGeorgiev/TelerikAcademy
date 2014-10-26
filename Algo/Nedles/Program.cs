using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedles
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            int c = int.Parse(firstLine.Split(' ')[0]);
            int n = int.Parse(firstLine.Split(' ')[1]);

            string secondLine = Console.ReadLine();
            string[] numbersStr = secondLine.Split(new char[]
            {
                ' '
            });
            int[] numbers = new int[numbersStr.Length];
            for (int i = 0; i < numbersStr.Length; i++)
            {
                numbers[i] = int.Parse(numbersStr[i]);
            }

            string thirdLine = Console.ReadLine();
            string[] numbersSearchStr = thirdLine.Split(new char[]
            {
                ' '
            });
            int[] searchNumbers = new int[numbersSearchStr.Length];
            for (int i = 0; i < numbersSearchStr.Length; i++)
            {
                searchNumbers[i] = int.Parse(numbersStr[i]);
            }

            for (int i = numbers.Length - 1; i >= 0 ; i--)
            {
                if (numbers[i] == 0)
                {
                    
                }
            }
        }
    }
}

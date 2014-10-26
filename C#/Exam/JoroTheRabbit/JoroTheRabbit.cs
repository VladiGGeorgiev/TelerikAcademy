using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoroTheRabbit
{
    class JoroTheRabbit
    {
        static void Main()
        {
            string line = "1, -2, -3, 4, -5, 6, -7, -8"; //Console.ReadLine();
            string[] numbersStr = line.Split(',');
            int[] numbers = new int[numbersStr.Length];
            int startNumber = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                numbersStr[i].Trim();
                numbers[i] = int.Parse(numbersStr[i]);
            }

            int maxNumber = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }
            int jump = 1;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int currentJump = numbers[i];
                for (int j = 0; j < numbers.Length; j+= jump)
                {
                    if (currentJump < numbers[j])
                    {
                        jump = j - i;
                        jumpsCounter++;
                        currentJump = numbers[j];
                    }
                    if (currentJump == maxNumber)
                    {
                        break;
                    }
                    if (j + jump > numbers.Length)
                    {
                        j = (j + jump) - numbers.Length;
                    }
                }
                if (maxJumps < jumpsCounter)
                {
                    maxJumps = jumpsCounter;
                }
                jumpsCounter = 0;
            }
            
        }
        static List<int> results = new List<int>();
        static int maxJumps = 0;
        static int jumpsCounter = 0;
        //private static void Solve(int[] numbers, int startNumber, int maxNumber)
        //{
        //    if (numbers[startNumber] == maxNumber)
        //    {
        //        results.Add(jumpsCounter);
        //        return;
        //    }

        //    for (int j = 0; j < numbers.Length; j++)
        //    {
        //        if (numbers[j] > numbers[startNumber])
        //        {
        //            jumpsCounter++;
        //            startNumber = j;
        //            Solve(numbers, j+ 1, maxNumber);
        //        }
        //        if (j == numbers.Length - 1)
        //        {
        //            j = 0;
        //        }
        //        if (numbers[startNumber] == maxNumber)
        //        {
        //            return;
        //        }
        //    }
        //    jumpsCounter = 0;
        //}
    }
}

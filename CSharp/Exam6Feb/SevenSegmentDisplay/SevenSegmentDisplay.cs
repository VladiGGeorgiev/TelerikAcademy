namespace SevenSegmentDisplay
{
    using System;
    using System.Collections.Generic;

    public class SevenSegmentDisplay
    {
        static private readonly int[] PossibleNumbers = new int[10]
        {
            126, 48, 109, 121, 51, 91, 95, 112, 127, 123 
        };

        private static readonly List<string> AllAnswers = new List<string>();
        private static int[] inputStates;
        private static char[] currentAnswer;

        private static void FindPossibleNumbers(int p, int n)
        {
            if (p == n)
            {
                AllAnswers.Add(new string(currentAnswer));
                return;
            }

            for (int i = 0; i < PossibleNumbers.Length; i++)
            {
                if ((inputStates[p] & PossibleNumbers[i]) == inputStates[p])
                {
                    currentAnswer[p] = (char)('0' + i);
                    FindPossibleNumbers(p + 1, n);
                }
            }
        }

        private static int BinNumberToDec(string number)
        {
            int decimalNumber = 0;
            int binNumber = int.Parse(number);
            for (int i = 0; i < number.Length; i++)
            {
                decimalNumber += (binNumber % 10) * (int)Math.Pow(2, i);
                binNumber /= 10;
            }

            return decimalNumber;
        }

        private static void PrintAnswers()
        {
            Console.WriteLine(AllAnswers.Count);

            foreach (var item in AllAnswers)
            {
                Console.WriteLine(item);
            }
        }

        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            inputStates = new int[n];
            currentAnswer = new char[n];

            for (int i = 0; i < n; i++)
            {
                string currentLineNumber = Console.ReadLine();
                inputStates[i] = BinNumberToDec(currentLineNumber);
            }

            FindPossibleNumbers(0, n);

            PrintAnswers();
        }
    }
}

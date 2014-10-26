namespace Tubes
{
    using System;

    class Tubes
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] tubes = new int[n];

            for (int i = 0; i < n; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
            }

            int min = 0;
            int max = 2000000000;
            int possibleAnswer = (max + min) / 2;
            int numberOfTubes = 0;

            while (min <= max)
            {
                numberOfTubes = 0;

                for (int i = 0; i < tubes.Length; i++)
                {
                    numberOfTubes += tubes[i] / possibleAnswer;
                }

                if (numberOfTubes < m)
                {
                    max = possibleAnswer - 1;
                }
                else
                {
                    min = possibleAnswer + 1;
                }

                possibleAnswer = (min + max) / 2;
            }

            Console.WriteLine(possibleAnswer);
        }
    }
}

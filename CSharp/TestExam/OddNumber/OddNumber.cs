using System;

class OddNumber
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        long number = 0;
        long oddNumber = 0;
        for (int i = 0; i < N; i++)
        {
            number = long.Parse(Console.ReadLine());
            oddNumber ^= number;
        }
        Console.WriteLine(oddNumber);
    }
}

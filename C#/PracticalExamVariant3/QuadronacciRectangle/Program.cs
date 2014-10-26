using System;

class Program
{
    static void Main(string[] args)
    {


        long n1 = long.Parse(Console.ReadLine());
        long n2 = long.Parse(Console.ReadLine());
        long n3 = long.Parse(Console.ReadLine());
        long n4 = long.Parse(Console.ReadLine());

        byte R = byte.Parse(Console.ReadLine());
        byte C = byte.Parse(Console.ReadLine());
        long[] numbers = new long[R * C];

        numbers[0] = n1;
        numbers[1] = n2;
        numbers[2] = n3;
        numbers[3] = n4;

        for (int i = 4; i < R * C; i++)
        {
            numbers[i] = numbers[i - 1] + numbers[i - 2]
                + numbers[i - 3] + numbers[i - 4];

        }

        for (int i = 0; i < numbers.Length; i++)
        {
            if (i % C == 0 && i != 0)
            {
                Console.WriteLine();
            }
            if (i % C == 0 && i != 0)
            {
                Console.Write(numbers[i]);
            }
            else if (i != 0)
            {
                Console.Write(" " + numbers[i]);   
            }

            else
            {
                Console.Write(numbers[i]);
            }
        }
    }
}
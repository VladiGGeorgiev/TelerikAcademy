namespace StraightLineCode
{
    using System;

    public class Chef
    {
        public static void Main()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        i = 666;
                    }
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }
            // More code here
            if (i == 666)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}

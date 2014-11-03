namespace Sequence
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            Queue<int> numbers = new Queue<int>();
            numbers.Enqueue(n);
            int index = 0;

            while (index < 50)
            {
                int currentNumber = numbers.Dequeue();
                Console.WriteLine(currentNumber);

                numbers.Enqueue(currentNumber + 1);
                numbers.Enqueue(currentNumber * 2 + 1);
                numbers.Enqueue(currentNumber + 2);

                index++;
            }
        }
    }
}

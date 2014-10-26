/*Write a program that reads two numbers N and K and generates
 * all the combinations of K distinct elements from the set [1..N]. Example:
	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
*/

using System;

class CombinationsFromSet
{
    private static void Combinations(int[] array, int element, int numbers, int begin)
    {
        if (element == -1)
        {
            Print(array);
        }
        else
        {
            for (int i = begin; i <= numbers; i++)
            {
                array[element] = i;
                Combinations(array, element - 1, numbers, i + 1);
            }
        }
    }

    private static void Print(int[] array)
    {
        Console.Write("{ ");
        for (int i = array.Length - 1; i >= 0; i--)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine("}");
    }

    static void Main()
    {
        int numbers = int.Parse(Console.ReadLine());
        int elements = int.Parse(Console.ReadLine());
        int begin = 1;
        int[] array = new int[elements];

        Combinations(array, elements - 1, numbers, begin);
    }
}
using System;

class Variations
{
    private static void GenerateVariations(int[] array, int elements, int numbers)
    {
        if (elements == -1)
        {
            Print(array);
        }
        else
        {
            for (int i = 1; i <= numbers; i++)
            {
                array[elements] = i;
                GenerateVariations(array, elements - 1, numbers);
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

        int[] array = new int[elements];

        GenerateVariations(array, elements - 1, numbers);

    }
}
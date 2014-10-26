using System;

class MostFrequentNumber
{
    static void Main()
    {
        int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

        int maxNumberFrequences = 1;
        int number = 0;
        for (int i = 0; i < array.Length; i++)
        {
            int numberFrequences = 1;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    numberFrequences++;
                }
            }
            if (numberFrequences > maxNumberFrequences)
            {
                maxNumberFrequences = numberFrequences;
                number = array[i];
            }
        }
        Console.WriteLine(number + " (" + maxNumberFrequences + " times)");
    }
}
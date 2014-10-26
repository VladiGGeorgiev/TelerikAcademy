using System;
using System.Collections.Generic;

class DurankulacNumbers
{
    static void Main()
    {
        //Read the input
        string durStrNumber = Console.ReadLine();

        List<string> durNumber = new List<string>();
        for (int i = durStrNumber.Length - 1; i >= 0 ; i--)
        {
            if (char.IsUpper(durStrNumber[i]) && i != 0 && char.IsLower(durStrNumber[i - 1]))
            {
                durNumber.Add(durStrNumber[i - 1].ToString() + durStrNumber[i]);
            }
            if ((char.IsUpper(durStrNumber[i]) && i == 0) || 
                (char.IsUpper(durStrNumber[i]) && i !=0 && char.IsUpper(durStrNumber[i - 1])))
            {
                durNumber.Add(durStrNumber[i].ToString());
            }
        }

        //Read char by char
        long currentAnswer = 0;
        long answer = 0;
        for (int i = 0; i < durNumber.Count; i++)
        {
            for (int j = 0; j < durNumber[i].Length; j++)
            {
                if (char.IsLower(durNumber[i][j]))
                {
                    currentAnswer += (durNumber[i][j] - 'a' + 1) * 26;
                }
                if (char.IsUpper(durNumber[i][j]))
                {
                    currentAnswer += (durNumber[i][j] - 'A');
                }
                
            }
            currentAnswer = currentAnswer * (long)Math.Pow(168, i);
            answer += currentAnswer;
            currentAnswer = 0;
        }
        Console.WriteLine(answer);
        //Write the output
    }
}
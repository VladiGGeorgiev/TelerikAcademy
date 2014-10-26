using System;
using System.Collections.Generic;

class CleanCode
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());

        List<string> code = new List<string>(lines);

        for (int i = 0; i < lines; i++)
		{
            code.Add(Console.ReadLine());
		}

        bool isInComment = false;
        bool isInString = false;
        for (int i = 0; i < code.Count; i++)
        {
            int commentIndex = code[i].IndexOf("//");
            code.RemoveRange(commentIndex, (code[i].Length - commentIndex - 1));
        }

        for (int i = 0; i < code.Count; i++)
        {
            Console.WriteLine(code[i]);
        }
    }
}
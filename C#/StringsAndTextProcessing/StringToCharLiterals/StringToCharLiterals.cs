/*Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings.*/

namespace StringToCharLiterals
{
    using System;

    public class StringToCharLiterals
    {
        public static void Main(string[] args)
        {
            string text = "Hi!";

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write("\\u{0:x4}", (int)text[i]);
            }
        }
    }
}

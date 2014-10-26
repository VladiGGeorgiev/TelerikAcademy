/*Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. 
 * The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, 
 * the second – with the second, etc. When the last key character is reached, the next is the first.
*/

namespace TextEncodeDecode
{
    using System;
    using System.Collections.Generic;

    public class TextEncodeDecode
    {
        public static void Main(string[] args)
        {
            string text = "Write a program that encodes and decodes a string using given encryption key";
            string key = "bubble";

            List<int> encText = EncodeText(text, key);
            char[] decText = DecodeText(encText, key);

            Print(encText);

            Console.WriteLine("\n" + new string('-', 50));

            Console.WriteLine(string.Join(string.Empty, decText));
        }

        private static void Print(List<int> encText)
        {
            for (int i = 0; i < encText.Count; i++)
            {
                Console.Write("\\u{0:x4}", encText[i]);
            }
        }

        private static List<int> EncodeText(string text, string key)
        {
            List<int> encodedText = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                encodedText.Add((text[i] ^ key[i % key.Length]));
            }

            return encodedText;
        }

        private static char[] DecodeText(List<int> encode, string key)
        {
            char[] decodedText = new char[encode.Count];
            for (int i = 0; i < encode.Count; i++)
            {
                decodedText[i] = (char)(encode[i] ^ key[i % key.Length]);
            }

            return decodedText;
        }
    }
}

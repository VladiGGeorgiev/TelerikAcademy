/*Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
*/

namespace CountSubstring
{
    using System;

    public class CountSubstring
    {
        public static void Main(string[] args)
        {
            string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string searchedString = "in";

            int substringCounter = CountSubstringInText(text, searchedString);
            Console.WriteLine("Number of \"{0}\" in text is: {1}", searchedString, substringCounter);
        }

        private static int CountSubstringInText(string text, string searchedString)
        {
            int substringCounter = 0;
            string currentSubstring = string.Empty;

            for (int i = 0; i < (text.Length - searchedString.Length) + 1; i++)
            {
                currentSubstring = text.Substring(i, searchedString.Length);
                if (currentSubstring.ToLower() == searchedString)
                {
                    substringCounter++;
                }
            }

            return substringCounter;
        }
    }
}

/*You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. 
 * The tags cannot be nested. 
*/

namespace UppercaseSubstring
{
    using System;

    public class UppercaseSubstring
    {
        public static void Main(string[] args)
        {
            string text = @"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            Console.WriteLine(text);
            string openTag = "<upcase>";
            string closeTag = "</upcase>";

            string newText = UppercaseSubstrings(text, openTag, closeTag);

            Console.WriteLine(newText);
        }

        private static string UppercaseSubstrings(string text, string openTag, string closeTag)
        {
            /*Find indexes of tags */
            int index = text.IndexOf(openTag);
            int endIndex = text.IndexOf(closeTag);
            while (index >= 0)
            {
                /*Indexes of text between tags*/
                int startUppercaseText = index + openTag.Length;
                int endUppercaseText = endIndex;

                /*Uppercase text between tags*/
                string subUppercaseText = text.Substring(startUppercaseText, endUppercaseText - startUppercaseText);
                text = text.Replace(subUppercaseText, subUppercaseText.ToUpper());

                /*Remove tags*/
                text = text.Remove(text.IndexOf(openTag), openTag.Length);
                text = text.Remove(text.IndexOf(closeTag), closeTag.Length);

                /*If there are more tags loop will continue*/
                index = text.IndexOf(openTag);
                endIndex = text.IndexOf(closeTag);
            }

            return text;
        }
    }
}

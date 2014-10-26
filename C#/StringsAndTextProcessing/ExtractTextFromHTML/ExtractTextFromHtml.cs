/* Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.*/
namespace ExtractTextFromHtml
{
    using System;
    using System.IO;

    public class ExtractTextFromHtml
    {
        public static void Main()
        {
            string text = string.Empty;
            using (var reader = new StreamReader("../../html.txt"))
            {
                text = reader.ReadToEnd();
            }

            int startIndex = text.IndexOf('<');
            int endIndex = text.IndexOf('>');
            while (startIndex >= 0)
            {
                text = text.Remove(startIndex, endIndex - startIndex + 1);
                
                startIndex = text.IndexOf('<');
                endIndex = text.IndexOf('>');
            }

            text = text.Trim();
            Console.WriteLine(text);
        }
    }
}

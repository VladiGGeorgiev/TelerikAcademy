using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractTextFromXml
{
    class ExtractTextFromXml
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            using (var reader = new StreamReader("../../file.xml"))
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractSentencesWithWord
{
    class ExtractSentencesWithWord
    {
        static void Main(string[] args)
        {
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string searchWord = " in ";
            string[] sentences = text.Split('.');

            for (int i = 0; i < sentences.Length; i++)
            {
                if (sentences[i].Contains(searchWord))
                {
                    Console.WriteLine(sentences[i].Trim());
                }
            }
        }
    }
}

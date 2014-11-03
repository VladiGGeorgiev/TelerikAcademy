using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesInABottle
{
    class Program
    {
        static Dictionary<string, string> codes = new Dictionary<string,string>();
        static HashSet<string> decodedMessages = new HashSet<string>();
        static string currentMessage;
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string ciffer = Console.ReadLine();
            codes = ProcessCiffer(ciffer);

            DecodeMessage(message, 0);
            Console.WriteLine(decodedMessages.Count);
            Console.WriteLine(string.Join(Environment.NewLine, decodedMessages.OrderBy(x => x)));
        }

        private static void DecodeMessage(string message, int index)
        {
            if (index == message.Length)
            {
                decodedMessages.Add(currentMessage);
                return;
            }

            for (int i = 1; i <= message.Length - index; i++)
            {
                if (codes.ContainsKey(message.Substring(index, i)))
                {
                    currentMessage += codes[message.Substring(index, i)];
                    DecodeMessage(message, index + i);
                    currentMessage = currentMessage.Remove(currentMessage.Length - 1);
                }
            }
        }

        private static Dictionary<string, string> ProcessCiffer(string ciffer)
        {
            Dictionary<string, string> codes = new Dictionary<string, string>();
            string letter = string.Empty;
            for (int i = 0; i < ciffer.Length; i++)
            {
                if (char.IsLetter(ciffer[i]))
                {
                    letter = ciffer[i].ToString();
                }

                i++;
                string code = string.Empty;
                while (i < ciffer.Length && !char.IsLetter(ciffer[i]))
                {
                    code += ciffer[i];
                    i++;
                }

                codes.Add(code, letter);
                i--;
            }

            return codes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageInABottle
{
    class Program
    {
        static List<KeyValuePair<char, string>> codes = new List<KeyValuePair<char, string>>();
        static List<string> decodedMessages = new List<string>();
        static string message;

        static void Main(string[] args)
        {
            message = Console.ReadLine();
            string chipher = Console.ReadLine();

            ParseChipher(chipher);

            DecodeMessage(0, new StringBuilder());

            Console.WriteLine(decodedMessages.Count);
            decodedMessages.Sort();
            foreach (var msg in decodedMessages)
            {
                Console.WriteLine(msg);
            }
        }

        private static void ParseChipher(string chipher)
        {
            char key = char.MinValue;
            StringBuilder value = new StringBuilder();
            for (int i = 0; i < chipher.Length; i++)
            {
                if (chipher[i] >= 'A' && chipher[i] <= 'Z')
                {
                    if (key != char.MinValue)
                    {
                        var code = new KeyValuePair<char, string>(key, value.ToString());
                        codes.Add(code);
                        value.Clear();
                    }

                    key = chipher[i];
                }
                else
                {
                    value.Append(chipher[i]);
                }
            }

            if (key != char.MinValue)
            {
                var code = new KeyValuePair<char, string>(key, value.ToString());
                codes.Add(code);
            }
        }
        
        private static void DecodeMessage(int messageIndex, StringBuilder result)
        {
            if (messageIndex >= message.Length)
            {
                decodedMessages.Add(result.ToString());
                return;
            }

            foreach (var code in codes)
            {
                if (message.Substring(messageIndex).StartsWith(code.Value))
                {
                    result.Append(code.Key);
                    DecodeMessage(messageIndex + code.Value.Length, result);
                    result.Length--;
                }
            }
        }
    }
}

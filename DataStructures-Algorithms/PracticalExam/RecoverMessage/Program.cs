using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverMessage
{
    class Letter
    {
        public Letter(char value)
        {
            this.Value = value;
            this.After = new List<Letter>();
            this.Before = new List<Letter>();
        }
        public List<Letter> Before { get; set; }

        public List<Letter> After { get; set; }

        public char Value { get; set; }

        public void AddBefore(Letter letter)
        {
            this.Before.Add(letter);
        }

        public void AddAfter(Letter letter)
        {
            this.After.Add(letter);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> receivedMessages = new List<string>();
            for (int i = 0; i < n; i++)
            {
                receivedMessages.Add(Console.ReadLine());
            }

            Dictionary<char, Letter> letters = new Dictionary<char, Letter>();

            for (int i = 0; i < receivedMessages.Count; i++)
            {
                for (int j = 0; j < receivedMessages[i].Length; j++)
                {
                    if (!letters.ContainsKey(receivedMessages[i][j]))
                    {
                        letters.Add(receivedMessages[i][j], new Letter(receivedMessages[i][j]));
                    }
                }
            }
        }
    }
}

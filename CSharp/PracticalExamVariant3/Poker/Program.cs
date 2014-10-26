using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cards = new string[5];
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = Console.ReadLine();
                if (cards[i] == "J")
                {
                    cards[i] = "11";
                }
                else if (cards[i] == "Q")
                {
                    cards[i] = "12";
                }
                else if (cards[i] == "K")
                {
                    cards[i] = "13";
                }
                else if (cards[i] == "A")
                {
                    cards[i] = "14";
                }
            }

            int counter = 0;
            int secondCounter = 0;
            int maxFrequent = 0;
            int straightCather = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                counter = 0;
                for (int j = 0; j < cards.Length; j++)
                {
                    if (cards[i] == cards[j])
                    {
                        counter++;
                        secondCounter++;

                        if (counter > maxFrequent)
                        {
                            maxFrequent = counter;
                        }
                    }
                    if (int.Parse(cards[i]) == int.Parse(cards[j]) + 1)
                    {
                        straightCather++;
                    }
                }
            }

            if (maxFrequent == 5)
            {
                Console.WriteLine("Impossible");
            }
            else if (maxFrequent == 4)
            {
                Console.WriteLine("Four of a Kind");
            }
            else if (maxFrequent == 3 && secondCounter == 13)
            {
                Console.WriteLine("Full House");
            }
            else if (maxFrequent == 2 && (secondCounter - 1) / 4 == 2)
            {
                Console.WriteLine("Two Pairs");
            }
            else if (maxFrequent == 3)
            {
                Console.WriteLine("Three of a Kind");
            }
            else if (secondCounter == 7)
            {
                Console.WriteLine("One Pair");
            }
            else if (straightCather == 4)
            {
                Console.WriteLine("Straight");
            }
            else 
            {
                Console.WriteLine("Nothing");
            }
            
        }
    }
}
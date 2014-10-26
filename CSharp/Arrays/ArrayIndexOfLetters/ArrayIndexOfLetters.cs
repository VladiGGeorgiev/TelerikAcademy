/*Write a program that creates an array containing
 * all letters from the alphabet (A-Z). Read a word 
 * from the console and print the index of each of 
 * its letters in the array.
*/
using System;

class ArrayIndexOfLetters
{
    static void Main()
    {
        int[] letters = new int[26];

        //Initialize every letter code
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i] = 'a' + i;
        }

        //Read the word from the console
        string word = Console.ReadLine();
        word = word.ToLower(); 

        //Find every letter position in alphabet(array) by binary search.
        for (int i = 0; i < word.Length; i++)
        {
            int middleElement = 0;
            int firstElement = 0;
            int lastElement = letters.Length - 1;

            while (firstElement <= lastElement)
            {
                middleElement = (firstElement + lastElement) / 2;

                if (word[i] < letters[middleElement])
                {
                    lastElement = middleElement - 1;
                }
                else if (word[i] > letters[middleElement])
                {
                    firstElement = middleElement + 1;
                }
                else // Print letter position int alphabet. Starting from 1 not from 0.
                {
                    Console.WriteLine("Letter {0} in alphabet is at position: {1}", word[i], middleElement + 1);
                    break;
                }
            }
        }
    }
}
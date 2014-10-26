/*Write a program to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d).
Example of incorrect expression: )(a+b)).
*/

namespace CheckExpresionsBrackets
{
    using System;

    public class CheckExpresionsBrackets
    {
        public static void Main(string[] args)
        {
            string expression = "(a+b)/5-d)";

            int bracketsCounter = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    bracketsCounter++;
                }
                else if (expression[i] == ')')
                {
                    bracketsCounter--;
                }

                if (bracketsCounter < 0)
                {
                    break;
                }
            }

            if (bracketsCounter == 0)
            {
                Console.WriteLine("Your expression is correct");
            }
            else
            {
               Console.WriteLine("Incorrect expression! Look your brackets."); 
            }
        }
    }
}

using System;
using System.Numerics;

namespace Brackets
{
    class Brackets
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            int length = expression.Length;
            long[,] table = new long[length + 1, length + 2];
            table[0, 0] = 1;
            for (int i = 1; i <= length; i++)
            {
                if (expression[i - 1] == '(')
                {
                    table[i, 0] = 0;
                }
                else
                {
                    table[i, 0] = table[i - 1, 1];
                }

                for (int j = 1; j <= length; j++)
                {
                    if (expression[i - 1] == '(')
                    {
                        table[i, j] = table[i - 1, j - 1];
                    }
                    else if (expression[i-1] == ')')
	                {
		                table[i, j] = table[i-1, j+1];
	                }
                    else
	                {
                        table[i,j] = table[i - 1, j - 1] + table[i-1, j+1];
	                }
                }
            }

            Console.WriteLine(table[length,0]);
        }
    }
}

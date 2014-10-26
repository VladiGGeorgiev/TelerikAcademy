using System;

class PrintASCIISymbols
{
    static void Main(string[] args)
    {
        char symbol;
        for (int i = 0; i < 256; i++)
        {
            symbol = (char)i;
            Console.WriteLine("Code {0} is: {1}", i, symbol);
        }
    }
}


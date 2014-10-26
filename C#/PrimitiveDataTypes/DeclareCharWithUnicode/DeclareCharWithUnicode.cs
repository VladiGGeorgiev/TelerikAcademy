using System;

class DeclareCharWithUnicode
{
    static void Main(string[] args)
    {
        char a = (char)0x48;
        Console.WriteLine(a);
        char b = (char)72;
        Console.WriteLine(b);
        char c = '\u0048';
        Console.WriteLine(c);

    }
}

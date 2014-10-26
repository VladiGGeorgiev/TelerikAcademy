using System;

class CopyrightTriangle
{
    static void Main(string[] args)
    {
        char copyRight = '\u00A9';
        Console.WriteLine("    " + copyRight);
        Console.WriteLine("  " + copyRight + " " + copyRight + " " + copyRight);
        Console.WriteLine(copyRight + " " + copyRight + " " + copyRight + " " + copyRight + " " + copyRight);
    }
}

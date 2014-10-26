using System;

class TextAssignedStrings
{
    static void Main(string[] args)
    {
        string firstVarible = "The \"use\" of quotations causes difficulties.";
        string secondVariable = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(firstVarible);
        Console.WriteLine(secondVariable);
    }
}

using System;

class HelloWorldTypeCasting
{
    static void Main(string[] args)
    {
        string first = "Hello";
        string second = "World!";
        object twice = first + " " + second;
        string final = (string)twice;
        Console.WriteLine(final);
    }
}


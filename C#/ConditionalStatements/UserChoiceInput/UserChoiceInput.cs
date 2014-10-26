using System;

class UserChoiceInput
{
    static void Main()
    {
        Console.WriteLine("Insert a number.");
        Console.WriteLine("1 For Integer.");
        Console.WriteLine("2 For Floatting point number.");
        Console.WriteLine("3 For String.");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                {
                    Console.Write("Insert a variable type integer: ");
                    int variable = int.Parse(Console.ReadLine());
                    variable += 1;
                    Console.WriteLine("The variable is: " + variable);
                }   
                break;
            case 2:
                {
                    Console.Write("Insert a floating point number: ");
                    double number = double.Parse(Console.ReadLine());
                    number += 1;
                    Console.WriteLine("The floating point number is: " + number);
                }
                break;
            case 3:
                {
                    Console.Write("Insert a text:");
                    string text = Console.ReadLine();
                    Console.WriteLine("Text is:" + text + "*");
                } 
                break;
            default:
                Console.WriteLine("Insert number from 1 to 3:");
                break;
        }
    }
}
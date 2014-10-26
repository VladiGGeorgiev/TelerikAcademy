using System;

class ChangeVariableValues
{
    static void Main(string[] args)
    {
        //Change with third variable
        int a = 10;
        int b = 15;
        int change = a;
        a = b;
        b = change;

        //Change without third variable
        a = a + b;
        b = a - b;
        a = a - b;
    }
}

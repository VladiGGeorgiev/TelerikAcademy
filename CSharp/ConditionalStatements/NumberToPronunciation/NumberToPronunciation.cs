using System;

class NumberToPronunciation
{
    static void Main()
    {
        Console.WriteLine("Insert a number from 1 to 999: ");
        int number = int.Parse(Console.ReadLine());

        int unitDigit = number % 10;
        int tensDigit = (number / 10) % 10;
        int hundredsDigit = number / 100;

        if (number < 10)
        {
            Console.WriteLine(UnitsAndHundreds(unitDigit));
        }
        else if (number > 9 && number < 20)
        {
            Console.WriteLine(SpecialNumbers(number)); 
        }
        else if (number > 19 && number < 100)
        {
            Console.WriteLine("{0} {1}", TensNumbers(tensDigit), UnitsAndHundreds(unitDigit));
        }

        else if (number > 99)
        {
            if (tensDigit > 0 && tensDigit < 2)
            {
                Console.WriteLine("{0} hundred and {1}", 
                    UnitsAndHundreds(hundredsDigit), SpecialNumbers(tensDigit * 10 + unitDigit));
            }

            else if (number % 100 != 0 && tensDigit != 1)
            {
                Console.WriteLine("{0} hundred and {1}{2}", 
                    UnitsAndHundreds(hundredsDigit), TensNumbers(tensDigit), UnitsAndHundreds(unitDigit) );
            }
            else
            {
                Console.WriteLine("{0} hundred {1}{2}", 
                    UnitsAndHundreds(hundredsDigit), TensNumbers(tensDigit), UnitsAndHundreds(unitDigit) );
            }
        }
    }

    static string SpecialNumbers(int number)
    {
        string str = "";
        switch (number)
        {
            case 10: str = "Ten";
                break;
            case 11: str = "Eleven";
                break;
            case 12: str = "Twelve";
                break;
            case 13: str = "Thirteen";
                break;
            case 14: str = "Fourteen";
                break;
            case 15: str = "Fifteen";
                break;
            case 16: str = "Sixteen";
                break;
            case 17: str = "Seventeen";
                break;
            case 18: str = "Eighteen";
                break;
            case 19: str = "Nineteen";
                break;
        }
        return str;
    }

    static string TensNumbers(int number)
    {
        string str = "";
        switch (number)
        {
            case 2: str = "Twenty";
                break;
            case 3: str = "Thirty";
                break;
            case 4: str = "Forty";
                break;
            case 5: str = "Fifty";
                break;
            case 6: str = "Sixty";
                break;
            case 7: str = "Seventy";
                break;
            case 8: str = "Eighty";
                break;
            case 9: str = "Ninety";
                break;
        }
        return str;
    }

    static string UnitsAndHundreds(int tensDigit)
    {
        string str = "";
        switch (tensDigit)
        {
            case 0: str = "";
                break;
            case 1: str = "One";
                break;
            case 2: str = "Two";
                break;
            case 3: str = "Three";
                break;
            case 4: str = "Four";
                break;
            case 5: str = "Five";
                break;
            case 6: str = "Six";
                break;
            case 7: str = "Seven";
                break;
            case 8: str = "Eight";
                break;
            case 9: str = "Nine";
                break;
        }
        return str;
    }
}
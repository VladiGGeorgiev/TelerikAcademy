using System;

class Program
{
    static void Main(string[] args)
{
        decimal number = decimal.Parse(Console.ReadLine());
        string stringNumber = number.ToString();
        string newString = "";
        if (stringNumber.Length == 6)
        {

            newString += stringNumber[0].ToString();
            newString += stringNumber[1].ToString();
            newString += stringNumber[2].ToString();
            newString = stringNumber[stringNumber.Length - 1].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();
            newString = stringNumber[stringNumber.Length - 2].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();
            newString = stringNumber[stringNumber.Length - 3].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();
            Console.WriteLine(decimal.Parse(newString));
        }
        else if (stringNumber.Length == 5)
        {

            newString += stringNumber[0].ToString();
            newString += stringNumber[1].ToString();

            newString = stringNumber[stringNumber.Length - 1].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();
            newString = stringNumber[stringNumber.Length - 2].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();
            newString = stringNumber[stringNumber.Length - 3].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();
            Console.WriteLine(decimal.Parse(newString));
        }
        else if (stringNumber.Length == 4)
        {
            newString += stringNumber[0].ToString();

            newString = stringNumber[stringNumber.Length - 1].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();
            newString = stringNumber[stringNumber.Length - 2].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();
            newString = stringNumber[stringNumber.Length - 3].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();
            Console.WriteLine(decimal.Parse(newString));
        }
        else if (stringNumber.Length == 3)
        {
            newString = stringNumber[stringNumber.Length - 1].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();
            newString = stringNumber[stringNumber.Length - 2].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();
            newString = stringNumber[stringNumber.Length - 3].ToString() + newString;
            newString = (decimal.Parse(newString)).ToString();

            if (decimal.Parse(stringNumber) % 100 == 0)
            {
                Console.WriteLine(newString[0]);
            }
            else
            {
                Console.WriteLine(decimal.Parse(newString));
            }
        }
        else if (stringNumber.Length == 2)
        {
            newString += stringNumber[stringNumber.Length - 1].ToString();
            newString += stringNumber[stringNumber.Length - 2].ToString();
            Console.WriteLine(decimal.Parse(newString));
        }
        else if (stringNumber.Length == 1)
        {
            newString = stringNumber[0].ToString();
            Console.WriteLine(decimal.Parse(newString));
        }
    }
}

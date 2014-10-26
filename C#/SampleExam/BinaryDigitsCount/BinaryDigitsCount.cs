using System;

class BinaryDigitsCount
{

    static void Main()
    {
        short B = short.Parse(Console.ReadLine());
        short N = short.Parse(Console.ReadLine());

        uint number = 0;
        string binNumber = "";

        int bitCounter = 0;

        for (int i = 0; i < N; i++)
        {
            number = uint.Parse(Console.ReadLine());
            binNumber = Convert.ToString(number, 2);

            for (int j = 0; j < binNumber.Length; j++)
            {
                if (B == 1)
                {
                    if (binNumber[j] == '1')
                    {
                        bitCounter++;
                    }
                }
                else
                {
                    if (binNumber[j] == '0')
                    {
                        bitCounter++;
                    }
                }
            }
            Console.WriteLine(bitCounter);
            bitCounter = 0;
        }
    }
}

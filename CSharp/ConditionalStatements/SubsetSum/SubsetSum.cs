using System;

class SubsetSum
{
    static void Main()
    {
        //Declare array
        int[] numbers = new int[5];
        int numberLength = numbers.Length;

        //Read the numbers
        for (int i = 0; i < numberLength; i++)
        {
            Console.Write("Insert number [{0}]: ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }
        
        bool check = true;
        int count = 0;
        //Check sum of 1 and all numbers
        for (int i = 0; i < numberLength; i++)
        {
            if (numbers[i] == 0)
            {
                Console.WriteLine("The subset sum of {0} is 0.", numbers[i]);
            }
            count += numbers[i];
            check = count == 0;
            if (check)
	        {
                Console.WriteLine("The subset sum of all numbers is 0.");
	        }
        }

        
        for (int i = 0; i < numberLength - 1; i++)
        {
            for (int j = i + 1; j < numberLength; j++)
            {
                check = numbers[i] + numbers[j] == 0; //Check for subset of two numbers
                if (check)
                {
                    Console.WriteLine("The subset sum of {0} + {1} is 0.", numbers[i], numbers[j]);
                }

                for (int k = j + 1; k < numberLength; k++)
                {
                    check = numbers[i] + numbers[j] + numbers[k] == 0; //Check for subset of three numbers
                    if (check)
                    {
                        Console.WriteLine("The subset sum of {0} + {1} + {2} is 0.", 
                            numbers[i], numbers[j], numbers[k]);
                    }

                    for (int l = k + 1; l < numberLength; l++)
                    {
                        check = numbers[i] + numbers[j] + numbers[k] + numbers[l] == 0; //Check for subset of four numbers
                        if (check)
                        {
                            Console.WriteLine("The subset sum of {0} + {1} + {2} + {3} is 0.", 
                                numbers[i], numbers[j], numbers[k], numbers[l]);
                        }
                    }
                }
            }
        }
    }
}

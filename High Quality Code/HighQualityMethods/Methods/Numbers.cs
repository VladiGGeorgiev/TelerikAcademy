namespace Methods
{
    using System;

    public class Numbers
    {
        /// <summary>
        ///     Convert integer representation of digit to it's English representation
        /// </summary>
        /// <param name="value">Digit between 0 - 9</param>
        /// <returns>English word</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Throw if the value is not in range.</exception>
        public static string ConvertDigitToText(int value)
        {
            string digit;
            switch (value)
            {
                case 0: digit = "zero";
                    break;
                case 1: digit = "one";
                    break;
                case 2: digit = "two";
                    break;
                case 3: digit = "three";
                    break;
                case 4: digit = "four";
                    break;
                case 5: digit = "five";
                    break;
                case 6: digit = "six";
                    break;
                case 7: digit = "seven";
                    break;
                case 8: digit = "eight";
                    break;
                case 9: digit = "nine";
                    break;
                default: throw new ArgumentOutOfRangeException("Number must be in 0-9 range!");
            }

            return digit;
        }

        /// <summary>
        ///     Find max element in sequence of elements
        /// </summary>
        /// <param name="elements">Sequence of elements</param>
        /// <returns>Max element of sequence</returns>
        public static int MaxElement(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Arguments is null!");   
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("No arguments!");
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static void PrintNumberWithPrecisionTwo(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintNumberAsPercent(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintNumberWithAlignment(double number)
        {
            Console.WriteLine("{0,8}", number);
        }
    }
}

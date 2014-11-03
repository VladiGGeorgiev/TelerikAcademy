namespace Statistics
{
    using System;

    /// <summary>
    /// Statistics on sequences of elements
    /// </summary>
    public class SequenceStatistics
    {
        private double[] sequence;

        /// <summary>
        /// Initializes a new instance of the SequenceStatistics class.
        /// </summary>
        /// <param name="sequence">Input sequence</param>
        public SequenceStatistics(double[] sequence)
        {
            this.sequence = sequence;
        }

        public double[] Sequence
        {
            get
            {
                return this.sequence;
            }

            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Invalid array. It can't be empty.");
                }

                this.sequence = value;
            }
        }
  
        /// <summary>
        ///     Print on console Average value of array
        /// </summary>
        public void PrintAverageValue()
        {
            string result = "Average value is: " + this.GetAverageValue(this.sequence);
            Console.WriteLine(result);
        }
        
        /// <summary>
        ///     Print on console min value of array
        /// </summary>
        public void PrintMinElement()
        {
            string result = "Minumum value is: " + this.GetMinValue(this.sequence);
            Console.WriteLine(result);
        }
        
        /// <summary>
        ///     Print on console max value of array
        /// </summary>
        public void PrintMaxElement()
        {
            string result = "Maximum value is: " + this.GetMaxValue(this.sequence);
            Console.WriteLine(result);
        }

        private double GetAverageValue(double[] numbers)
        {
            double numbersSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                numbersSum += numbers[i];
            }

            double averageValue = numbersSum / numbers.Length;
            return averageValue;
        }

        private double GetMinValue(double[] numbers)
        {
            var minValue = double.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < minValue)
                {
                    minValue = numbers[i];
                }
            }

            return minValue;
        }

        private double GetMaxValue(double[] numbers)
        {
            double maxValue = double.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maxValue)
                {
                    maxValue = numbers[i];
                }
            }

            return maxValue;
        }
    }
}

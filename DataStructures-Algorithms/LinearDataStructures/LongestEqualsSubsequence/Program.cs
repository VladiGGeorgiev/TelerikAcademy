using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestEqualsSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, 5, 2, 3, 3, 3, 2, 4, 4, 4, 4, 2, 5, 1, 3, 2 };

            var sequenceEquals = FindLongestEqualSubsequence(numbers);

            Console.WriteLine(string.Join(" ", sequenceEquals));
        }

        public static IList<int> FindLongestEqualSubsequence(IList<int> numbers)
        {
            int startSequenceIndex = 0;
            int sequenceLengthCounter = 0;
            int maxSequenceCounter = 0;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1] && sequenceLengthCounter == 0)
                {
                    startSequenceIndex = i;
                    sequenceLengthCounter++;
                }
                else if (numbers[i] == numbers[i + 1])
                {
                    sequenceLengthCounter++;
                }
                else
                {
                    sequenceLengthCounter = 0;
                }

                if (sequenceLengthCounter > maxSequenceCounter)
                {
                    maxSequenceCounter = sequenceLengthCounter;
                }
            }

            List<int> equalsSequence = new List<int>();
            for (int i = startSequenceIndex; i <= startSequenceIndex + maxSequenceCounter; i++)
            {
                equalsSequence.Add(numbers[i]);
            }

            return equalsSequence;
        }
    }
}

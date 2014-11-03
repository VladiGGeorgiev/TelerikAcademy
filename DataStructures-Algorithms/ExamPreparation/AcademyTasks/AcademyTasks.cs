using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyTasks
{
    class AcademyTasks
    {
        static short[] pleasentness;
        static int minSteps;
        static short variety;
        static int maxIndex;

        static void Main(string[] args)
        {
            ReadInput();

            variety = short.Parse(Console.ReadLine());

            int min = pleasentness[0];
            int max = pleasentness[0];
            for (int i = 0; i < pleasentness.Length; i++)
            {
                min = Math.Min(min, pleasentness[i]);
                max = Math.Max(max, pleasentness[i]);

                if (max - min >= variety)
                {
                    maxIndex = i;
                    break;
                }
            }

            FindMinimumSolvedProblems(0, 1, pleasentness[0], pleasentness[0]);
            Console.WriteLine(minSteps);
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();
            string[] pleasentnessString = line.Split(new char[]
            {
                ',',
                ' '
            }, StringSplitOptions.RemoveEmptyEntries);
            pleasentness = new short[pleasentnessString.Length];
            for (int i = 0; i < pleasentnessString.Length; i++)
            {
                pleasentness[i] = short.Parse(pleasentnessString[i]);
            }

            minSteps = pleasentness.Length;
        }

        private static void FindMinimumSolvedProblems(int index, int steps, int min, int max)
        {
            if (index > maxIndex)
            {
                return;
            }

            if (max - min >= variety)
            {
                minSteps = steps;
                return;
            }

            for (byte i = 2; i >= 1; i--)
            {
                if (index + i < pleasentness.Length)
                {
                    FindMinimumSolvedProblems(index + i, steps + 1, 
                        Math.Min(min, pleasentness[index + i]),
                        Math.Max(max, pleasentness[index + i]));
                }

                if (minSteps != pleasentness.Length)
                {
                    return;
                }
            }
        }
    }
}
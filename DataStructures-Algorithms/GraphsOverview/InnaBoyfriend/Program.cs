using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnaBoyfriend
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string playboysName = string.Empty;
            int playboyPoints = 0;
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split(' ');
                string name = tokens[0];
                string points = tokens[1];

                int currentBoyPoints = 0;

                for (int j = 0; j < points.Length; j++)
                {
                    currentBoyPoints += points[j] - '0';   
                }

                if (currentBoyPoints > playboyPoints)
                {
                    playboyPoints = currentBoyPoints;
                    playboysName = name;
                }
                currentBoyPoints = 0;
            }

            Console.WriteLine(playboysName);
        }
    }
}

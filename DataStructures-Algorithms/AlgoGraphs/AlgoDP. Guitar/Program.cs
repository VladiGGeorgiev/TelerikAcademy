using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDP.Guitar
{
    class Program
    {
        static void Main(string[] args)
        {
            int songsNumber = int.Parse(Console.ReadLine());
            string[] songsStr = Console.ReadLine().Split(' ');
            int[] songs = new int[songsStr.Length];
            for (int i = 0; i < songs.Length; i++)
            {
                songs[i] = int.Parse(songsStr[i]);
            }

            int startVolume = int.Parse(Console.ReadLine());
            int maxVolume = int.Parse(Console.ReadLine());

            bool[,] table = new bool[songsNumber + 1, maxVolume + 1];
            table[0, startVolume] = true;

            for (int row = 0; row < table.GetLength(0) - 1; row++)
			{
			    for (int col = 0; col < table.GetLength(1); col++)
			    {
			        if (table[row, col])
	                {
                        if (col - songs[row] >= 0)
	                    {
                            table[row + 1, col - songs[row]] = true;
	                    }
                        if (col + songs[row] < table.GetLength(1))
	                    {
		                     table[row + 1, col + songs[row]] = true;
	                    }
	                }
			    }
			}

            int result = -1;
            for (int i = table.GetLength(1) - 1; i >= 0; i--)
            {
                if (table[table.GetLength(0) - 1, i])
	            {
                    result = i;
                    break;
	            }
            }

            Console.WriteLine(result);
        }
    }
}

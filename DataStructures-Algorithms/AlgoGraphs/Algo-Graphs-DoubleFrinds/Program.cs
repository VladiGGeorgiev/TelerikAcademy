using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_Graphs_DoubleFrinds
{
    class Program
    {
        static short c;
        static bool[,] matrix;
        static int maxCounter = int.MinValue;

        static void Main(string[] args)
        {
            #region Read input
            c = short.Parse(Console.ReadLine());
            matrix = new bool[c, c];
            for (int i = 0; i < c; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < c; j++)
                {
                    if (line[j] == 'Y')
                    {
                        matrix[i, j] = true;
                    }
                }
            }
            #endregion

            List<List<int>> persons = new List<List<int>>();
            for (int i = 0; i < c; i++)
            {
                persons.Add(new List<int>());
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j])
                    {
                        persons[i].Add(j);
                    }
                }
            }

            for (int i = 0; i < persons.Count; i++)
            {
                int counter = 0;
                bool[] visitedFriends = new bool[c];
                visitedFriends[i] = true;

                foreach (var friend in persons[i])
                {
                    if (!visitedFriends[friend])
                    {
                        counter++;
                        visitedFriends[friend] = true;
                    }

                    foreach (var friendsOfFriend in persons[friend])
                    {
                        if (!visitedFriends[friendsOfFriend])
                        {
                            counter++;
                            visitedFriends[friendsOfFriend] = true;
                        }
                    }
                }
                
                if (counter > maxCounter)
                {
                    maxCounter = counter;
                }
            }

            Console.WriteLine(maxCounter);
        }
    }
}

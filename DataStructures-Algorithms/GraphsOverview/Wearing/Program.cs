using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wearing
{
    class Program
    {
        static void Main(string[] args)
        {
            int bagSize = int.Parse(Console.ReadLine());
            int roomsCount = int.Parse(Console.ReadLine());

            string[] roomsSize = Console.ReadLine().Split(' ');
            int maxRoomGrabbedCount = 0;
            for (int i = 0; i < roomsSize.Length; i++)
            {
                int currentRoomSize = int.Parse(roomsSize[i]);
                bagSize -= currentRoomSize;

                if (bagSize < 0)
                {
                    break;
                }

                maxRoomGrabbedCount++;
            }

            Console.WriteLine(maxRoomGrabbedCount);
        }
    }
}

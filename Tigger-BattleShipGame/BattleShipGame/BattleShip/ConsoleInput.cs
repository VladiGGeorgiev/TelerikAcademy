using System;
using BattleShip.Common;

namespace BattleShip
{
    public class ConsoleInput : IUserInput
    {
        public Ship ReadInputShip(int length)
        {
            Position start = new Position();
            //Console.WriteLine("Enter: XCoord YCoord");
            string line = Console.ReadLine().ToLower();
            //for unit testing 
            //string line="2 3";
            //string line = "2 , ,/ | 3";
            string[] arrLine = line.Split(new char[]{' ',',','|','/'}, StringSplitOptions.RemoveEmptyEntries);
            start.X = int.Parse(arrLine[0]);
            start.Y = int.Parse(arrLine[1]);
            //Console.WriteLine("Enter alignment: vertical or horizontal");
            Alignment alignment;
            if (Console.ReadLine().ToLower()=="vertical")
            //for unit testing
            //if ("vertical"=="vertical")
            //if ("Vertical".ToLower()=="vertical")
            {
                alignment = Alignment.Vertical;
            }
            else
            {
                alignment = Alignment.Horizontal;
            }
            return new Ship(start, length, alignment);
        }

        public Position ReadShootCommand()
        {
            string line = Console.ReadLine().ToLower();
            //string line="3 6";
            //string line = "3  6";
            string[] strPos = line.Split(new char[] { ' ', ',','|','/' }, StringSplitOptions.RemoveEmptyEntries);
            return new Position(int.Parse(strPos[0]), int.Parse(strPos[1]));
        }
    }
}

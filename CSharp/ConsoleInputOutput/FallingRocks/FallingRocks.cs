using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FallingRocks
{
    class Rocks 
    {
        public char rockSymbol { get; set; }
        public int rockPositionX { get; set; }
        public int rockPositionY { get; set; }

        public Rocks(char rock, int x, int y) 
        {
            this.rockSymbol = rock;
            this.rockPositionX = x;
            this.rockPositionY = y;
        }
    }

    class FallingRocks
    {
        static int playerPadSize = 3;
        static string playerPad = "-----";
        static int playerPosition = 5;

        static int rockPositionX = 0;
        static int rockPositionY = 0;

        static char[] rockTypes = { '@', '$', '^', '*', '&', '+', '%', '#', '!', '.', ';', };

        static Random randomNumber = new Random();

        static void Main()
        {
            SetPlayerPosition();
            ConsoleOptions();

            List<Rocks> rocksList = new List<Rocks>();

            while (true)
            {
                Console.Clear();

                MovePlayer();
                DrawPlayer();

                rocksList.Add(GenerateRocks());

                DrawRock(rocksList);
                CheckFallRock(rocksList);


                Thread.Sleep(150);
            }
        }

        static void CheckFallRock(List<Rocks> rocksList)
        {
            for (int i = 0; i < rocksList.Count; i++)
            {
                if (rocksList[i].rockPositionY == Console.WindowHeight - 1)
                {
                    if (rocksList[i].rockPositionX >= playerPosition && 
                        rocksList[i].rockPositionX <= playerPosition + playerPadSize - 1)
                    {
                        string gameOver = "Game over dude!";
                        Console.SetCursorPosition(Console.WindowWidth / 2 - gameOver.Length / 2, Console.WindowHeight / 2);
                        Console.WriteLine(gameOver);
                        Console.ReadKey();
                    }

                }
            }
        }

        static Rocks GenerateRocks()
        {
            rockPositionX = randomNumber.Next(0, Console.WindowWidth);
            rockPositionY = 0;

            char rockType = rockTypes[randomNumber.Next(0, rockTypes.Length)];

            Rocks rock = new Rocks(rockType, rockPositionX, rockPositionY);
            return rock;
        }



        static void DrawRock(List<Rocks> rocks)
        {
            for (int i = 0; i < rocks.Count ; i++)
            {


                if (rocks[i].rockPositionY < Console.WindowHeight)
                {               
                    Console.SetCursorPosition(rocks[i].rockPositionX, rocks[i].rockPositionY);
                    Console.Write(rocks[i].rockSymbol);
                    rocks[i].rockPositionY++;
                }
                else
                {
                    rocks.Remove(new Rocks(rocks[i].rockSymbol,rocks[i].rockPositionX,rocks[i].rockPositionY));
                }
            }
        }

        static void SetPlayerPosition()
        {
            playerPosition = Console.WindowWidth / 2 - playerPadSize / 2;
        }

        static void ConsoleOptions()
        {
            Console.SetWindowSize(80, 50);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.ForegroundColor = ConsoleColor.Red;
        }

        static void MovePlayer()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    MoveLeft();
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    MoveRight();
                }
            }
        }

        static void MoveRight()
        {
            if (playerPosition <= Console.WindowWidth - 1 - playerPadSize)
            {
                playerPosition++;
            }
        }

        static void MoveLeft()
        {
            if (playerPosition > 0 )
            {
                playerPosition--;
            }
        }

        static void DrawPlayer()
        {
            Console.SetCursorPosition(playerPosition, Console.WindowHeight - 1);

            Console.Write(playerPad);
            //Console.SetCursorPosition(playerPosition, Console.WindowHeight - 1);
            //for (int i = playerPosition; i < playerPosition + playerPadSize; i++)
            //{
            //    Console.Write('*');
            //}
        }
    }
}

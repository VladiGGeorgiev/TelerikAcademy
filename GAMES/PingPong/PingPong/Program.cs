using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong
{
    class Program
    {
        static int firstPlayerPadSize = 8;
        static int secondPlayerPadSize = 3;

        static int firstPlayerPosition = 5;
        static int secondPlayerPosition = 7;

        static int ballPositionX = 0;
        static int ballPositionY = 0;

        static int firstPlayerPoints = 0;
        static int secondPlayerPoints = 0;

        static bool ballDirectionUp = true;
        static bool ballDirectionRight = true;

        static string firstPlayerName = "Desi-Shanel";
        static string secondPlayerName = "Computer";

        static Random randomGenerator = new Random();

        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            firstPlayerName = Console.ReadLine();

            RemoveScrollBars();
            SetPlayersPositions();
            SetBallPositions();

            while (true)
            {

                Console.Clear();

                DrawFirstPlayer();
                DrawSecondPlayer();

                FirstPlayerMove();
                SecondPlayerAIMove();

                DrawBall();
                MoveBall();

                DrawResult();
                Thread.Sleep(40);
            }
        }

        private static void FirstPlayerMove()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    MoveFirstPlayerUp();
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    MoveFirstPlayerDown();
                }
            }
        }

        private static void MoveBall()
        {
            if (ballPositionY == 0)
            {
                ballDirectionUp = false;
            }

            if (ballPositionY == Console.WindowHeight - 1)
            {
                ballDirectionUp = true;
            }
            if (ballPositionX == Console.WindowWidth - 1)
            {
                SetBallPositions();
                ballDirectionRight = false;
                firstPlayerPoints++;
                Console.SetCursorPosition(Console.WindowWidth / 2 - firstPlayerName.Length, Console.WindowHeight / 2);
                Console.Write("{0} wins!", firstPlayerName);
                Console.ReadKey();
            }
            if (ballPositionX == 0)
            {
                SetBallPositions();
                ballDirectionRight = true;
                secondPlayerPoints++;
                Console.SetCursorPosition(Console.WindowWidth / 2 - secondPlayerName.Length, Console.WindowHeight / 2);
                Console.Write("{0} wins!", secondPlayerName);
                Console.ReadKey();
            }

            if (ballPositionX < 3)
            {
                if (ballPositionY >= firstPlayerPosition && 
                    ballPositionY <= firstPlayerPosition + firstPlayerPadSize)
                {
                    ballDirectionRight = true;
                }
            }

            if (ballPositionX >= (Console.WindowWidth - 1) - 2)
            {
                if (ballPositionY >= secondPlayerPosition &&
                    ballPositionY <= secondPlayerPosition + secondPlayerPadSize)
                {
                    ballDirectionRight = false;
                }
            }

            if (ballDirectionUp)
            {
                ballPositionY--;
            }
            else
            {
                ballPositionY++;
            }
            if (ballDirectionRight)
            {
                ballPositionX++;
            }
            else
            {
                ballPositionX--;
            }
        }

        private static void SecondPlayerAIMove()
        {
            int random = randomGenerator.Next(1, 101);
            //if (random == 1)
            //{
            //    MoveSecondPlayerDown();
            //}
            //if (random == 0)
            //{
            //    MoveSecondPlayerUp();
            //}
            if (random < 60)
            {
                if (ballDirectionUp)
                {
                    MoveSecondPlayerUp();
                }
                else
                {
                    MoveSecondPlayerDown();
                }
            }
      
        }

        private static void MoveFirstPlayerDown()
        {
            if (firstPlayerPosition < (Console.WindowHeight - 1) - firstPlayerPadSize)
            {
                firstPlayerPosition++;
            }
        }

        private static void MoveFirstPlayerUp()
        {
            if (firstPlayerPosition > 0)
            {
                firstPlayerPosition--;
            }
        }

        private static void MoveSecondPlayerDown()
        {
            if (secondPlayerPosition < (Console.WindowHeight - 1) - secondPlayerPadSize)
            {
                secondPlayerPosition++;
            }
        }

        private static void MoveSecondPlayerUp()
        {
            if (secondPlayerPosition > 0)
            {
                secondPlayerPosition--;
            }
        }

        private static void DrawResult()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 
                (firstPlayerName.Length + secondPlayerName.Length + 5) / 2, 0);
            Console.WriteLine("{0} {1}:{2} {3}", firstPlayerName, firstPlayerPoints, secondPlayerPoints, secondPlayerName);
        }

        private static void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, 'D');
        }

        private static void SetPlayersPositions()
        {
            firstPlayerPosition = Console.WindowHeight / 2 - firstPlayerPadSize / 2;
            secondPlayerPosition = Console.WindowHeight / 2 - secondPlayerPadSize / 2;
        }

        private static void SetBallPositions()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }


        private static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y <= secondPlayerPosition + secondPlayerPadSize; y++)
            {
                PrintAtPosition(Console.WindowWidth - 1, y, '*');
            }
        }

        static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y <= firstPlayerPosition + firstPlayerPadSize; y++)
            {
                PrintAtPosition(0, y, '*');
            }
        }

        static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        static void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
    }
}

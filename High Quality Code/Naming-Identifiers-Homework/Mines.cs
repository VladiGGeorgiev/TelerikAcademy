namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Mines
    {
        private const int MaxPlayerPoints = 35;
        private static int playerPoints = 0;

        private static List<Result> champions = new List<Result>(6);
        
        private static bool isBombHit = false;
        private static bool isFirstTurn = true;
        private static bool isWinGame = false;

        private static int row = 0;
        private static int column = 0;

        private static char[,] field = GenerateField();
        private static char[,] bombs = GenerateBombs();

        internal static void Main(string[] args)
        {
            string inputCommand = string.Empty;

            do
            {
                if (isFirstTurn)
                {
                    Console.WriteLine("Lets play Minesweeper." +
                        " Commands: 'top' - show ranking, 'restart' - starts new game, 'exit' - ends the game!");
                    DisplayField(field);
                    isFirstTurn = false;
                }

                Console.Write("Input row and column, separated by space: ");
                inputCommand = Console.ReadLine().Trim();

                if (inputCommand.Length >= 3)
                {
                    if (int.TryParse(inputCommand[0].ToString(), out row) &&
                        int.TryParse(inputCommand[2].ToString(), out column) &&
                        row <= field.GetLength(0) &&
                        column <= field.GetLength(1))
                    {
                        inputCommand = "turn";
                    }
                }

                ProcessCommand(inputCommand);

                if (isBombHit)
                {
                    DisplayField(bombs);
                    Console.Write("\nGame over! Your ponts: {0}. " + "Enter your name: ", playerPoints);
                    string nickname = Console.ReadLine();

                    Result currentPlayerResult = new Result(nickname, playerPoints);
                    if (champions.Count < 5)
                    {
                        champions.Add(currentPlayerResult);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < currentPlayerResult.Points)
                            {
                                champions.Insert(i, currentPlayerResult);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Result result1, Result result2) => result2.Name.CompareTo(result1.Name));
                    champions.Sort((Result result1, Result result2) => result2.Points.CompareTo(result1.Points));
                    DisplayRankList(champions);

                    field = GenerateField();
                    bombs = GenerateBombs();
                    playerPoints = 0;
                    isBombHit = false;
                    isFirstTurn = true;
                }

                if (isWinGame)
                {
                    Console.WriteLine("\nCongratulations! You win!");
                    DisplayField(bombs);

                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();

                    Result currentResult = new Result(name, playerPoints);
                    champions.Add(currentResult);
                    DisplayRankList(champions);

                    field = GenerateField();
                    bombs = GenerateBombs();
                    playerPoints = 0;
                    isWinGame = false;
                    isFirstTurn = true;
                }
            }
            while (inputCommand != "exit");
            Console.WriteLine("Thank you for playing our game!");
            Console.Read();
        }

        /// <summary>
        ///     Process commands for make new turn, display rank list, restart game and exit.
        /// </summary>
        /// <param name="inputCommand">Command inserted by user</param>
        private static void ProcessCommand(string inputCommand)
        {
            switch (inputCommand)
            {
                case "top":
                    DisplayRankList(champions);
                    break;
                case "restart":
                    field = GenerateField();
                    bombs = GenerateBombs();
                    DisplayField(field);

                    isBombHit = false;
                    isFirstTurn = false;
                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    break;
                case "turn":
                    if (bombs[row, column] != '*')
                    {
                        if (bombs[row, column] == '-')
                        {
                            MakeTurn(field, bombs, row, column);
                            playerPoints++;
                        }

                        if (MaxPlayerPoints == playerPoints)
                        {
                            isWinGame = true;
                        }
                        else
                        {
                            DisplayField(field);
                        }
                    }
                    else
                    {
                        isBombHit = true;
                    }

                    break;
                default:
                    Console.WriteLine("\nInvalid command!\n");
                    break;
            }
        }

        /// <summary>
        ///     Display on console rank list of best players.
        /// </summary>
        /// <param name="results">Container of best played results.</param>
        private static void DisplayRankList(List<Result> results)
        {
            Console.WriteLine("\nResults:");
            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} points", i + 1, results[i].Name, results[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The ranking is empty!\n");
            }
        }

        /// <summary>
        ///     When you make turn and "click" on some cell, where no bomb.
        /// </summary>
        /// <param name="field">Field matrix</param>
        /// <param name="bombs">matrix with all bombs</param>
        /// <param name="row">Player turn position Y</param>
        /// <param name="col">Player turn position X</param>
        private static void MakeTurn(char[,] field, char[,] bombs, int row, int col)
        {
            char bombsAroundCell = CountBombsAroundCell(bombs, row, col);
            bombs[row, col] = bombsAroundCell;
            field[row, col] = bombsAroundCell;
        }

        /// <summary>
        ///     Display current field on console with indexes
        /// </summary>
        /// <param name="field">Current field</param>
        private static void DisplayField(char[,] field)
        {
            int fieldRows = field.GetLength(0);
            int fieldCols = field.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < fieldRows; row++)
            {
                Console.Write("{0} | ", row);

                for (int col = 0; col < fieldCols; col++)
                {
                    Console.Write(string.Format("{0} ", field[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        /// <summary>
        ///     Make new field with some sizes.
        /// </summary>
        /// <returns>Field filled with ?</returns>
        private static char[,] GenerateField()
        {
            int fieldRows = 5;
            int fieldCols = 10;
            char[,] field = new char[fieldRows, fieldCols];
            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldCols; j++)
                {
                    field[i, j] = '?';
                }
            }

            return field;
        }

        /// <summary>
        ///     Generate bombs on random positions in field
        /// </summary>
        /// <returns>Filled field with bombs</returns>
        private static char[,] GenerateBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] field = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            foreach (int randomNumber in randomNumbers)
            {
                int bombCol = randomNumber / cols;
                int bombRow = randomNumber % cols;

                if (bombRow == 0 && randomNumber != 0)
                {
                    bombCol--;
                    bombRow = cols;
                }
                else
                {
                    bombRow++;
                }

                field[bombCol, bombRow - 1] = '*';
            }

            return field;
        }

        /// <summary>
        ///     Fill field with numbers that shows how many bombs have around it.
        /// </summary>
        /// <param name="field">Field with bombs</param>
        private static void FillFieldWithNumbers(char[,] field)
        {
            int fieldWidth = field.GetLength(0);
            int fieldHeight = field.GetLength(1);

            for (int col = 0; col < fieldWidth; col++)
            {
                for (int row = 0; row < fieldHeight; row++)
                {
                    if (field[col, row] != '*')
                    {
                        char bombsAroundCell = CountBombsAroundCell(field, col, row);
                        field[col, row] = bombsAroundCell;
                    }
                }
            }
        }

        /// <summary>
        ///     Count how many bombs have around every cell in field
        /// </summary>
        /// <param name="field">Field</param>
        /// <param name="cellCol">Current cell col</param>
        /// <param name="cellRow">Current cell row</param>
        /// <returns>Number like char, that shows how many bombs have around it</returns>
        private static char CountBombsAroundCell(char[,] field, int cellCol, int cellRow)
        {
            int bombsAroundCell = 0;
            int fieldRows = field.GetLength(0);
            int fieldCols = field.GetLength(1);

            if (cellCol - 1 >= 0)
            {
                if (field[cellCol - 1, cellRow] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if (cellCol + 1 < fieldRows)
            {
                if (field[cellCol + 1, cellRow] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if (cellRow - 1 >= 0)
            {
                if (field[cellCol, cellRow - 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if (cellRow + 1 < fieldCols)
            {
                if (field[cellCol, cellRow + 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if ((cellCol - 1 >= 0) && (cellRow - 1 >= 0))
            {
                if (field[cellCol - 1, cellRow - 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if ((cellCol - 1 >= 0) && (cellRow + 1 < fieldCols))
            {
                if (field[cellCol - 1, cellRow + 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if ((cellCol + 1 < fieldRows) && (cellRow - 1 >= 0))
            {
                if (field[cellCol + 1, cellRow - 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if ((cellCol + 1 < fieldRows) && (cellRow + 1 < fieldCols))
            {
                if (field[cellCol + 1, cellRow + 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            return char.Parse(bombsAroundCell.ToString());
        }
    }
}
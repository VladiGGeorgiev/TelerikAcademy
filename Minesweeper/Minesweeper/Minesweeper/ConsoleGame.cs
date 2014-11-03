using Minesweeper.Common;
using Minesweeper.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class ConsoleGame : Game
    {
        private Field field;
        public ConsoleGame(int rows, int columns, int mines)
            : base(rows, columns, mines)
        {
            this.field = new Field(rows, columns, mines);
        }

        public override void Play()
        {
            ConsoleVisualizer visualizer = new ConsoleVisualizer(field);
            base.Play();
            string startMessage = "Welcome to the game “Minesweeper”. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
            Console.WriteLine(startMessage);
            
            while (true)
            {
                visualizer.VisualizeField();

                Console.Write("Enter row and column:");
                string inputLine = Console.ReadLine().ToLower().Trim();
                string[] command = inputLine.Split(' ');

                ProcessCommand(command);
            }
        }

        private void ProcessCommand(string[] command)
        {
            ConsoleVisualizer visualizer = new ConsoleVisualizer(field);
            
            if (command.Length == 1)
            {
                string gameCommand = command[0];

                switch (gameCommand)
                {
                    case "restart": Play();
                        break;
                    case "top": visualizer.VisualizeScore(this.Scores);
                        break;
                    case "exit": this.Exit();
                        break;
                    default: visualizer.VisualizeField();
                        break;
                }
            }
            else if (command.Length == 2)
            {
                int row = 0;
                int col = 0;
                bool tryParse = false;
                tryParse = (Int32.TryParse(command[0], out row) || tryParse);
                tryParse = (Int32.TryParse(command[1], out col) || tryParse);

                if (!tryParse)
                {
                    throw new CommandUnknownException();
                }

                if (field.RevealCell(row, col) == '*')
                {
                    field.MarkAndRevealEmptyFields('-');
                    field.RevealMines();
                    Console.WriteLine(field.ToString());
                    Console.WriteLine(String.Format("Booooom! You were killed by a mine. You revealed {0} cells without mines.", CurrentScore));
                    Console.Write("Please enter your name for the top scoreboard: ");
                    string playerName = Console.ReadLine();
                    Scores.Add(new Score(playerName, this.CurrentScore));
                    Console.WriteLine();
                    PrintScoreBoard();
                    //Play();
                }
                else
                {
                    visualizer.VisualizeField();
                    //Console.WriteLine(field.ToString());
                    this.CurrentScore++;
                    //ProcessCommand(command);
                }
                //TODO: Implement the missed logic
            }
            else
            {
                throw new CommandUnknownException("No exist such command!");
            }
        }

        public void PrintScoreBoard()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Scoreboard:");
            Scores.Sort();
            int i = 0;
            foreach (Score sr in Scores)
            {
                i++;
                sb.AppendFormat("{0}. {1} --> {2} cells \n", i, sr.PlayerName, sr.PlayerPoints);
            }
            Console.WriteLine(sb.ToString());
        }

        private void Exit()
        {
            Console.WriteLine("Good bye!");
        }
    }
}

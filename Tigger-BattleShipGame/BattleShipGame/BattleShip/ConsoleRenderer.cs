namespace BattleShip
{
    using System;
    using System.Text;
    using BattleShip.Common;

    class ConsoleRenderer : IRenderer
    {
        int fieldRows;
        int fieldCols;
        StringBuilder scene = new StringBuilder();

        public void AddSeaToRender(Sea sea)
        {
            State[,] field = sea.GetBody() as State[,];
            fieldRows = field.GetLength(0);
            fieldCols = field.GetLength(1);

            scene.Append(string.Format("   0 1 2 3 4 5 6 7 8 9" + Environment.NewLine));
            scene.Append(string.Format("   -------------------" + Environment.NewLine));

            for (int row = 0; row < fieldRows; row++)
            {
                scene.Append(string.Format("{0} |", row));
                for (int col = 0; col < fieldCols; col++)
                {
                    if (sea is PlayerSea)
                    {
                        if (field[row, col] == State.Empty)
                        {
                            scene.Append((char)State.Empty);
                            scene.Append(" ");
                        }
                        else if (field[row, col] == State.MissedHit)
                        {
                            scene.Append((char)State.MissedHit);
                            scene.Append(" ");
                        }
                        else if (field[row, col] == State.Ship)
                        {
                            scene.Append((char)State.Ship);
                            scene.Append(" ");
                        }
                        else if (field[row, col] == State.TargetHit)
                        {
                            scene.Append((char)State.TargetHit);
                            scene.Append(" ");
                        }
                        else
                        {
                            throw new ArgumentException("Invalid State in Sea matrix.");
                        }
                    }
                    else if (sea is BootSea)
                    {
                        if (field[row, col] == State.Empty || field[row, col] == State.Ship)
                        {
                            scene.Append((char)State.Empty);
                            scene.Append(" ");
                        }
                        else if (field[row, col] == State.MissedHit)
                        {
                            scene.Append((char)State.MissedHit);
                            scene.Append(" ");
                        }
                        else if (field[row, col] == State.TargetHit)
                        {
                            scene.Append((char)State.TargetHit);
                            scene.Append(" ");
                        }
                        else
                        {
                            throw new ArgumentException("Invalid State in Sea matrix.");
                        }
                    }
                }

                scene.Append(Environment.NewLine);
            }
        }

        public void AddMessageToRender(string message)
        {
            this.scene.Append(message);
        }

        public void RenderAll(Position position)
        {
            Console.SetCursorPosition(position.X, position.Y);

            Console.WriteLine(scene.ToString());
        }

        public void RenderAll()
        {
            Console.WriteLine();
            Console.WriteLine(scene.ToString());
        }

        public void ClearRenderObjects()
        {
            scene.Clear();
        }
    }
}

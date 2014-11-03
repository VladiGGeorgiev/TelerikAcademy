namespace Minesweeper
{
    class MinesweeperMain
    {
        const int FieldRows = 5;
        const int FieldCols = 10;
        const int NumberOfMines = 15;

        static void Main(string[] args)
        {
            ConsoleGame game = new ConsoleGame(FieldRows, FieldCols, NumberOfMines);

            game.Play();
        }
    }
}

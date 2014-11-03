using Minesweeper.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Common
{
    public class Field
    {
        private Cell[,] field;
        private int mines;
        private int rows;
        private int columns;

        public Field(int rows, int cols, int mines)
        {
            this.field = InitializeGrid(rows, cols);
            this.mines = mines;
            this.rows = rows;
            this.columns = cols;
        }

        public Cell this[int row, int col]
        {
            get
            {
                return field[row, col];
            }
            set
            {
                field[row, col] = value;
            }
        }


        /// <summary>
        /// Gets or sets the columns.
        /// </summary>
        /// <value>The columns.</value>
        public int Columns
        {
            get
            {
                return this.columns;
            }
        }

        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        /// <value>The rows.</value>
        public int Rows
        {
            get
            {
                return this.rows;
            }
        }

        public void RevealMines()
        {
            foreach (var element in field)
            {
                if (element.State == '*')
                {
                    element.Reveal();
                }
            }
        }
        
        private void InitializeMineField()
        {
            int[] randomMinePosition = GenerateRandomPositions();
            FillMines(randomMinePosition);
        }

        private void FillMines(int[] randomMinePosition)
        {
            int row = new int();
            int column = new int();
            for (int index = 0; index < this.mines; index++)
            {
                row = randomMinePosition[index] / this.columns;
                column = randomMinePosition[index] % this.columns;
                SetCellValue(row, column, '*');
            }
        }

        private int[] GenerateRandomPositions()
        {
            int[] positiveRandomNumbersUpToRowsXCols = new int[this.mines];//creates array of coordinates of mines row*x+column
            int currentMinesCount = 0;

            Random randomGenerator = new Random();
            int gridCellsCount = this.rows * this.columns;
            int randomNumber = 0;

            do
            {
                do
                {
                    randomNumber = randomGenerator.Next(gridCellsCount);
                }
                while ((positiveRandomNumbersUpToRowsXCols.Count(n => n == randomNumber) > 0));//check if number exist
                positiveRandomNumbersUpToRowsXCols[currentMinesCount] = randomNumber;
                currentMinesCount++;
            }
            while (currentMinesCount < this.mines);

            return positiveRandomNumbersUpToRowsXCols;
        }

        public void MarkAndRevealEmptyFields(char marker)
        {
            foreach (var element in field)
            {
                if ((element.State != '*') && (!element.IsRevealed))
                {
                    element.State = marker;
                    element.Reveal();
                }
            }
        }

        public bool IsValidCell(int row, int column)
        {
            if ((0 <= row && row < this.rows) && (0 <= column && column < this.columns))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetCellValue(int row, int column, char state)
        {
            if (!IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }
            
            this.field[row, column].State = state;
        }

        private char GetCellValue(int row, int column)
        {
            if (IsValidCell(row, column))
            {
                char cellValue = field[row, column].State;
                return cellValue;
            }
            else
            {
                throw new InvalidCellException();
            }
        }

        public char RevealCell(int row, int column)
        {
            if (!IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }
            if (field[row, column].IsRevealed)
            {
                throw new IllegalMoveException("Cell is already revealed! Try again.");
            }

            field[row, column].Reveal();
            if (field[row, column].State != '*')
            {
                int neighbourMinesCount = NeighbourMinesCount(row, column);
                SetCellValue(row, column, (char)neighbourMinesCount);
            }

            return field[row, column].State;
        }

        public int NeighbourMinesCount(int row, int column)
        {
            if (IsValidCell(row, column))
            {
                int upCellRow = (row - 1 < 0) ? row : (row - 1);
                int downCellRow = (row + 1) >= rows ? row : row + 1;
                int leftCellColumn = (column - 1) < 0 ? column : column - 1;
                int rightCellColumn = (column + 1) >= columns ? column : column + 1;

                int mineCount = 0;
                for (int r = upCellRow; r <= downCellRow; r++)
                {
                    for (int col = leftCellColumn; col <= rightCellColumn; col++)
                    {
                        if (field[r, col].State == '*')
                        {
                            mineCount++;
                        }
                    }
                }
                return mineCount;
            }
            else
            {
                throw new InvalidCellException();
            }
        }

        private Cell[,] InitializeGrid(int rows, int cols)
        {
            var tempGrid = new Cell[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    tempGrid[row, col] = new Cell('?');
                }
            }

            return tempGrid;
        }
    }
}

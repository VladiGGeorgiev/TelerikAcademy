using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Common;

namespace Minesweeper
{
    class ConsoleVisualizer
    {
        private Field field;

        public ConsoleVisualizer(Field field)
        {
            this.field = field;
        }

        public void VisualizeField()
        {
            StringBuilder result = new StringBuilder();
            result.Append("   ");
            result.Append(GenerateColumnsNumbers());
            result.Append(GenerateHorizontalBorders());
            result.Append(GenerateField());
            result.Append(GenerateHorizontalBorders());

            Console.WriteLine(result);
        }

        private string GenerateColumnsNumbers()
        {
            StringBuilder result = new StringBuilder();
            for (int col = 0; col < field.Columns; col++)
            {
                result.AppendFormat(" {0}", col);
            }

            result.Append(" \n");

            return result.ToString();
        }

        private string GenerateHorizontalBorders()
        {
            StringBuilder result = new StringBuilder();
            result.Append("   ");
            result.Append('-', field.Columns * 2 + 1);
            result.Append(" \n");

            return result.ToString();
        }

        private string GenerateField()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < field.Rows; row++)
            {
                //generates row number
                result.AppendFormat("{0} |", row);

                //generate values in each row
                for (int col = 0; col < field.Columns; col++)
                {
                    result.AppendFormat(" {0}", (char)field[row, col].State);
                }
                result.Append(" |\n");
            }

            return result.ToString();
        }

        public void VisualizeScore(List<Score> scores)
        {
            
        }
    }
}

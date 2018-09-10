using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramGame
{
    public class NonogramGameViewModel
    {
        public NonogramCell[,] NonogramCells { get; set; }
        public string[,] ColumnNums { get; set;}
        public string[,] RowNums { get; set; }

        public NonogramGameViewModel()
        {
            NonogramCells = new NonogramCell[5,5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    NonogramCells[i, j] = new NonogramCell();
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    ColumnNums[i, j] = "";
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    RowNums[i, j] = "";
                }
            }
        }
    }
}

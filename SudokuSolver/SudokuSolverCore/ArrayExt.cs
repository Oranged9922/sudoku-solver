using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverCore
{
    public static class Array2DExt
    {

        public static int?[] GetRow(this int?[,] array, int row)
        {
            int?[] res = new int?[array.GetLength(1)];
            for (int i = 0; i < array.GetLength(1); i++)
            {
                res[i] = array[row, i];
            }
            return res;
        }
        public static int?[] GetCol(this int?[,] array, int col)
        {
            int?[] res = new int?[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                res[i] = array[i, col];
            }
            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverCore
{
    public class Sudoku
    {

        public SudokuGrid SudokuGrid { get; set; }
        public SudokuSolver SudokuSolver { get; }
        public bool IsInDefaultForm { get => SudokuGrid.IsInDefaultForm; }
        public Sudoku(int?[,] testInputSudoku)
        {
            SudokuGrid = new(testInputSudoku);
            SudokuSolver = new(SudokuGrid);
        }
        public SudokuGrid Solve()
        {
            SudokuGrid = SudokuSolver.Solve(SudokuGrid);
            return SudokuGrid;
        }

        public void Show(TextWriter writer)
        {
            StringBuilder sb = new();
            for (int i = 0; i < SudokuGrid.Size; i++)
            {
                for (int j = 0; j < SudokuGrid.Size; j++)
                {
                    sb.Append('[');
                    sb.Append(SudokuGrid[i, j] == null ? "." : SudokuGrid[i,j]);
                    sb.Append(']');
                }
                sb.AppendLine();
            }
            writer.Write(sb);
        }
    }

}

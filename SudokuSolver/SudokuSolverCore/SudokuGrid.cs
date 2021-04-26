using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverCore
{
    public class SudokuGrid
    {

        public int?[,] Grid { get; init; }
        public bool IsInDefaultForm { get; init; }
        public int Size { get; init; }
        public int EmptyFields { get; set; }
        public int? this[int index, int jndex] { get => Grid[index, jndex]; set => Grid[index, jndex] = value; }
        public SudokuGrid(int size)
        {
            Grid = new int?[size, size];
            IsInDefaultForm = (size == 9);
            Size = size;
            EmptyFields = size * size;
        }
        public SudokuGrid(int?[,] grid)
        {
            Grid = grid;
            IsInDefaultForm = grid.GetUpperBound(0) + 1 == 9;
            Size = grid.GetUpperBound(0) + 1;
            int remaining = GetRemainingToFill();
            EmptyFields = remaining;
        }

        private int GetRemainingToFill()
        {
            int result = 0;
            foreach (var item in Grid)
            {
                result += (item == null) ? 1 : 0;
            }
            return result;
        }

        public void SetValue(int x, int y, int value)
        {
            if (Grid[x, y] == null) EmptyFields--;
            Grid[x, y] = value;
        }
        public int? GetValue(int x, int y) => Grid[x, y];
        public int?[] GetRow(int row) => Grid.GetRow(row);
        public int?[] GetCol(int col) => Grid.GetCol(col);

        public static implicit operator int?[,](SudokuGrid g) => g.Grid;
        public void SetRow(int?[] row, int rowNum)
        {
            if (!(row.Length == Grid.GetUpperBound(rowNum) + 1)) throw new InvalidOperationException("Number of elements");
            for (int i = 0; i < Grid.GetUpperBound(rowNum) + 1; i++)
            {
                Grid[rowNum, i] = row[i];
            }
        }
        public void SetCol(int?[] col, int colNum)
        {
            if (!(col.Length == Grid.GetUpperBound(colNum) + 1)) throw new InvalidOperationException("Number of elements");
            for (int i = 0; i < Grid.GetUpperBound(colNum) + 1; i++)
            {
                Grid[i, colNum] = col[i];
            }
        }

        public int?[,] Get3x3Region(int row, int col)
        {
            if (!this.IsInDefaultForm) throw new InvalidOperationException("Cannot get 3 by 3 region in non-regular form");
            // 012 | 345 | 678
            int rowPos = (row < 3) ? 0 : (row < 6) ? 1 : 2;
            int colPos = (col < 3) ? 0 : (col < 6) ? 1 : 2;
            int?[,] result = {
                { this[3*rowPos + 0,3*colPos + 0], this[3*rowPos + 0,3*colPos + 1], this[3*rowPos + 0,3*colPos + 2] },
                { this[3*rowPos + 1,3*colPos + 0], this[3*rowPos + 1,3*colPos + 1], this[3*rowPos + 1,3*colPos + 2] },
                { this[3*rowPos + 2,3*colPos + 0], this[3*rowPos + 2,3*colPos + 1], this[3*rowPos + 2,3*colPos + 2] }
            };
            return result;
        }
    }
    public static class SudokuGridExt
    {
        public static SudokuGrid Copy(this SudokuGrid sd)
        {
            int?[,] newGrid = new int?[sd.Size, sd.Size];
            for (int i = 0; i < sd.Size; i++)
            {
                for (int j = 0; j < sd.Size; j++)
                {
                    newGrid[i, j] = sd[i, j];
                }
            }
            return new SudokuGrid(newGrid);

        }
    }
}

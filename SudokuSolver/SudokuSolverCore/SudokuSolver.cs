using System;
using System.Collections.Generic;

[assembly:System.Runtime.CompilerServices.InternalsVisibleTo("SudokuSolverTests")]
namespace SudokuSolverCore
{
    public class SudokuSolver
    {

        public List<List<List<int>>> possible { get; set; }
        bool solved = false;
        public SudokuSolver(SudokuGrid sudokuGrid)
        {
            possible = new List<List<List<int>>>();
            for (int i = 0; i < sudokuGrid.Size; i++)
                possible.Add(new());
        }

        internal SudokuGrid Solve(SudokuGrid sudokuGrid)
        {
            if (!sudokuGrid.IsInDefaultForm) 
                throw new NotImplementedException("Cannot solve sudoku that is not in regular 9x9 form.");

            var res = SolveDefaultForm(sudokuGrid);
            solved = res.EmptyFields == 0;
            return res;
        }

        public SudokuGrid SolveDefaultForm(SudokuGrid sudokuGrid)
        {
            CreatePossibleList(sudokuGrid);
            while (!solved)
            {
                if (sudokuGrid.EmptyFields == 0) return sudokuGrid;
                if (!Update(sudokuGrid))
                {
                    Tuple<int, int> minimal = GetMinOptions(possible);
                    if (minimal.Item1 == -1 || minimal.Item2 == -1) return sudokuGrid;
                    
                    for (int k = 0; k < possible[minimal.Item1][minimal.Item2].Count; k++)
                    {
                        Sudoku s = new(sudokuGrid.Copy());
                        s.SudokuGrid.SetValue(minimal.Item1, minimal.Item2, possible[minimal.Item1][minimal.Item2][k]);
                        var temp = s.Solve();
                        if (s.SudokuSolver.solved) return temp;
                        else continue;
                }
                return sudokuGrid;
            }

            if (solved) return sudokuGrid;
            CreatePossibleList(sudokuGrid);
        }
            return sudokuGrid;
        }

        private Tuple<int, int> GetMinOptions(List<List<List<int>>> possible)
        {
            List<int> min = null;
            int item1 = -1, item2 = -1;
            for (int i = 0; i  < possible.Count; i++)
            {
                for (int j = 0; j < possible[i].Count; j++)
                {
                    if (min == null) min = possible[i][j];
                    if (possible[i][j] == null) continue;
                    if (possible[i][j].Count < 2) continue;
                    if (item1 == -1 || item2 == -1)
                    {
                        item1 = i;
                        item2 = j;
                    }
                    if (possible[i][j].Count < min.Count)
                    {
                        item1 = i;
                        item2 = j;
                        min = possible[i][j];
                    }
                }
            }
            return new Tuple<int, int>(item1, item2);
        }

        private bool Update(SudokuGrid sudokuGrid)
        {
            bool somethingUpdated = false;
            for (int i = 0; i < possible.Count; i++)
            {
                for (int j = 0; j < possible[i].Count; j++)
                {
                    if (possible[i][j] != null)
                        if (possible[i][j].Count == 1)
                        {
                            somethingUpdated = true;
                            sudokuGrid[i, j] = possible[i][j][0];
                            sudokuGrid.EmptyFields--;
                            if (sudokuGrid.EmptyFields == 0)
                            {
                                solved = true;
                                return true;
                            }
                            return true;
                        }
                }
            }
            return somethingUpdated;
        }
        private void CreatePossibleList(SudokuGrid sudokuGrid)
        {
            possible = new List<List<List<int>>>();
            for (int i = 0; i < sudokuGrid.Size; i++)
                possible.Add(new());
            for (int i = 0; i < sudokuGrid.Size; i++)
                for (int j = 0; j < sudokuGrid.Size; j++)
                {
                    if (sudokuGrid[i, j] == null)
                    {
                        this.possible[i].Add(CheckPossibleValues(sudokuGrid, i, j));
                    }
                    else this.possible[i].Add(null);
                }
        }
        public static List<int> CheckPossibleValues(SudokuGrid sudokuGrid, int row, int col)
        {
            var region = sudokuGrid.Get3x3Region(row, col);
            List<int> possibleValues = GetPossibleValues(new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, region);
            possibleValues = GetPossibleValues(possibleValues, sudokuGrid.GetCol(col));
            possibleValues = GetPossibleValues(possibleValues, sudokuGrid.GetRow(row));
            return possibleValues;
        }

        public static List<int> GetPossibleValues(List<int> possible, int?[,] region)
        {
            
            foreach (var item in region)
            {
                if (!(item == null))
                    if (possible.Contains((int)item)) possible.Remove((int)item);
            }
            return possible;
        }
        public static List<int> GetPossibleValues(List<int> possible, int?[] region)
        {
            foreach (var item in region)
            {
                if (!(item == null))
                    if (possible.Contains((int)item)) possible.Remove((int)item);
            }
            return possible;
        }

    }
}

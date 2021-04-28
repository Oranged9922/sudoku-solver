using System;
using SudokuSolverCore;
using System.Diagnostics;

namespace SudokuSolverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int?[,] testInputSudoku = new int?[,]
{
                            {   8, null, null,    7,    1,    5, null, null,    4},
                            {null, null,    5,    3, null,    6,    7, null, null},
                            {   3, null,    6,    4, null,    8,    9, null,    1},

                            {null,    6, null, null,    5, null, null,    4, null},
                            {null, null, null,    8, null,    7, null, null, null},
                            {null,    5, null, null,    4, null, null,    9, null},

                            {   6, null,    9,    5, null,    3,    4, null,    2},
                            {null, null,    4,    9, null,    2,    5, null, null},
                            {   5, null, null,    1,    6,    4, null, null,    9},
};
            //int?[,] testInputSudoku = new int?[,]
            //{
            //    {null,null,null,null,9,null,8,2,null },
            //    {null,1,null,null,null,null,5,null,9 },
            //    {7,null,9,null,1,null,null,null,null },
            //    {null,6,2,7,null,1,null,9,null },
            //    {null,null,null,null,6,null,null,null,null },
            //    {null,8,null,3,null,9,null,4,null },
            //    {null,null,null,null,8,null,9,null,2 },
            //    {8,null,4,null,null,null,null,3,null },
            //    {null,1,6,null,3,null,null,null,null }
            //};
            int?[,] sudokugrid = new int?[,]
           {
                            {8,2,7,1,5,4,3,9,6 },
                            {9,6,5,3,2,7,1,4,8 },
                            {3,4,1,6,8,9,7,5,2 },
                            {5,9,3,4,6,8,2,7,1 },
                            {4,7,2,5,null,3,6,8,9 },
                            {6,1,8,9,7,2,4,3,5 },
                            {7,8,6,2,3,5,9,1,4 },
                            {1,5,4,7,9,6,8,2,3 },
                            {2,3,9,8,4,1,5,6,7 }

           };

            int?[,] errorcekSudoku = new int?[,]
          {
                            { 9, 4, null, 3, null, null, 2, null, 8 },
                            { 5, 8, null, null, 4, null, null, null, null },
                            { null, 2, null, 7, null, null, 6, 5, null },
                            { null, null, null, null, 9, null, null, null, 2 },
                            { null, 9, null, null, 5, null, null, null, null },
                            { null, null, null, null, null, null, null, 6, 3 },
                            { 4, 5, null, 2, null, null, null, null, 9 },
                            { null, null, null, null, 3, null, 7, null, 6 },
                            { null, null, null, null, null, null, null, null, null },
          };

            int?[,] errorcekSudokuv2 = new int?[,]
            {/*
9, x, x, x, x, x, 8, x, x,
5, x, x, x, x, 9, 1, x, x,
2, 1, x, 8, x, x, 6, x, x,
x, x, x, 5, x, 1, x, x, 7,
x, x, x, 2, x, 8, x, x, x,
3, x, x, 9, x, 6, x, x, x,
x, x, 7, x, x, 4, x, 6, 5,
x, x, 2, 6, x, x, x, x, 3,
x, x, 9, x, x, x, x, x, 8*/
                {9,null,null,   null,null,null,   8, null, null },
                {5,null,null,   null,null, 9,     1, null, null },
                {2, 1, null,    8, null, null,    6,  null, null },
                { null, null, null, 5, null, 1, null, null, 7 },
                { null, null, null, 2, null, 8, null, null, null },
                { 3, null, null, 9, null, 6, null, null, null },
                { null, null, 7, null, null, 4, null, 6, 5 },
                { null, null, 2, 6, null, null, null, null, 3 },
                { null, null, 9, null, null, null, null, null, 8 }

            };
            Sudoku sudoku = new(errorcekSudoku);
            sudoku.Solve();
            sudoku.Show(Console.Out);
            Console.WriteLine("__________");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            sudoku = new(errorcekSudokuv2);
            sudoku.Solve();
            sw.Stop();
            sudoku.Show(Console.Out);
            Console.WriteLine("Time taken:" + sw.Elapsed);


        }
    }
}


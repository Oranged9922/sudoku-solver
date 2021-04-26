using NUnit.Framework;
using SudokuSolverCore;

namespace SudokuSolverTests
{
    class SudokuSolverCheckerTests
    {
        [Test]
        public void FindPossible()
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
            Sudoku sudoku = new(testInputSudoku);
            var res00 = sudoku.SudokuGrid.Get3x3Region(0, 0);
            var res01 = sudoku.SudokuGrid.Get3x3Region(0, 1);
            var res02 = sudoku.SudokuGrid.Get3x3Region(0, 2);
            var res22 = sudoku.SudokuGrid.Get3x3Region(2, 2);
            var res03 = sudoku.SudokuGrid.Get3x3Region(0, 3);
            var res05 = sudoku.SudokuGrid.Get3x3Region(0, 5);

            int?[,] region00 = new int?[,]
            {
                {8,null,null },{null,null,5},{3,null,6}
            };

            int?[,] sudokugrid = new int?[,]
            {
                {8,2,7  ,1,5,4    ,3,9,6 },
                {9,6,5  ,3,2,7    ,1,4,8 },
                {3,4,1  ,6,8,9    ,7,5,2 },

                {5,9,3  ,4,6,8    ,2,7,1 },
                {4,7,2  ,5,null,3 ,6,8,9 },
                {6,1,8  ,9,7,2    ,4,3,5 },

                {7,8,6  ,2,3,5    ,9,1,4 },
                {1,5,4  ,7,9,6    ,8,2,3 },
                {2,3,9  ,8,4,1    ,5,6,7 }

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
            Sudoku s = new(sudokugrid);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    var res = s.SudokuGrid.Get3x3Region(i,j);
                }
            }
        } 
    }
}

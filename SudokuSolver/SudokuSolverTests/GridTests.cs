using NUnit.Framework;
using SudokuSolverCore;

namespace SudokuSolverTests
{
    class GridTests
    {
        [Test]
        public void SetRowTest()
        {
            int?[,] t = new int?[3, 3]
            {
                { 0, 1, 2},
                { 0, 1, 2},
                { 0, 1, 2}
            };

            int?[,] res = new int?[3, 3]
            {
                { 0, 1, 2},
                { 10,20, 30},
                { 0, 1, 2}
            };

            SudokuGrid sudokuGrid = new(t);
            sudokuGrid.SetRow(new int?[] { 10, 20, 30 }, 1);
            Assert.AreEqual(res, (int?[,])sudokuGrid);
        }
        [Test]
        public void SetColTest()
        {
            int?[,] t = new int?[3, 3]
            {
                { 0, 1, 2},
                { 0, 1, 2},
                { 0, 1, 2}
            };

            int?[,] res = new int?[3, 3]
             {
                { 0, 10, 2},
                { 0, 20, 2},
                { 0, 30, 2}
             };

            SudokuGrid sudokuGrid = new(t);
            sudokuGrid.SetCol(new int?[] { 10, 20, 30 }, 1);
            Assert.AreEqual(res, (int?[,])sudokuGrid);

        }
        [Test]
        public void IsDefaultTest()
        {

            SudokuGrid s = new(9);
            int?[] col = s.GetCol(0);
            Assert.AreEqual(true, s.IsInDefaultForm);
            Assert.AreEqual(9, col.Length);
        }

        [Test]
        public void IsNotDefaultTest()
        {

            SudokuGrid s = new(7);
            int?[] col = s.GetCol(0);
            Assert.AreEqual(false, s.IsInDefaultForm);
            Assert.AreEqual(7,col.Length);
        }
    }
}

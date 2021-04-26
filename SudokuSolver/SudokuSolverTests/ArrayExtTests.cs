using NUnit.Framework;
using SudokuSolverCore;

namespace SudokuSolverTests
{
    public class ArrayExtTests
    {
        [Test]
        public void GetRowTest()
        {
            int?[,] t = new int?[3, 4]
            {
                { 0, 0, 0, 0},
                { 1, 1, 1, 1},
                { 2, 2, 2, 2}
            };

            int?[] res = new int?[]{ 1, 1, 1, 1 };

            Assert.AreEqual(res, t.GetRow(1));
        }

        [Test]
        public void GetColTest()
        {
            int?[,] t = new int?[3, 4]
            {
                { 0, 1, 2, 3},
                { 0, 1, 2, 3},
                { 0, 1, 2, 3}
            };

            int?[] res = new int?[] { 1, 1, 1};

            Assert.AreEqual(res, t.GetCol(1));
        }
    }
}
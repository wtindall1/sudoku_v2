namespace SudokuTest;
using SudokuObject;
using System.Linq;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestGetRow()
    {
        //create sudoku object
        Sudoku testPuzzle = new Sudoku();
        //set sudoku grid to one of the row 1s
        int[,] testGrid =
        {
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {1,0,1,0,1,0,1,0,1},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0}
        };
        testPuzzle.grid = testGrid;

        //create a test array as that row
        int[] testRow = {1,0,1,0,1,0,1,0,1};

        //retrieve that row
        int[] sudokuRow = testPuzzle.GetRow(2);
        
        Assert.IsTrue(testRow.SequenceEqual(sudokuRow), $"Failed. testRow was {testRow}, sudokuRow was {sudokuRow}");
    }

    [TestMethod]
    public void TestGetColumn()
    {
    }

    [TestMethod]
    public void TestGetCell()
    {
    }
}
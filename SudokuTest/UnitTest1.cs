namespace SudokuTest;
using SudokuObject;
using System.Linq;

[TestClass]
public class SudokuUnitTest
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
        
        Assert.IsTrue(testRow.SequenceEqual(sudokuRow), $"Failed. 3rd row was not returned.");
    }

    [TestMethod]
    public void TestGetColumn()
    {
        //create sudoku object
        Sudoku testPuzzle = new Sudoku();
        //set sudoku grid to one of the row 1s
        int[,] testGrid =
        {
            {0,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,1,0,0,0,0,0,0}
        };
        testPuzzle.grid = testGrid;

        //create a test array as that column
        int[] testColumn = {1,0,1,0,1,0,1,0,1};

        //retrieve that row
        int[] sudokuColumn = testPuzzle.GetColumn(2);
        
        Assert.IsTrue(testColumn.SequenceEqual(sudokuColumn), $"Failed. 3rd column was not returned.");
    }

    [TestMethod]
    public void TestGetCell()
    {
        //create sudoku object
        Sudoku testPuzzle = new Sudoku();
        //set sudoku grid to one of the row 1s
        int[,] testGrid =
        {
            {0,0,0,0,0,0,1,2,3},
            {0,0,0,0,0,0,4,5,6},
            {0,0,0,0,0,0,7,8,9},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0}
        };
        testPuzzle.grid = testGrid;

        //create 2d array with the expected result
        int[,] testCell =
        {
            {1,2,3},
            {4,5,6},
            {7,8,9}
        };

        //call the method
        int[,] sudokuCell = testPuzzle.GetCell(2, 6);

        Assert.IsTrue(testCell.Cast<int>().SequenceEqual(sudokuCell.Cast<int>()), "Failed. Incorrect cell retrieved.");
    }
}
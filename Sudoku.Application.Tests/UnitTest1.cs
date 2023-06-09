namespace SudokuTest;
using Sudoku.Application;
using System.Linq;

[TestClass]
public class SudokuUnitTest
{
    [TestMethod]
    public void TestGetRow()
    {
        //create sudoku object
        SudokuPuzzle testPuzzle = new SudokuPuzzle();
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
        SudokuPuzzle testPuzzle = new SudokuPuzzle();
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
        SudokuPuzzle testPuzzle = new SudokuPuzzle();
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

    [TestMethod]
    public void TestIsPositionValidIdentifiesInvalidPosition()
    {
                        //create sudoku object
        SudokuPuzzle testPuzzle = new SudokuPuzzle();
        //set sudoku grid to one of the row 1s
        int[,] testGrid =
        {
            {0,0,0,0,0,0,1,2,3},
            {0,0,0,0,0,0,4,5,6},
            {0,0,0,0,0,0,7,8,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0}
        };
        testPuzzle.grid = testGrid;

        Assert.IsFalse(testPuzzle.IsPositionValid(4, 2, 8), "Incorrect, value present in row, cell or column");
        
    }

    [TestMethod]
    public void TestIsPositionValidAllowsValidPosition()
    {
        //create sudoku object
        SudokuPuzzle testPuzzle = new SudokuPuzzle();
        //set sudoku grid to one of the row 1s
        int[,] testGrid =
        {
            {0,0,0,0,0,0,1,2,3},
            {0,0,0,0,0,0,4,5,6},
            {0,0,0,0,0,0,7,8,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0}
        };
        testPuzzle.grid = testGrid;

        Assert.IsTrue(testPuzzle.IsPositionValid(9, 2, 8), "Incorrect, value present in row, cell or column");
    }

    [TestMethod]
    public void TestIsCurrentGridValidIdentifiesInvalidGrid()
    {
        //create sudoku object
        SudokuPuzzle testPuzzle = new SudokuPuzzle();
        //set sudoku grid to one of the row 1s
        int[,] testGrid =
        {
            {1,0,0,2,6,0,7,0,1},
            {6,8,0,0,7,0,0,9,0},
            {1,9,0,0,0,4,5,0,0},
            {8,2,0,1,0,0,0,4,0},
            {0,0,4,6,0,2,9,0,0},
            {0,5,0,0,0,3,0,2,8},
            {0,0,9,3,0,0,0,7,4},
            {0,4,0,0,5,0,0,3,6},
            {7,0,3,0,1,8,0,0,0}
        };
        testPuzzle.grid = testGrid;

        Assert.IsFalse(testPuzzle.IsCurrentGridValid());

    }

    [TestMethod]
    public void TestSolverSolvesEasySudokuPuzzle()
    {
        //create sudoku object
        SudokuPuzzle testPuzzle = new SudokuPuzzle();
        //set sudoku grid to one of the row 1s
        int[,] testGrid =
        {
            {0,0,0,2,6,0,7,0,1},
            {6,8,0,0,7,0,0,9,0},
            {1,9,0,0,0,4,5,0,0},
            {8,2,0,1,0,0,0,4,0},
            {0,0,4,6,0,2,9,0,0},
            {0,5,0,0,0,3,0,2,8},
            {0,0,9,3,0,0,0,7,4},
            {0,4,0,0,5,0,0,3,6},
            {7,0,3,0,1,8,0,0,0}
        };
        testPuzzle.grid = testGrid;

        testPuzzle.SolveSudoku();

        bool IsComplete = !testPuzzle.solvedGrids[0].Cast<int>().Any(x => x == 0);

        Assert.IsTrue(testPuzzle.IsCurrentGridValid() && IsComplete, "Failed. Grid is Invalid or Incomplete.");

    }


    [TestMethod]
    public void TestSolverSolvesEmptySudokuPuzzle()
    {
        //create sudoku object
        SudokuPuzzle testPuzzle = new SudokuPuzzle();
        int[,] testGrid =
        {
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0}
        };
        testPuzzle.grid = testGrid;

        testPuzzle.SolveSudoku();

        bool IsComplete = !testPuzzle.solvedGrids[0].Cast<int>().Any(x => x == 0);

        Assert.IsTrue(testPuzzle.IsCurrentGridValid() && IsComplete, "Failed. Grid is Invalid or Incomplete.");
    }

    [TestMethod]
    public void TestSolverStopsAfterTwoSolutions()
    {
        //create sudoku object
        SudokuPuzzle testPuzzle = new SudokuPuzzle();
        int[,] testGrid =
        {
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0}
        };
        testPuzzle.grid = testGrid;

        testPuzzle.SolveSudoku();

        Assert.IsFalse(testPuzzle.solvedGrids.Count >2, "Failed. Solver found more than 2 solutions.");
    }

    [TestMethod]
    public void TestCreateCompletedMethodCreatesCompleteGrid()
    {
        //create sudoku object
        SudokuPuzzle testPuzzle = new SudokuPuzzle();

        testPuzzle.CreateCompleted();

        bool IsComplete = !testPuzzle.grid.Cast<int>().Any(x => x == 0);

        Assert.IsTrue(testPuzzle.IsCurrentGridValid() && IsComplete, $"Failed. Grid is Invalid {testPuzzle.IsCurrentGridValid()} or Incomplete {IsComplete}.");


    }
    [TestMethod]
    public void TestGeneratePuzzleMethodCreatesSolvableSudokuPuzzle()
    {
        //create sudoku object
        SudokuPuzzle testPuzzle = new SudokuPuzzle();

        //convert unsolved and solved strings back to 2d arrays
        int index = 0;
        var (unsolved, solved) = testPuzzle.GeneratePuzzle();
        int [,] solvedGrid = new int[9,9];

        for (int i=0; i < 9; i++)
        {
            for (int j=0; j < 9; j++)
            {
                testPuzzle.grid[i, j] = unsolved[index];
                solvedGrid[i,j] = (int)unsolved[index];
                index++;
            }
        }

        //clear solved grids
        testPuzzle.solvedGrids.Clear();
        //solve the unsolved
        testPuzzle.SolveSudoku();

        //check if the solution is equal to the solved string array
        Assert.IsTrue(solvedGrid.Cast<int>().SequenceEqual(testPuzzle.solvedGrids[0].Cast<int>()));


    }

    [TestMethod]
    public void TestGeneratePuzzleSolutionIsUnique()
    {
        
        SudokuPuzzle testPuzzle = new SudokuPuzzle();        
        testPuzzle.GeneratePuzzle();

        Console.WriteLine(testPuzzle.solvedGrids.Count);

        Assert.IsTrue(testPuzzle.solvedGrids.Count == 1, "Failed, a unique solution was not given.");




    }




}

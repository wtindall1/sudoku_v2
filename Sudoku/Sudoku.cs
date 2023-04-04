namespace SudokuObject;

using System.Linq;
using System.Collections.Generic;
using System.Text;

public class Sudoku
{
    //private member data
    private int[,] _grid = new int[9, 9];
    private int[,] _devGrid = new int[9, 9]; //to use before solver is finished

    private List<int[,]> _solvedGrids = new List<int[,]>();

    //setter for _grid
    public int[,] grid
    {
        get
        {
            return this._grid;
        }
        set
        {
            this._grid = value;
        }
    }

    public List<int[,]> solvedGrids
    {
        get
        {
            return this._solvedGrids;
        }
    }

    public void PrintGrid()
    {
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                Console.Write($"{_grid[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    //takes in row number, returns the corresponding grid row
    public int[] GetRow(int row)
    {
        //loops through the 1st (0) dimension of the 2d array
        //return array which each value in the first row
        return Enumerable.Range(0, _grid.GetLength(0))
            .Select(i => _grid[row, i])
            .ToArray();
    }

    public int[] GetColumn(int column)
    {
        return Enumerable.Range(0, _grid.GetLength(1))
            .Select(i => _grid[i, column])
            .ToArray();
    }

    //takes in indices of a square, returns the 3x3 grid it is contained in, as a 2d array
    public int[,] GetCell(int row, int column)
    {
        //find y, x for top left square of the 3x3 cell
        int y;
        int x;
        int[,] slicedArray = new int[3,3];
        //find y (row)
        if (row < 3)
        {
            y = 0;
        }
        else if (row < 6)
        {
            y = 3;
        }
        else
        {
            y = 6;
        }


        //find x (column)
        if (column < 3)
        {
            x = 0;
        }
        else if (column < 6)
        {
            x = 3;
        }
        else
        {
            x = 6;
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                slicedArray[i, j] = _grid[y + i, x + j];
            }
        }

        return slicedArray;

        
    }

    public bool IsPositionValid(int possibleValue, int row, int column)
    {
        //get row
        int[] selectedRow = this.GetRow(row);
        //get column
        int[] selectedColumn = this.GetColumn(column);
        //get 3x3 cell
        int[,] selectedCell = this.GetCell(row, column);

        //check if value in row, column or cell
        return (Array.IndexOf(selectedRow, possibleValue) == -1 &&
            Array.IndexOf(selectedColumn, possibleValue) == -1 &&
            Array.IndexOf(selectedCell.Cast<int>().ToArray(), possibleValue) == -1); //cast the cell to int to make it a 1d array)

    }

    public bool IsCurrentGridValid() //this is more to help with testing
    {
        //loop through each non 0 value
        for (int i=0; i < _grid.GetLength(0); i++)
        {
            for (int j=0; j < _grid.GetLength(1); j++)
            {
                if (_grid[i, j] != 0)
                {
                    //store a copy of the value
                    int temp = _grid[i,j];
                    //temporarily set to 0 so only a duplicate will be found
                    _grid[i,j] = 0;
                    //check that the value is allowed
                    if (!IsPositionValid(temp, i, j))
                    {
                        return false;
                    };
                    //restore the grid value
                    _grid[i,j] = temp;
                }
            }
        }

        //if none of the values were an issue, return true
        return true;




    }
    
    //returns List of value tuples, with (row, column) of empty positions in this.grid
    public List<(int, int)> GetEmptyPositionsList()
    {
        //find all empty positions
        List<(int, int)> emptyPositions = new List<(int, int)>();
        for (int i=0; i < grid.GetLength(0); i++)
        {
            for (int j=0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 0)
                {
                    emptyPositions.Add((i, j));
                }
            }
        }

        return emptyPositions;
    }
    public void SolveSudoku()

    {
        
        //exit out if found >1 solution
        if (_solvedGrids.Count > 1)
        {
            return;
        }

        //create a dict, keys = empty positions, values = array of possible values for each position
        Dictionary<(int, int), int[]> emptyPositionsValidNumbers = new Dictionary<(int, int), int[]>();
        for (int i=0; i < _grid.GetLength(0); i++)
        {
            for (int j=0; j < _grid.GetLength(1); j++)
            {
                //only use empty positions
                if (_grid[i, j] == 0)
                {
                    //tuple with row and column indices
                    (int, int) key = (i, j);
                    //create array with all numbers valid in that position
                    int[] validNumbers = Enumerable.Range(1, 9).Where(x => IsPositionValid(x, i, j)).ToArray();
                    emptyPositionsValidNumbers.Add(key, validNumbers);
                }

            }
        }

        //save solved grid and exit out of no positions are empty (solved)
        if (emptyPositionsValidNumbers.Count == 0)
        {
            this._solvedGrids.Add((int[,])this._grid.Clone()); //.Clone() to create shallow copy - passing by reference means backtracking will undo the solve
            return;
        }

        //get the position with least possible positions
        var positionWithLeastValidNumbers = emptyPositionsValidNumbers.OrderBy(x => x.Value.Length).First();
        int row = positionWithLeastValidNumbers.Key.Item1;
        int column = positionWithLeastValidNumbers.Key.Item2;

        //for that position, loop throug the valid numbers
        foreach (int i in positionWithLeastValidNumbers.Value)
        {
            //set the empty position to a valid number
            this._grid[row, column] = i;

            //recursive call to chekc if the assigned number leads to a solution
            this.SolveSudoku();

            //backtracking step
            this._grid[row, column] = 0;
        }

        //return to backtrack if none of the valid numbers led to a solution
        return;


    }

    public void CreateCompleted()
    {
        //randomly assign the values in the top row
        int[] values = Enumerable.Range(1, 9).ToArray();
        Random random = new Random();
        values = values.OrderBy(x => random.Next()).ToArray();
        for (int i = 0; i < values.Length; i++)
        {
            this.grid[0, i] = values[i];
        }

        //loop until board is full
        while (true)
        {
            //find all empty positions
            List<(int, int)> emptyPositions = GetEmptyPositionsList();

            //exit if grid is filled
            if (emptyPositions.Count == 0)
            {
                break;
            }

            //pick a random row and column
            Random randomer = new Random();
            (int, int) randomPosition = emptyPositions.OrderBy(x => randomer.Next()).First();
            int randomRow = randomPosition.Item1;
            int randomColumn = randomPosition.Item2;

            //pick a random number for the cell, out of those that are valid
            int randomValidValue = Enumerable.Range(1, 9)
                                        .Where(x => this.IsPositionValid(x, randomRow, randomColumn))
                                        .OrderBy(x => randomer.Next())
                                        .First();
            this.grid[randomRow, randomColumn] = randomValidValue;

            //wipe solved grids array
            this._solvedGrids.Clear();

            //solve and undo change if no valid solution
            this.SolveSudoku();
            if (this._solvedGrids.Count == 0)
            {
                this.grid[randomRow, randomColumn] = 0;
            }
        }
    }

    public (string, string) GeneratePuzzle()
    {
        //create completed puzzle - this._grid
        this.CreateCompleted();

        //random outside loop so not created each time
        Random random = new Random();

        //make list of all filled positions
        List<(int, int)> positions = new List<(int, int)>();
        for (int i=0; i < grid.GetLength(0); i++)
        {
            for (int j=0; j < grid.GetLength(1); j++)
            {
                if(grid[i,j] != 0)
                {
                    positions.Add((i, j));
                }
            }
        }

        //while loop
        while (true)
        {            



            //pick a random position (skip to next loop if it's a 0)
            (int, int) randomPosition = positions.OrderBy(x => random.Next()).First();
            // Console.WriteLine(randomPosition);
            int randomRow = randomPosition.Item1;
            int randomColumn = randomPosition.Item2;
            
            //make a copy of the value & remove the value
            int temp = this.grid[randomRow, randomColumn];
            this.grid[randomRow, randomColumn] = 0;

            //wipe the solved grids list
            this._solvedGrids.Clear();


            //solve, then undo the removal if there is no solution or > 1
            this.SolveSudoku();
            if (this.solvedGrids.Count != 1)
            {
                this.grid[randomRow, randomColumn] = temp;
            }

            //remove the position from the list
            positions.Remove(randomPosition);

            //exit if 17 clues left or all positions tested
            if (positions.Count == 0)
            {
                break;
            }
        }

        //at this point this.grid should be a prepared sudoku
        //and the first item in solvedGrids should be the solved version
        //return both of these as 81 character strings
        StringBuilder stringBuilderStart = new StringBuilder();
        StringBuilder stringBuilderComplete = new StringBuilder();
        int[,] solvedSudokuArray = solvedGrids[0];


        for (int i=0; i < grid.GetLength(0); i++)
        {
            for (int j=0; j < grid.GetLength(1); j++)
            {
                stringBuilderStart.Append(grid[i, j].ToString());
                stringBuilderComplete.Append(solvedSudokuArray[i, j].ToString());
            }
        }
        
        return (stringBuilderStart.ToString(), stringBuilderComplete.ToString());
        //IF THIS IS SLOW, CHECK HOW LONG SOLVER RUNS WHEN THERE IS NO SOLUTION
    }
}


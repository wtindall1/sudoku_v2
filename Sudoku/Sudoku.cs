namespace SudokuObject;

public class Sudoku
{
    //private member data
    private int[,] _grid = new int[9, 9];
    private int[,] _devGrid = new int[9, 9]; //to use before solver is finished

    private int[,] _solvedGrids = new int[9, 9];

    //setter for _grid
    public int[,] grid
    {
        set
        {
            this._grid = value;
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
        return Enumerable.Range(0, _grid.GetLength(0))
            .Select(i => _grid[i, column])
            .ToArray();
    }

    //takes in indices of a square, returns the 3x3 grid it is contained in
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


}


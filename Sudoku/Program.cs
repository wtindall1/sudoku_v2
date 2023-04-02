using SudokuObject;

public class Program
{
    public static void Main()
    {
        Sudoku puzzle = new Sudoku();

        puzzle.PrintGrid();

        puzzle.grid = new int[,]
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

        Console.WriteLine(puzzle.IsPositionValid(1, 2, 1));

    }
}

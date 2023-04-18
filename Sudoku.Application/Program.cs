using Sudoku.Application;

public class Program
{
    public static void Main()
    {
        var puzzle = new SudokuPuzzle();

        Console.WriteLine(puzzle.GeneratePuzzle());

    }
}

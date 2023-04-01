using SudokuObject;

public class Program
{
    public static void Main()
    {
        Sudoku puzzle = new Sudoku();

        puzzle.PrintGrid();
        Console.WriteLine(puzzle.GetRow(0));
        Console.WriteLine(puzzle.GetColumn(0));

    }
}

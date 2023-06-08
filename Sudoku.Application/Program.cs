using Sudoku.Application;

public class Program
{
    public static void Main()
    {
        var puzzle = new SudokuPuzzle(difficulty: "easy");

        (string, string) result = puzzle.GeneratePuzzle();

        Console.WriteLine(result);
        Console.WriteLine(result.Item1.Where(x => x!='0').Count());

    }
}

using System;

namespace Sudoku.Application.Models;

public class SudokuModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public required String StartingSudoku { get; set; }

    public required String SolvedSudoku { get; set; }

}

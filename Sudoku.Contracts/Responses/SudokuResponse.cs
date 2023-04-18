using System;

namespace Sudoku.Contracts.Responses;

public class SudokuResponse
{
    public required Guid Id { get; set; }

    public required String StartingSudoku { get; set; }

    public required String SolvedSudoku { get; set; }

}
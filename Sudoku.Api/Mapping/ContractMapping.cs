namespace Sudoku.Api.Mapping;

using System;
using Sudoku.Contracts.Responses;
using Sudoku.Application.Models;


public static class ContractMapping
{
    public static SudokuResponse MapToResponse(this SudokuModel sudoku)
    {
        return new SudokuResponse
        {
            Id = sudoku.Id,
            StartingSudoku = sudoku.StartingSudoku,
            SolvedSudoku = sudoku.SolvedSudoku
        };
    }
}

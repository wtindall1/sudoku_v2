using Microsoft.AspNetCore.Mvc;
using Sudoku.Application;
using Sudoku.Contracts;
using Sudoku.Application.Models;
using Sudoku.Api.Mapping;
using System;

namespace Sudoku.Api.Controllers;

[ApiController]
public class SudokuController : ControllerBase
{
    [HttpGet(ApiEndpoints.Sudoku.Get)]
    public async Task<IActionResult> Get()
    {
        (string, string) sequences = new SudokuPuzzle().GeneratePuzzle();
        
        //convert sudoku object to model
        var sudokuModel = new SudokuModel
        {
            StartingSudoku = sequences.Item1,
            SolvedSudoku = sequences.Item2
        };

        return Ok(sudokuModel.MapToResponse());
            



    }
}




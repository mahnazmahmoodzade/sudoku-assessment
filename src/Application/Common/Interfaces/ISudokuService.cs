using SudokuApp.Application.Board.Commands.SolveBoard;
using SudokuApp.Application.Board.Queries.GetBoardQuery;
using SudokuApp.Application.Board.Queries.ValidateBoard;
using SudokuApp.Domain.Enums;

namespace SudokuApp.Application.Common.Interfaces;

public interface ISudokuService
{
	Task<BoardDto> GetBoardAsync(Difficulty difficulty);
	Task<ValidationResultDto> ValidateBoardAsync(int[][] board);
	Task<SolveResultDto> SolveBoardAsync(int[][] board);
}
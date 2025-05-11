using SudokuApp.Application.Board.Queries.GetBoardQuery;
using SudokuApp.Domain.Enums;

namespace SudokuApp.Application.Common.Interfaces;

public interface ISudokuProvider
{
	Task<BoardDto> GetBoardAsync(Difficulty difficulty);
}
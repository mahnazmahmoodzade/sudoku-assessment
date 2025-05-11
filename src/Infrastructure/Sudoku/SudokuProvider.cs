using System.Net.Http.Json;
using SudokuApp.Application.Board.Queries.GetBoardQuery;
using SudokuApp.Application.Common.Interfaces;
using SudokuApp.Domain.Enums;
using SudokuApp.Domain.Extensions;

namespace SudokuApp.Infrastructure.Sudoku;

public class SudokuProvider : ISudokuProvider
{
	private readonly HttpClient _http;
	public SudokuProvider(HttpClient http)
	{
		_http = http;
	}
	public async Task<BoardDto> GetBoardAsync(Difficulty difficulty)
	{
		var response = await _http.GetFromJsonAsync<BoardDto>($"https://sugoku.onrender.com/board?difficulty={difficulty.ToApiValue()}");
		return response!;
	}
}
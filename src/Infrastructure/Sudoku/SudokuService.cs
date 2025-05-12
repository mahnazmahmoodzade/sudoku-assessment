using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using SudokuApp.Application.Board.Commands.SolveBoard;
using SudokuApp.Application.Board.Queries.GetBoardQuery;
using SudokuApp.Application.Board.Queries.ValidateBoard;
using SudokuApp.Application.Common.Interfaces;
using SudokuApp.Domain.Enums;
using SudokuApp.Domain.Extensions;

namespace SudokuApp.Infrastructure.Sudoku;

public class SudokuService : ISudokuService
{
	private readonly HttpClient _httpClient;
	private readonly string _endpoint;

	public SudokuService(HttpClient httpClient)
	{
		_httpClient = httpClient;
		_endpoint = "https://sugoku.onrender.com/";
	}
	public async Task<BoardDto> GetBoardAsync(Difficulty difficulty)
	{
		var response = await _httpClient.GetFromJsonAsync<BoardDto>($"{_endpoint}board?difficulty={difficulty.ToApiValue()}");
		return response!;
	}

	public async Task<ValidationResultDto> ValidateBoardAsync(int[][] board)
	{
		var data = new Dictionary<string, string>
		{
			{ "board", JsonSerializer.Serialize(board) }
		};

		var content = new FormUrlEncodedContent(data);

		var response = await _httpClient.PostAsync($"{_endpoint}validate", content);
		response.EnsureSuccessStatusCode();

		var result = await response.Content.ReadFromJsonAsync<ValidationResultDto>();
		return result!;
	}

	public async Task<SolveResultDto> SolveBoardAsync(int[][] board)
	{
		var data = new Dictionary<string, string>
		{
			{ "board", JsonSerializer.Serialize(board) }
		};

		var content = new FormUrlEncodedContent(data);

		var response = await _httpClient.PostAsync($"{_endpoint}solve", content);
		response.EnsureSuccessStatusCode();

		var result = await response.Content.ReadFromJsonAsync<SolveResultDto>();
		return result!;
	}
}
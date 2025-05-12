using Microsoft.AspNetCore.Http.HttpResults;
using SudokuApp.Application.Board.Commands.SolveBoard;
using SudokuApp.Application.Board.Queries.GetBoardQuery;
using SudokuApp.Application.Board.Queries.ValidateBoard;
using SudokuApp.Domain.Enums;

namespace SudokuApp.Web.Endpoints;

public class Boards: EndpointGroupBase
{
	public override void Map(WebApplication app)
	{
		app.MapGroup(this)
			.AllowAnonymous()
			.MapGet(GetBoard)
			.MapPost(ValidateBoard,"validate")
			.MapPost(SolveBoard, "solve");
	}

	public async Task<Ok<BoardDto>> GetBoard(ISender sender, Difficulty difficulty = Difficulty.Easy)
	{
		var result = await sender.Send(new GetBoardQuery(difficulty));
		return TypedResults.Ok(result);
	}



	public async Task<Ok<ValidationResultDto>> ValidateBoard(ISender sender, ValidateBoardQuery request)
	{
		var result = await sender.Send(request);
		return TypedResults.Ok(result);
	}

	public async Task<Ok<SolveResultDto>> SolveBoard(ISender sender, SolveBoardCommand request)
	{
		var result = await sender.Send(request);
		return TypedResults.Ok(result);
	}
}
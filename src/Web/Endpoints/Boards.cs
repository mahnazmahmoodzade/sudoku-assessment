using Microsoft.AspNetCore.Http.HttpResults;
using SudokuApp.Application.Board.Queries.GetBoardQuery;
using SudokuApp.Domain.Enums;

namespace SudokuApp.Web.Endpoints;

public class Boards: EndpointGroupBase
{
	public override void Map(WebApplication app)
	{
		app.MapGroup(this)
			.AllowAnonymous()
			.MapGet(GetBoard);
	}

	public async Task<Ok<BoardDto>> GetBoard(ISender sender, Difficulty difficulty = Difficulty.Easy)
	{
		var result = await sender.Send(new GetBoardQuery(difficulty));
		return TypedResults.Ok(result);
	}
}
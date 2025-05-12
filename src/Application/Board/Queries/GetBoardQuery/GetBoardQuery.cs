 using SudokuApp.Application.Common.Interfaces;
using SudokuApp.Domain.Enums;

namespace SudokuApp.Application.Board.Queries.GetBoardQuery;

public record GetBoardQuery(Difficulty Difficulty) : IRequest<BoardDto>
{
}

public class GetBoardQueryHandler : IRequestHandler<GetBoardQuery, BoardDto>
{
	private readonly ISudokuService _sudokuService;
	public GetBoardQueryHandler(ISudokuService sudokuService)
	{
		_sudokuService = sudokuService;
	}
	public Task<BoardDto> Handle(GetBoardQuery request, CancellationToken cancellationToken)
	{
		return _sudokuService.GetBoardAsync(request.Difficulty);
	}
}

public class GetBoardQueryValidator : AbstractValidator<GetBoardQuery>
{
    public GetBoardQueryValidator()
    {
    }
}


using SudokuApp.Application.Common.Interfaces;
using SudokuApp.Domain.Enums;

namespace SudokuApp.Application.Board.Queries.GetBoardQuery;

public record GetBoardQuery(Difficulty Difficulty) : IRequest<BoardDto>
{
}

public class GetBoardQueryHandler : IRequestHandler<GetBoardQuery, BoardDto>
{
	private readonly ISudokuProvider _sudokuProvider;
	public GetBoardQueryHandler(ISudokuProvider sudokuProvider)
	{
		_sudokuProvider = sudokuProvider;
	}
	public Task<BoardDto> Handle(GetBoardQuery request, CancellationToken cancellationToken)
	{
		return _sudokuProvider.GetBoardAsync(request.Difficulty);
	}
}

public class GetBoardQueryValidator : AbstractValidator<GetBoardQuery>
{
    public GetBoardQueryValidator()
    {
    }
}


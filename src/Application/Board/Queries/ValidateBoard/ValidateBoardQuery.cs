using SudokuApp.Application.Common.Interfaces;

namespace SudokuApp.Application.Board.Queries.ValidateBoard;

public record ValidateBoardQuery(int[][] Board) : IRequest<ValidationResultDto>;


public class ValidateBoardQueryHandler : IRequestHandler<ValidateBoardQuery, ValidationResultDto>
{
	private readonly ISudokuService _sudokuService;

	public ValidateBoardQueryHandler(ISudokuService sudokuApiService)
	{
		_sudokuService = sudokuApiService;
	}

	public async Task<ValidationResultDto> Handle(ValidateBoardQuery request, CancellationToken cancellationToken)
	{
		var result = await _sudokuService.ValidateBoardAsync(request.Board);
		return result;
	}
}
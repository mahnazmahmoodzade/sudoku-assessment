using SudokuApp.Application.Common.Interfaces;

namespace SudokuApp.Application.Board.Commands.SolveBoard;
public record SolveBoardCommand(int[][] Board) : IRequest<SolveResultDto>;


public class SolveBoardCommandHandler : IRequestHandler<SolveBoardCommand, SolveResultDto>
{
	private readonly ISudokuService _sudokuApiService;

	public SolveBoardCommandHandler(ISudokuService sudokuApiService)
	{
		_sudokuApiService = sudokuApiService;
	}

	public async Task<SolveResultDto> Handle(SolveBoardCommand request, CancellationToken cancellationToken)
	{
		return await _sudokuApiService.SolveBoardAsync(request.Board);
	}
}
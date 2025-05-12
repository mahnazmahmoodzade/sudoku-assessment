namespace SudokuApp.Application.Board.Queries.ValidateBoard;

public class ValidationResultDto
{
	public string Status { get; set; } = default!; // "solved", "unsolved", or "broken"
}
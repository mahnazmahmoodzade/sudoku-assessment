namespace SudokuApp.Application.Board.Commands.SolveBoard;

public class SolveResultDto
{
	public string Status { get; set; } = default!; 
	public int[][]? Solution { get; set; }          
}
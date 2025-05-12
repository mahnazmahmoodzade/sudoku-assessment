using SudokuApp.Domain.Enums;

namespace SudokuApp.Domain.Extensions;

public static class DifficultyExtensions
{
	public static string ToApiValue(this Difficulty difficulty) =>
		difficulty.ToString().ToLower();
}
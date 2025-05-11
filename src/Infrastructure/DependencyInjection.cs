using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SudokuApp.Application.Common.Interfaces;
using SudokuApp.Infrastructure.Sudoku;

namespace SudokuApp.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
	    builder.Services.AddHttpClient<ISudokuProvider, SudokuProvider>();
	}
}

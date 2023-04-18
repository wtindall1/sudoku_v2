using System;

namespace Sudoku.Api;

public static class ApiEndpoints
{
	private const string ApiBase = "api";

	public static class Sudoku
	{
		private const string Base = $"{ApiBase}/sudoku";

		//later could add a post, and make the get retrieve the most recent
		public const string Get = Base;


	}
}

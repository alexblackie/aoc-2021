using Xunit;
using System.Linq;
using System.Collections.Generic;
using Bingo;

namespace BingoTests;

public class GameTest
{
	[Fact]
	public void TestAddBoard()
	{
		var input = new List<List<int>>()
		{
			new List<int>() { 14, 21, 17, 24, 4 },
			new List<int>() { 10, 16, 15, 9, 19 },
			new List<int>() { 18, 8, 23, 26, 20 },
			new List<int>() { 22, 11, 13, 6, 5 },
			new List<int>() { 2, 0, 12, 3, 7 }
		};
		var board = Board.Parse(input);

		var game = new Game();
		game.AddBoard(board);

		Assert.Equal(board, game.Boards[0]);
	}

	[Fact]
	public void TestAddBoards()
	{
		var input = new List<List<List<int>>>()
		{
			new List<List<int>>()
			{
				new List<int>() { 14, 21, 17, 24, 4 },
				new List<int>() { 10, 16, 15, 9, 19 },
				new List<int>() { 18, 8, 23, 26, 20 },
				new List<int>() { 22, 11, 13, 6, 5 },
				new List<int>() { 2, 0, 12, 3, 7 }
			},

			new List<List<int>>()
			{
				new List<int>() { 22, 13, 17, 11, 0 },
				new List<int>() { 8, 2, 23, 4, 24 },
				new List<int>() { 21, 9, 14, 16, 7 },
				new List<int>() { 6, 10, 3, 18, 5 },
				new List<int>() { 1, 12, 20, 15, 19 }
			},
		};
		var boards = input.Select(input => Board.Parse(input)).ToList();

		var game = new Game();
		game.AddBoards(boards);

		Assert.Equal(boards[0], game.Boards[0]);
		Assert.Equal(boards[1], game.Boards[1]);
	}

	[Fact]
	public void TestDrawWithABingo()
	{
		var draws = new List<int>()
		{
			7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15,
			25, 12, 22, 18, 20, 8, 19, 3, 26, 1
		};

		var boards = new List<Board>()
		{
			Board.Parse(new List<List<int>>()
			{
				new List<int>() { 22, 13, 17, 11, 0 },
				new List<int>() { 8, 2, 23, 4, 24 },
				new List<int>() { 21, 9, 14, 16, 7 },
				new List<int>() { 6, 10, 3, 18, 5 },
				new List<int>() { 1, 12, 20, 15, 19 }
			}),

			Board.Parse(new List<List<int>>()
			{
				new List<int>() { 3, 15, 0, 2, 22 },
				new List<int>() { 9, 18, 13, 17, 5 },
				new List<int>() { 19, 8, 7, 25, 23 },
				new List<int>() { 20, 11, 10, 24, 4 },
				new List<int>() { 14, 21, 16, 12, 6 }
			}),

			Board.Parse(new List<List<int>>()
			{
				new List<int>() { 14, 21, 17, 24, 4 },
				new List<int>() { 10, 16, 15, 9, 19 },
				new List<int>() { 18, 8, 23, 26, 20 },
				new List<int>() { 22, 11, 13, 6, 5 },
				new List<int>() { 2, 0, 12, 3, 7 }
			}),
		};

		var game = new Game();
		game.AddBoards(boards);
		var result = game.Draw(draws);

		Assert.Equal(boards[2], result.WinningBoard);
		Assert.Equal(24, result.WinningDraw);
	}

	[Fact]
	public void TestDrawWithoutABingo()
	{
		var draws = new List<int>()
		{
			7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21
		};

		var boards = new List<Board>()
		{
			Board.Parse(new List<List<int>>()
			{
				new List<int>() { 22, 13, 17, 11, 0 },
				new List<int>() { 8, 2, 23, 4, 24 },
				new List<int>() { 21, 9, 14, 16, 7 },
				new List<int>() { 6, 10, 3, 18, 5 },
				new List<int>() { 1, 12, 20, 15, 19 }
			}),

			Board.Parse(new List<List<int>>()
			{
				new List<int>() { 3, 15, 0, 2, 22 },
				new List<int>() { 9, 18, 13, 17, 5 },
				new List<int>() { 19, 8, 7, 25, 23 },
				new List<int>() { 20, 11, 10, 24, 4 },
				new List<int>() { 14, 21, 16, 12, 6 }
			}),

			Board.Parse(new List<List<int>>()
			{
				new List<int>() { 14, 21, 17, 24, 4 },
				new List<int>() { 10, 16, 15, 9, 19 },
				new List<int>() { 18, 8, 23, 26, 20 },
				new List<int>() { 22, 11, 13, 6, 5 },
				new List<int>() { 2, 0, 12, 3, 7 }
			}),
		};

		var game = new Game();
		game.AddBoards(boards);

		Assert.Null(game.Draw(draws));
	}
}

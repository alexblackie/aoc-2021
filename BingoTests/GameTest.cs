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
}

using Xunit;
using System.Collections.Generic;
using Bingo;

namespace BingoTests;

public class BoardTest
{
	[Fact]
	public void TestIsBingoWithAFullRow()
	{
		var board = new Board()
		{
			Cells = new List<List<Cell>>()
			{
				new List<Cell>() {
					new Cell() { Number = 5, Marked = true },
					new Cell() { Number = 10, Marked = true },
					new Cell() { Number = 7, Marked = true },
					new Cell() { Number = 8, Marked = true },
					new Cell() { Number = 9, Marked = true },
				},
				new List<Cell>() {
					new Cell() { Number = 69, Marked = false },
					new Cell() { Number = 420, Marked = false },
					new Cell() { Number = 666, Marked = false },
					new Cell() { Number = 888, Marked = false },
					new Cell() { Number = 1989, Marked = false },
				},
				new List<Cell>() {
					new Cell() { Number = 67, Marked = false },
					new Cell() { Number = 101, Marked = false },
					new Cell() { Number = 700, Marked = false },
					new Cell() { Number = 432, Marked = false },
					new Cell() { Number = 111, Marked = false },
				}
			}
		};

		Assert.True(board.IsBingo());
	}

	[Fact]
	public void TestIsBingoWithAFullColumn()
	{
		var board = new Board()
		{
			Cells = new List<List<Cell>>()
			{
				new List<Cell>() {
					new Cell() { Number = 5, Marked = false },
					new Cell() { Number = 10, Marked = false },
					new Cell() { Number = 7, Marked = false },
					new Cell() { Number = 8, Marked = true },
					new Cell() { Number = 9, Marked = false },
				},
				new List<Cell>() {
					new Cell() { Number = 69, Marked = false },
					new Cell() { Number = 420, Marked = false },
					new Cell() { Number = 666, Marked = false },
					new Cell() { Number = 888, Marked = true },
					new Cell() { Number = 1989, Marked = false },
				},
				new List<Cell>() {
					new Cell() { Number = 67, Marked = false },
					new Cell() { Number = 101, Marked = false },
					new Cell() { Number = 700, Marked = false },
					new Cell() { Number = 432, Marked = true },
					new Cell() { Number = 111, Marked = false },
				}
			}
		};

		Assert.True(board.IsBingo());
	}

	[Fact]
	public void TestIsBingoWithNoAdjacent()
	{
		var board = new Board()
		{
			Cells = new List<List<Cell>>()
			{
				new List<Cell>() {
					new Cell() { Number = 5, Marked = false },
					new Cell() { Number = 10, Marked = true },
					new Cell() { Number = 7, Marked = false },
					new Cell() { Number = 8, Marked = true },
					new Cell() { Number = 9, Marked = false },
				},
				new List<Cell>() {
					new Cell() { Number = 69, Marked = false },
					new Cell() { Number = 420, Marked = false },
					new Cell() { Number = 666, Marked = false },
					new Cell() { Number = 888, Marked = false },
					new Cell() { Number = 1989, Marked = false },
				},
				new List<Cell>() {
					new Cell() { Number = 67, Marked = true },
					new Cell() { Number = 101, Marked = false },
					new Cell() { Number = 700, Marked = false },
					new Cell() { Number = 432, Marked = true },
					new Cell() { Number = 111, Marked = false },
				}
			}
		};

		Assert.False(board.IsBingo());
	}
}

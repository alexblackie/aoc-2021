using Xunit;
using Bingo;

namespace BingoTests;

public class CellTest
{
	[Fact]
	public void TestEquality()
	{
		var cell = new Cell() { Number = 100 };
		var cellToo = new Cell() { Number = 100 };
		var markedCell = new Cell() { Number = 100, Marked = true };

		Assert.Equal(cell, cellToo);
		Assert.NotEqual(cell, markedCell);
		Assert.NotEqual(cellToo, markedCell);
	}

	[Fact]
	public void TestMarkIfNumberMatches()
	{
		var cell = new Cell() { Number = 100 };

		cell.MarkIf(100);

		Assert.True(cell.Marked);
	}

	[Fact]
	public void TestMarkIfNumberDoesntMatch()
	{
		var cell = new Cell() { Number = 100 };

		cell.MarkIf(69);

		Assert.False(cell.Marked);
	}
}

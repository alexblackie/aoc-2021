using Xunit;
using Bingo;

namespace BingoTests;

public class CellTest
{
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

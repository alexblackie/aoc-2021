using Xunit;
using Submarine;

namespace SubmarineTests;

public class DirectionChangeTest
{
	[Fact]
	public void TestParseCanParseCommandLineForward()
	{
		var entity = DirectionChange.Parse("forward 5");
		Assert.Equal(5, entity.Forward);
		Assert.Equal(0, entity.Reverse);
		Assert.Equal(0, entity.Up);
		Assert.Equal(0, entity.Down);
	}

	[Fact]
	public void TestParseCanParseCommandLineReverse()
	{
		var entity = DirectionChange.Parse("reverse 4");
		Assert.Equal(0, entity.Forward);
		Assert.Equal(4, entity.Reverse);
		Assert.Equal(0, entity.Up);
		Assert.Equal(0, entity.Down);
	}

	[Fact]
	public void TestParseCanParseCommandLineUp()
	{
		var entity = DirectionChange.Parse("up 7");
		Assert.Equal(0, entity.Forward);
		Assert.Equal(0, entity.Reverse);
		Assert.Equal(7, entity.Up);
		Assert.Equal(0, entity.Down);
	}

	[Fact]
	public void TestParseCanParseReverseCommandDown()
	{
		var entity = DirectionChange.Parse("down 891");
		Assert.Equal(0, entity.Forward);
		Assert.Equal(0, entity.Reverse);
		Assert.Equal(0, entity.Up);
		Assert.Equal(891, entity.Down);
	}

	[Fact]
	public void TestEqualityWorks()
	{
		var entity1 = DirectionChange.Parse("forward 6");
		var entity2 = DirectionChange.Parse("forward 6");

		Assert.Equal(entity1, entity2);
	}
}

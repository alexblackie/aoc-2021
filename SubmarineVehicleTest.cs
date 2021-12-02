using Xunit;
using System.Collections.Generic;

namespace Aoc;

public class SubmarineVehicleTest
{
	[Fact]
	public void TestMoveWithForward()
	{
		var sub = new SubmarineVehicle();
		var direction = new DirectionChange() { Forward = 5 };

		sub.Move(direction);

		Assert.Equal(5, sub.X);
	}

	[Fact]
	public void TestMoveWithReverse()
	{
		var sub = new SubmarineVehicle();
		var direction = new DirectionChange() { Reverse = 6 };

		sub.Move(direction);

		Assert.Equal(-6, sub.X);
	}

	[Fact]
	public void TestMoveWithUp()
	{
		var sub = new SubmarineVehicle();
		var direction = new DirectionChange() { Up = 6 };

		sub.Move(direction);

		Assert.Equal(-6, sub.Z);
	}

	[Fact]
	public void TestMoveWithDown()
	{
		var sub = new SubmarineVehicle();
		var direction = new DirectionChange() { Down = 6 };

		sub.Move(direction);

		Assert.Equal(6, sub.Z);
	}

	[Fact]
	public void TestMovesExecutesMoves()
	{
		var sub = new SubmarineVehicle();
		var directions = new List<DirectionChange>()
		{
			DirectionChange.Parse("forward 5"),
			DirectionChange.Parse("down 5"),
			DirectionChange.Parse("forward 8"),
			DirectionChange.Parse("up 3"),
			DirectionChange.Parse("down 8"),
			DirectionChange.Parse("forward 2"),
		};

		sub.Move(directions);

		Assert.Equal(15, sub.X);
		Assert.Equal(10, sub.Z);
	}
}

using Xunit;
using System.Collections.Generic;
using Submarine;

namespace SubmarineTests;

public class SubmarineVehicleTest
{
	[Fact]
	public void TestSimpleMoveWithForward()
	{
		var sub = new SubmarineVehicle();
		var direction = new DirectionChange() { Forward = 5 };

		sub.SimpleMove(direction);

		Assert.Equal(5, sub.X);
	}

	[Fact]
	public void TestSimpleMoveWithReverse()
	{
		var sub = new SubmarineVehicle();
		var direction = new DirectionChange() { Reverse = 6 };

		sub.SimpleMove(direction);

		Assert.Equal(-6, sub.X);
	}

	[Fact]
	public void TestSimpleMoveWithUp()
	{
		var sub = new SubmarineVehicle();
		var direction = new DirectionChange() { Up = 6 };

		sub.SimpleMove(direction);

		Assert.Equal(-6, sub.Z);
	}

	[Fact]
	public void TestSimpleMoveWithDown()
	{
		var sub = new SubmarineVehicle();
		var direction = new DirectionChange() { Down = 6 };

		sub.SimpleMove(direction);

		Assert.Equal(6, sub.Z);
	}

	[Fact]
	public void TestSimpleMovesExecutesSimpleMoves()
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

		sub.SimpleMove(directions);

		Assert.Equal(15, sub.X);
		Assert.Equal(10, sub.Z);
	}

	[Fact]
	public void TestMoveSetsAimAndDepth()
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
		Assert.Equal(60, sub.Z);
	}

	[Fact]
	public void TestResetClearsValues()
	{
		var sub = new SubmarineVehicle() { X = 5, Z = 8, Aim = 123 };
		Assert.Equal(123, sub.Aim);
		Assert.Equal(5, sub.X);
		Assert.Equal(8, sub.Z);

		sub.Reset();

		Assert.Equal(0, sub.Aim);
		Assert.Equal(0, sub.X);
		Assert.Equal(0, sub.Y);
	}
}

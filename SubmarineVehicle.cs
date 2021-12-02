using System.Collections.Generic;

namespace Aoc;

public class SubmarineVehicle
{
	public int X { get; set; } = 0;
	public int Y { get; set; } = 0;

	// Z is a "depth", so positive == "more down". Sea-level is 0-point.
	public int Z { get; set; } = 0;

	public void Move(DirectionChange cmd)
	{
		X += cmd.Forward;
		X -= cmd.Reverse;
		Z -= cmd.Up;
		Z += cmd.Down;
	}

	public void Move(List<DirectionChange> cmds)
	{
		foreach (DirectionChange c in cmds)
		{
			Move(c);
		}
	}
}

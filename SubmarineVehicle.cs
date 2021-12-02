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
		if (cmd.Forward != 0) X += cmd.Forward;
		if (cmd.Reverse != 0) X -= cmd.Reverse;
		if (cmd.Up != 0)      Z -= cmd.Up;
		if (cmd.Down != 0)    Z += cmd.Down;
	}

	public void Move(List<DirectionChange> cmds)
	{
		foreach (DirectionChange c in cmds)
		{
			Move(c);
		}
	}
}

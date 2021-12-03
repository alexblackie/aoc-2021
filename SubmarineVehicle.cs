using System.Collections.Generic;

namespace Aoc;

public class SubmarineVehicle
{
	public int X { get; set; } = 0;
	public int Y { get; set; } = 0;
	public int Aim { get; set; } = 0;

	// Z is a "depth", so positive == "more down". Sea-level is 0-point.
	public int Z { get; set; } = 0;

	public void Reset()
	{
		X = 0;
		Y = 0;
		Z = 0;
		Aim = 0;
	}

	public void Move(DirectionChange cmd)
	{
		Aim += cmd.Down;
		Aim -= cmd.Up;
		X += cmd.Forward;

		// Only increase depth if we are moving forward
		if (cmd.Forward != 0) Z += (cmd.Forward * Aim);
	}

	public void Move(List<DirectionChange> cmds)
	{
		foreach (DirectionChange c in cmds)
		{
			Move(c);
		}
	}

	public void SimpleMove(DirectionChange cmd)
	{
		X += cmd.Forward;
		X -= cmd.Reverse;
		Z -= cmd.Up;
		Z += cmd.Down;
	}

	public void SimpleMove(List<DirectionChange> cmds)
	{
		foreach (DirectionChange c in cmds)
		{
			SimpleMove(c);
		}
	}
}

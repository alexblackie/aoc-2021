using System;
using System.Collections.Generic;

namespace Submarine;

/// <summary>
/// Represents the state of the submarine. Exposes a minimal API to control
/// various aspects of the vehicle.
/// </summary>
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

	/// <summary>
	/// Update the submarine's position based on the given change-of-direction
	/// command record.
	/// </summary>
	public void Move(DirectionChange cmd)
	{
		Aim += cmd.Down;
		Aim -= cmd.Up;
		X += cmd.Forward;

		// Only increase depth if we are moving forward
		if (cmd.Forward != 0) Z += (cmd.Forward * Aim);
	}

	/// <summary>
	/// Update the submarine's position based on a series of change-of-
	/// direction command records.
	/// </summary>
	public void Move(List<DirectionChange> cmds)
	{
		foreach (DirectionChange c in cmds)
		{
			Move(c);
		}
	}

	/// <summary>
	/// Update the submarine's position naively to the verbatim values in the
	/// provided <c>DirectionChange</c>. Deprecated as <c>Move</c> now
	/// implements the correct navigation algorithm.
	/// </summary>
	[Obsolete("Movement logic is naive; use Move for new implementations.")]
	public void SimpleMove(DirectionChange cmd)
	{
		X += cmd.Forward;
		X -= cmd.Reverse;
		Z -= cmd.Up;
		Z += cmd.Down;
	}

	/// <summary>
	/// Update the submarine's position naively to the verbtain values in the
	/// provided List of <c>DirectionChange</c> records. Deprecated as
	/// <c>Move</c> now implements the correct navigation algorithm.
	/// </summary>
	[Obsolete("Movement logic is naive; use Move for new implementations.")]
	public void SimpleMove(List<DirectionChange> cmds)
	{
		foreach (DirectionChange c in cmds)
		{
			SimpleMove(c);
		}
	}
}

using System;
using System.Collections.Generic;

namespace Aoc;

public record DirectionChange
{
	public int Forward { get; set; } = 0;
	public int Reverse { get; set; } = 0;
	public int Up      { get; set; } = 0;
	public int Down    { get; set; } = 0;

	public static DirectionChange Parse(string line)
	{
		// TODO: can we use destructure somehow?
		string[] parts = line.Split(" ");
		string direction = parts[0];
		int klicks = int.Parse(parts[1]);

		var entity = new DirectionChange();

		if (direction == "forward") entity.Forward = klicks;
		if (direction == "reverse") entity.Reverse = klicks;
		if (direction == "up") entity.Up = klicks;
		if (direction == "down") entity.Down = klicks;

		return entity;
	}
}

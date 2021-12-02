using System;
using System.Collections.Generic;

namespace Aoc;

class Program
{
    static void Main(string[] args)
    {
		var ingestor = new Ingestor();

		// Day 1
		int[] input = ingestor.ReadNumbers("Inputs/Day1-1.txt");
		var depth = new DepthComparator();
		Console.WriteLine($"Day 1: {depth.CountIncreases(input)}");
		Console.WriteLine($"Day 1.1: {depth.CountIncreasesThrice(input)}");

		// Day 2
		var sub = new SubmarineVehicle();
		var directions = ingestor.ReadDirectionChanges("Inputs/Day2.txt");
		sub.Move(directions);
		Console.WriteLine($"Day 2: X:{sub.X} Z:{sub.Z} Product:{sub.X * sub.Z}");
	}
}

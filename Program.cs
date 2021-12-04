using System;

namespace Aoc;

class Program
{
	private static Ingestor ingestor = new Ingestor();
	private static DepthComparator depthComparator = new DepthComparator();
	private static SubmarineVehicle submarineVehicle = new SubmarineVehicle();

    static void Main(string[] args)
    {
		// Day 1
		int[] input = ingestor.ReadNumbers("Inputs/Day1-1.txt");
		Console.WriteLine($"Day 1: {depthComparator.CountIncreases(input)}");
		Console.WriteLine($"Day 1.1: {depthComparator.CountIncreasesThrice(input)}");

		// Day 2: Part 1
		var directions = ingestor.ReadDirectionChanges("Inputs/Day2.txt");
		submarineVehicle.SimpleMove(directions);
		Console.WriteLine($"Day 2: (X)(Z):{submarineVehicle.X * submarineVehicle.Z}");
		submarineVehicle.Reset();

		// Day 2: Part2
		submarineVehicle.Move(directions);
		Console.WriteLine($"Day 2.1: (X)(Z):{submarineVehicle.X * submarineVehicle.Z}");

		// Day 3
		var binaryDiagnostic = ingestor.ReadBinaryDiagnostic("Inputs/Day3.txt");
		var powerDiagnostic = PowerDiagnostic.Parse(binaryDiagnostic);
		Console.WriteLine($"Day 3: {powerDiagnostic.GammaRate * powerDiagnostic.EpsilonRate}");
		// I'm skipping Part 2 because it's insufferable.
	}
}

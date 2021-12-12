using System;
using Data;
using Submarine;

namespace Cmd;

class Program
{
	private static Ingestor ingestor = new Ingestor();
	private static DepthComparator depthComparator = new DepthComparator();
	private static SubmarineVehicle submarineVehicle = new SubmarineVehicle();

    static void Main(string[] args)
    {
		// Day 1
		// TODO: fix weird coupling with Data files
		int[] input = ingestor.ReadNumbers("Data/Inputs/Day1-1.txt");
		Console.WriteLine($"Day 1: {depthComparator.CountIncreases(input)}");
		Console.WriteLine($"Day 1.1: {depthComparator.CountIncreasesThrice(input)}");

		// Day 2: Part 1
		var directions = ingestor
			.Read("Data/Inputs/Day2.txt")
			.Select(line => DirectionChange.Parse(line))
			.ToList();

		submarineVehicle.SimpleMove(directions);
		Console.WriteLine($"Day 2: (X)(Z):{submarineVehicle.X * submarineVehicle.Z}");
		submarineVehicle.Reset();

		// Day 2: Part2
		submarineVehicle.Move(directions);
		Console.WriteLine($"Day 2.1: (X)(Z):{submarineVehicle.X * submarineVehicle.Z}");

		// Day 3
		var binaryDiagnostic = ingestor.ReadBinary("Data/Inputs/Day3.txt");
		var powerDiagnostic = PowerDiagnostic.Parse(binaryDiagnostic);
		Console.WriteLine($"Day 3: {powerDiagnostic.GammaRate * powerDiagnostic.EpsilonRate}");
		// I'm skipping Part 2 because it's insufferable.

		// Day 4
		var (day4Draws, day4BoardInputs) = ingestor.ReadBingoGame("Data/Inputs/Day4.txt");
		var day4Bingo = new Bingo.Game();
		var day4Boards = day4BoardInputs.Select(input => Bingo.Board.Parse(input)).ToList();
		day4Bingo.AddBoards(day4Boards);
		Bingo.GameResult day4Result = day4Bingo.Draw(day4Draws);

		if (day4Result != null)
		{
			Console.WriteLine($"Day 4: {day4Result.Score()}");
		}
	}
}

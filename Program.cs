using System;
using System.Collections.Generic;

namespace Aoc;

class Program
{
    static void Main(string[] args)
    {
		var ingestor = new Ingestor();
		int[] input = ingestor.ReadNumbers("Inputs/Day1-1.txt");

		var service = new DepthComparator();

		Console.WriteLine($"Day 1: {service.CountIncreases(input)}");
		Console.WriteLine($"Day 1.1: {service.CountIncreasesThrice(input)}");
	}
}

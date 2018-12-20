using System;
using System.Collections.Generic;
using System.Linq;
using MathGraph.Applications;
using MathGraph.Entities;

namespace MathGraph
{
	class Program
	{
		static void Main(string[] args)
		{
			var scenario = FordBellman.GetScenario();
			if (args.Length != 0)
				scenario.Invoke(args);
			else
				Console.WriteLine("No arguments were given");

			Console.WriteLine("\nPress Enter to exit. . .");
			Console.ReadLine();
		}
	}
}

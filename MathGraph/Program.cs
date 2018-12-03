using System;
using MathGraph.Core.Entities.Factories;

namespace MathGraph
{
	class Program
	{
		static void Main(string[] args)
		{
			var graph = GraphFactory.LoadGraphFromFile(@"/home/jambo/Jambo/edu/prog/graphs/MathGraph/MathGraph/AppData/testGraph.xml");
			Console.WriteLine(graph);
		}
	}
}

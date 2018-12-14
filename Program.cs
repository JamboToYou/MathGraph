using System;
using System.Collections.Generic;
using System.Linq;
using MathGraph.Entities;

namespace MathGraph
{
	class Program
	{
		static void Main(string[] args)
		{
			var graph = GraphLoader.LoadGraph(@"/home/jambo/Jambo/edu/prog/graphs/MathGraph/Graphs/test.txt");
			Console.WriteLine(graph.ToString(Graph.TO_STRING_MODE_MATRIX));
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(graph.ToString(Graph.TO_STRING_MODE_ADJLIST));
			Console.ReadLine();
		}
	}
}

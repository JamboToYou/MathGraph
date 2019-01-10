using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MathGraph.Entities
{
	public static class GraphLoader
	{
		public static Graph LoadGraph(string pathToFile)
		{
			var rows = File.ReadLines(pathToFile).ToList();
			var graphType = rows[0];
			rows.RemoveAt(0);

			switch (graphType)
			{
				case "matrix":
					return LoadFromMatrix(rows);
				case "adjlist":
					return LoadFromAdjList(rows);
				default:
					return null;
			}
		}

		private static Graph LoadFromMatrix(List<string> rows)
		{
			var nodesGrid = rows.Select(row => row.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)).ToArray();
			var graph = new Graph();
			for (int i = 0; i < nodesGrid.Length; i++)
			{
				graph.AddNode(i);
				for (int j = 0; j < nodesGrid.Length; j++)
				{
					graph.AddNode(j);
					if (nodesGrid[i][j] == "i")
						continue;

					graph.AddEdge(i, j, float.Parse(nodesGrid[i][j]));
				}
			}

			return graph;
		}
		private static Graph LoadFromAdjList(List<string> rows)
		{
			var adjList = rows.Select(row => row.Split(' ')).ToArray();
			var graph = new Graph();
			int node1, node2;

			foreach (var edge in adjList)
			{
				node1 = int.Parse(edge[0]);
				node2 = int.Parse(edge[1]);
				graph.AddNode(node1);
				graph.AddNode(node2);

				graph.AddEdge(node1, node2, float.Parse(edge[2]));
			}

			return graph;
		}
	}
}
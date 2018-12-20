using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathGraph.Entities
{
	public class Graph
	{
		public static string TO_STRING_MODE_MATRIX = "matrix";
		public static string TO_STRING_MODE_ADJLIST = "adjlist";
		public List<int> Nodes { get; set; }
		public List<List<float?>> Edges { get; set; }
		public int Count { get { return Nodes.Count; } }

		public Graph()
		{
			Nodes = new List<int>();
			Edges = new List<List<float?>>();
		}

		public void AddNode(int node)
		{
			if (node < 0)
				return;

			if (!Nodes.Contains(node))
				Nodes.Add(node);

			if (Edges.Count <= node)
				for (int i = Edges.Count; i <= node; i++)
					Edges.Add(new List<float?>());
		}

		public void AddEdge(int node1, int node2, float? weight)
		{
			if (node1 < 0 ||
				node2 < 0 ||
				!Contains(node1, node2) ||
				node1 == node2 ||
				!weight.HasValue)
				return;

			var node1Edges = Edges[node1];

			if (node1Edges.Count <= node2)
			{
				for (int i = node1Edges.Count; i <= node2; i++)
					node1Edges.Add(null);
				node1Edges.Add(weight);
			}
			else
			{
				Console.WriteLine(Count);
				Console.WriteLine(node1);
				Console.WriteLine(node2);
				node1Edges[node1] = node2;
			}
		}

		public bool IsAdjent(int node1, int node2)
		{
			if (Contains(node1, node2) && Edges[node1][node2].HasValue)
				return true;
			return false;
		}

		public float? GetWeight(int node1, int node2)
		{
			if (Contains(node1, node2))
				return Edges[node1][node2];
			return null;
		}

		public bool Contains(params int[] nodes) => nodes.All(node => Nodes.Contains(node));

		public string ToString(string outType = null)
		{
			var stringBuilder = new StringBuilder();
			if (outType == "matrix")
			{
				var orderedNodes = Nodes.OrderBy(e => e);
				stringBuilder.AppendLine(" \t" + string.Join('\t', orderedNodes));
				foreach (var node in Nodes)
					stringBuilder.AppendLine(node + "\t" + string.Join('\t',
						Edges[node].Select(weight => weight.HasValue ? weight.ToString() : "<i>")));

				return stringBuilder.ToString();
			}
			else if (outType == "adjlist")
			{
				foreach (var node in Nodes)
					for (int i = 0; i < Edges[node].Count; i++)
						if (Edges[node][i].HasValue &&
							Edges[i][node].HasValue &&
							Edges[node][i] == Edges[i][node])
							if (node < i)
								stringBuilder.AppendLine($"  {node}\t<===>\t{i}\t:\t{Edges[node][i]}");
							else
								continue;
						else if (Edges[node][i].HasValue)
							stringBuilder.AppendLine($"  {node}\t===>\t{i}\t:\t{Edges[node][i]}");

				return stringBuilder.ToString();
			}
			else
				return base.ToString();
		}
	}
}
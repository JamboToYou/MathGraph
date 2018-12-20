using MathGraph.Entities;

namespace MathGraph
{
	public static class Utils
	{
		public static bool IsGraphOriented(Graph graph)
		{
			var edges = graph.Edges;
			for (int i = 0; i < graph.Count; i++)
				for (int j = i + 1; j < graph.Count; j++)
					if (edges[i][j] != edges[j][i])
						return true;

			return false;
		}
	}
}
using System.Collections.Generic;
using System.Linq;

namespace MathGraph.Core.Entities
{
	public class Edge
	{
		private List<Node> Nodes { get; }
		public float Weight { get; set; }

		public Edge(Node node1, Node node2)
		{
			if (Nodes == null)
				Nodes = new List<Node>();

			Nodes.Add(node1);
			Nodes.Add(node2);
		}

		public bool IsIncident(Node node)
		{
			return Nodes.Contains(node);
		}
	}
}
using System.Collections.Generic;
using System.Linq;

namespace MathGraph.Core.Entities
{
	public class Graph
	{

		#region Properties and fields

		protected List<Node> Nodes { get; }
		protected List<Edge> Edges { get; }

		public int NodesCount
		{
			get
			{
				return Nodes.Count;
			}
		}

		public int EdgesCount
		{
			get
			{
				return Edges.Count;
			}
		}

		#endregion
		public Graph()
		{
			Nodes = new List<Node>(20);
		}

		#region CRUD with nodes
		public void AddNode(Node node)
		{
			Nodes.Add(node);
		}

		public bool RemoveNode(Node node)
		{
			return Nodes.Remove(node);
		}

		#endregion

		#region CRUD with edges

		public void AddEdge(Edge edge)
		{
			Edges.Add(edge);
		}

		public bool RemoveEdge(Edge edge)
		{
			return Edges.Remove(edge);
		}

		#endregion

		public bool AreNodesAdjecent(Node node1, Node node2) =>
			Edges.Any(edge => 
				edge.IsIncident(node1) &&
				edge.IsIncident(node2));

		public float? GetEdgeWieght(Node node1, Node node2) =>
			Edges.Find(edge =>
				edge.IsIncident(node1) &&
				edge.IsIncident(node2))?.Weight;
	}
}
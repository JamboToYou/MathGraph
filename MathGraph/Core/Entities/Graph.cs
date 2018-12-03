using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathGraph.Core.Exceptions;

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
			Edges = new List<Edge>(20);
		}

		#region CRUD with nodes
		public void AddNode(Node node)
		{
			if (!Nodes.Any(n => n.Equals(node)))
			{
				Nodes.Add(node);
			}
		}

		public bool RemoveNode(Node node)
		{
			return Nodes.Remove(node);
		}

		public Node GetNode(int nodeID) => Nodes.Find(node => node.ID == nodeID);

		#endregion

		#region CRUD with edges

		public void AddEdge(int nodeId1, int nodeId2, bool isDirect = false, float weight = 1)
		{
			Node node1 = null;
			Node node2 = null;
			try
			{
				node1 = Nodes.Find(node => node.ID == nodeId1);
				node2 = Nodes.Find(node => node.ID == nodeId2);

				var edge = new Edge(node1, node2, weight);

				if (!Edges.Any(e => e.Equals(edge)))
				{
					Edges.Add(edge);
				}

				node1.Nodes.Add(node2, edge);
				if (!isDirect)
					node2.Nodes.Add(node1, edge);

			}
			catch (InvalidNodeReferenceException ex)
			{
				throw new MathGraphException("An error occured while adding an edge", ex);
			}
			catch (ArgumentException)
			{
				throw new MathGraphException($"The edge between [{node1.ID}] and [{node2.ID}] already exists");
			}
		}

		public Edge GetEdge(int node1, int node2) => Edges.Find(edge => edge.IsIncidentTo(node1) && edge.IsIncidentTo(node2));

		public bool RemoveEdge(Edge edge) => Edges.Remove(edge);

		public bool RemoveEdge(int node1, int node2) => RemoveEdge(GetEdge(node1, node2));

		#endregion

		public bool AreNodesAdjecent(Node node1, Node node2) =>
			Edges.Any(edge =>
				edge.IsIncidentTo(node1) &&
				edge.IsIncidentTo(node2));

		public bool AreNodesAdjecent(int nodeID1, int nodeID2) =>
			Edges.Any(edge =>
				edge.IsIncidentTo(nodeID1) &&
				edge.IsIncidentTo(nodeID2));

		public float? GetEdgeWeight(Node node1, Node node2) =>
			Edges.Find(edge =>
				edge.IsIncidentTo(node1) &&
				edge.IsIncidentTo(node2))?.Weight;

		public float? GetEdgeWeight(int nodeID1, int nodeID2) =>
			Edges.Find(edge =>
				edge.IsIncidentTo(nodeID1) &&
				edge.IsIncidentTo(nodeID2))?.Weight;

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();
			foreach (var edge in Edges)
			{
				stringBuilder.AppendLine($"({edge.Nodes.Item1}, {edge.Nodes.Item2})	:	[{edge.Weight}]");
			}

			return stringBuilder.ToString();
		}
	}
}
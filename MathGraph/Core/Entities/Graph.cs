using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathGraph.Core.Entities.Enumerations;
using MathGraph.Core.Exceptions;

namespace MathGraph.Core.Entities
{
	public class Graph<T, N>
	{

		#region Properties and fields

		protected List<Node<N>> Nodes { get; }
		protected List<Edge<T, N>> Edges { get; }

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
			Nodes = new List<Node<N>>(20);
			Edges = new List<Edge<T, N>>(20);
		}

		#region CRUD with nodes
		public void AddNode(Node<N> node)
		{
			if (!Nodes.Any(n => n.Equals(node)))
			{
				Nodes.Add(node);
			}
		}

		public bool RemoveNode(Node<N> node)
		{
			return Nodes.Remove(node);
		}

		public Node<N> GetNode(int nodeID) => Nodes.Find(node => node.ID == nodeID);

		#endregion

		#region CRUD with edges

		public void AddEdge(int nodeId1, int nodeId2, bool isDirect = false, T weight = default(T))
		{
			Node<N> node1 = null;
			Node<N> node2 = null;
			try
			{
				node1 = Nodes.Find(node => node.ID == nodeId1);
				node2 = Nodes.Find(node => node.ID == nodeId2);

				var edge = new Edge<T, N>(node1, node2, weight);

				if (!Edges.Any(e => e.Equals(edge)))
				{
					Edges.Add(edge);
				}

				node1.Nodes.Add(node2);
				if (!isDirect)
					node2.Nodes.Add(node1);

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

		public Edge<T, N> GetEdge(int node1, int node2) => Edges.Find(edge => edge.IsIncidentTo(node1) && edge.IsIncidentTo(node2));

		public bool RemoveEdge(Edge<T, N> edge) => Edges.Remove(edge);

		public bool RemoveEdge(int node1, int node2) => RemoveEdge(GetEdge(node1, node2));

		#endregion

		public bool AreNodesAdjecent(Node<N> node1, Node<N> node2) =>
			Edges.Any(edge =>
				edge.IsIncidentTo(node1) &&
				edge.IsIncidentTo(node2));

		public bool AreNodesAdjecent(int nodeID1, int nodeID2) =>
			Edges.Any(edge =>
				edge.IsIncidentTo(nodeID1) &&
				edge.IsIncidentTo(nodeID2));

		public T GetEdgeWeight(Node<N> node1, Node<N> node2) =>
			Edges.Find(edge =>
				edge.IsIncidentTo(node1) &&
				edge.IsIncidentTo(node2)).Value;

		public T GetEdgeWeight(int nodeID1, int nodeID2) =>
			Edges.Find(edge =>
				edge.IsIncidentTo(nodeID1) &&
				edge.IsIncidentTo(nodeID2)).Value;

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();
			foreach (var edge in Edges)
			{
				stringBuilder.AppendLine($"({edge.Nodes.Item1}, {edge.Nodes.Item2})	:	[{edge.Value}]");
			}

			return stringBuilder.ToString();
		}

		public string ToString(GraphDisplayModes mode)
		{
			var stringBuilder = new StringBuilder();

			switch (mode)
			{
				case GraphDisplayModes.AdjencyList:
					return ToString();
				default:
					throw new NotImplementedException();
			}
		}
	}
}
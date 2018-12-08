using System;
using System.Collections.Generic;
using System.Linq;
using MathGraph.Core.Exceptions;

namespace MathGraph.Core.Entities
{
	public class Edge<T, N> : Identified
	{
		public Tuple<Node<N>, Node<N>> Nodes { get; }
		public T Value { get; set; }

		public Edge(Node<N> node1, Node<N> node2, T value = default(T))
		{
			if (node1 == null || node2 == null)
				throw new InvalidNodeReferenceException("Unable to create the edge");

			Nodes = new Tuple<Node<N>, Node<N>>(node1, node2);
			Value = value;
		}

		public bool IsIncidentTo(Node<N> node) => Nodes.Item1.Equals(node) || Nodes.Item2.Equals(node);
		public bool IsIncidentTo(int nodeID) => Nodes.Item1.ID == nodeID || Nodes.Item2.ID == nodeID;

		public override bool Equals(object obj)
		{
			var edge = obj as Edge<T, N>;
			return edge == null ? false :
				this.ID == edge.ID &&
				this.Nodes.Item1.Equals(edge.Nodes.Item1) &&
				this.Nodes.Item2.Equals(edge.Nodes.Item2) &&
				this.Value.Equals(edge.Value);
		}

		public bool Equals(int nodeId1, int nodeId2) => this.Nodes.Item1.ID == nodeId1 && this.Nodes.Item2.ID == nodeId2;

		public override int GetHashCode() => (this.ID.ToString() + this.Value.ToString() + this.Nodes.ToString()).GetHashCode();
	}
}
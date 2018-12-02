using System;
using System.Collections.Generic;
using System.Linq;
using MathGraph.Core.Exceptions;

namespace MathGraph.Core.Entities
{
	public class Edge : Identified
	{
		private Tuple<Node, Node> Nodes { get; }
		public float Weight { get; set; }

		public Edge(Node node1, Node node2, float weight = 1)
		{
			if (node1 == null || node2 == null)
				throw new InvalidNodeReferenceException("Unable to create the edge");

			Nodes = new Tuple<Node, Node>(node1, node2);
			Weight = weight;
		}

		public bool IsIncidentTo(Node node) => Nodes.Item1.Equals(node) || Nodes.Item2.Equals(node);
		public bool IsIncidentTo(int nodeID) => Nodes.Item1.ID == nodeID || Nodes.Item2.ID == nodeID;

		public override bool Equals(object obj)
		{
			var edge = obj as Edge;
			return edge == null ? false :
				this.ID == edge.ID &&
				this.Nodes.Item1.Equals(edge.Nodes.Item1) &&
				this.Nodes.Item2.Equals(edge.Nodes.Item2) &&
				this.Weight.Equals(edge.Weight);
		}

		public bool Equals(int nodeId1, int nodeId2) => this.Nodes.Item1.ID == nodeId1 && this.Nodes.Item2.ID == nodeId2;

		public override int GetHashCode() => (this.ID.ToString() + this.Weight.ToString() + this.Nodes.ToString()).GetHashCode();
	}
}
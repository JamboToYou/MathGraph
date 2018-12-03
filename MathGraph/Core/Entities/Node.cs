using System.Collections.Generic;

namespace MathGraph.Core.Entities
{
	public class Node : Identified
	{
		public Dictionary<Node, Edge> Nodes { get; set; }
		public Node() : base()
		{
			Nodes = new Dictionary<Node, Edge>();
		}

		public override bool Equals(object obj)
		{
			var node = obj as Node;
			return node == null ? false : this.ID == node.ID;
		}

		public override int GetHashCode() => this.ID.ToString().GetHashCode();

		public override string ToString() => this.ID.ToString();
	}
}
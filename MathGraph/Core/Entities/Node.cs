using System.Collections.Generic;

namespace MathGraph.Core.Entities
{
	public class Node<N> : Identified
	{
		public List<Node<N>> Nodes { get; set; }
		public Node() : base()
		{
			Nodes = new List<Node<N>>();
		}

		public override bool Equals(object obj)
		{
			var node = obj as Node<N>;
			return node == null ? false : this.ID == node.ID;
		}

		public override int GetHashCode() => this.ID.ToString().GetHashCode();

		public override string ToString() => this.ID.ToString();
	}
}
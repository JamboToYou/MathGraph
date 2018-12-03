using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using MathGraph.Core.Entities;
using MathGraph.Core.Exceptions;

namespace MathGraph.Core.Utils
{
	public class XMLGraphParser : GraphParser
	{
		public XMLGraphParser(string fileName) : base(fileName) { }
		public override Graph Parse()
		{
			var xmlGraph = XDocument.Load(FileName).Root;

			var result = new Graph();

			switch (xmlGraph.Attribute("type").Value)
			{
				case "matrix":
					return ParseFromMatrix(xmlGraph);
				case "adjlist":
					return ParseFromAdjList(xmlGraph);
				default:
					throw new UnknownGraphTypeException("Unknown");
			}
		}

		private Graph ParseFromAdjList(XElement xmlGraph)
		{
			throw new NotImplementedException();
		}

		private Graph ParseFromMatrix(XElement xmlGraph)
		{
			var graph = new Graph();
			Node node = null;
			var readNodes = new List<int>();
			var nodesGrid = xmlGraph
				.Element("rows")
				.Elements()
				.Select(row =>
					row.Value.Split(';'))
				.ToArray();

			for (int i = 0; i < nodesGrid.Length; i++)
			{
				node = new Node();
				readNodes.Add(node.ID);
				graph.AddNode(node);
			}

			for (int i = 0; i < nodesGrid.Length; i++)
			{
				for (int j = 0; j < nodesGrid.Length; j++)
				{
					if (i == j)
						continue;

					graph.AddEdge(readNodes[i], readNodes[j], true, float.Parse(nodesGrid[i][j]));
				}
			}

			return graph;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using MathGraph.Core.Exceptions;

namespace MathGraph.Core.Entities.Utils
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
			var rows = xmlGraph.Element("rows").Elements();
			Node node = null;
			var readNodes = new List<int>();

			for (int i = 0; i < rows.Count(); i++)
			{
				node = new Node();
				readNodes.Add(node.ID);
				graph.AddNode(node);
			}

			for (int i = 0; i < rows.Count(); i++)
			{
				var edgesWeights = rows.ToList()[i].Value.Split(';');
				for (int j = 0; j < edgesWeights.Length; j++)
				{
					//
					graph.AddEdge(readNodes[i], readNodes[j], true, float.Parse(edgesWeights[j]));
					//
				}
			}

			return null;
		}
	}
}
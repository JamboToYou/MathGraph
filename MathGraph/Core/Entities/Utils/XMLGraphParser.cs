using System;
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
			foreach (var row in xmlGraph.Element("rows").Elements())
			{
				
			}

			return null;
		}
	}
}
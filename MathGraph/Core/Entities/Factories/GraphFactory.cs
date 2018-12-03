using System;
using System.Linq;
using MathGraph.Core.Utils;

namespace MathGraph.Core.Entities.Factories
{
	public static class GraphFactory
	{
		public static Graph CreateEmptyGraph() => new Graph();
		public static Graph LoadGraphFromFile(string fileName)
		{
			var fileExtension = fileName.Split('.').Last();
			GraphParser parser = null;

			switch (fileExtension)
			{
				case "xml":
					parser = new XMLGraphParser(fileName);
					break;
				case "txt":
					parser = new TextGraphParser(fileName);
					break;
				default:
					throw new NotSupportedException("Unable to use given file extension");
			}

			return parser.Parse();
		}
	}
}
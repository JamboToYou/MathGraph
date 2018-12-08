using System;
using System.Linq;
using MathGraph.Core.Utils;

namespace MathGraph.Core.Entities.Factories
{
	public static class GraphFactory<T, N>
	{
		public static Graph<T, N> CreateEmptyGraph() => new Graph<T, N>();
		public static Graph<T, N> LoadGraphFromFile(string fileName)
		{
			var fileExtension = fileName.Split('.').Last();

			switch (fileExtension)
			{
				case "xml":
					return new XMLGraphParser<T, N>(fileName).Parse();
				case "txt":
					return new TextGraphParser<T, N>(fileName).Parse();
				default:
					throw new NotSupportedException("Unable to use given file extension");
			}
		}
	}
}
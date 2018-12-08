using System;
using MathGraph.Core.Entities;

namespace MathGraph.Core.Utils
{
	public abstract class GraphParser<T, N>
	{
		protected string FileName { get; set; }
		public GraphParser(string fileName)
		{
			FileName = fileName;
		}

		public abstract Graph<T, N> Parse();
	}
}

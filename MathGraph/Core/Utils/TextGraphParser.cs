using MathGraph.Core.Entities;

namespace MathGraph.Core.Utils
{
	public class TextGraphParser<T, N> : GraphParser<T, N>
	{
		public TextGraphParser(string fileName) : base(fileName)
		{
		}

		public override Graph<T, N> Parse()
		{
			throw new System.NotImplementedException();
		}
	}
}
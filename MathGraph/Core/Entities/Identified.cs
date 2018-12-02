namespace MathGraph.Core.Entities
{
	public abstract class Identified
	{
		private static int _nextID = 0;
		public int ID { get; }

		public Identified()
		{
			ID = _nextID++;
		}
	}
}
using System.Collections.Generic;

namespace MathGraph.Applications
{
	public static class BellFord
	{
		private static Graph _graph { get; private set; }
		private static Dictionary<int, Tuple<string, float?>> _paths { get; private set; }
		private static void Init() {}
		private static void Run() {}
		private static string DisplayResult() => null;

		public static Scenario GetScenario() => new Scenario(Init, Run, DisplayResult);
	}
}
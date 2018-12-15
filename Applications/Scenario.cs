namespace MathGraph.Applications
{
	public class Scenario
	{
		public string[] Args { get; private set; }
		public Action<string[]> Init { get; private set; }
		public Action<string[]> Run { get; private set; }
		public Func<string[], string> Display { get; private set; }

		public Scenario(Action<string[]> init, Action<string[]> run, Func<string[], string> display, params string[] args)
		{
			Args = args;
			Init = init;
			Run = run;
			Display = display;
		}
	}
}
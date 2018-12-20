using System;

namespace MathGraph.Applications
{
	public class Scenario
	{
		public Func<string[], bool> Init { get; private set; }
		public Func<string[], bool> Run { get; private set; }
		public Func<string[], string> Display { get; private set; }
		public Func<string> GetError { get; set; }

		public Scenario(Func<string[], bool> init, Func<string[], bool> run, Func<string[], string> display, Func<string> getError)
		{
			Init = init;
			Run = run;
			Display = display;
			GetError = getError;
		}

		public void Invoke(string[] args)
		{
			if (Init(args))
			{
				Run(args);
				Console.WriteLine(Display(args));
			}
			else
			{
				Console.WriteLine(GetError());
			}
		}
	}
}
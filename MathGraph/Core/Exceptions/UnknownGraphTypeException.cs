using System;

namespace MathGraph.Core.Exceptions
{
	public class UnknownGraphTypeException : MathGraphException
	{
		public UnknownGraphTypeException(string message) : base(message) { }
		public UnknownGraphTypeException(string message, Exception inner) : base(message, inner) { }
	}
}

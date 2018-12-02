using System;

namespace MathGraph.Core.Exceptions
{
	public class InvalidNodeReferenceException : MathGraphException
	{
		public InvalidNodeReferenceException(string message) : base(message) { }
		public InvalidNodeReferenceException(string message, Exception inner) : base(message, inner) { }
	}
}
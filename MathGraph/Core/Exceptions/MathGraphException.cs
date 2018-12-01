using System;
using System.Runtime.Serialization;

namespace MathGraph.Core.Exceptions
{
	[System.Serializable]
	public class MathGraphException : Exception
	{
		public MathGraphException() { }
		public MathGraphException(string message) : base(message) { }
		public MathGraphException(string message, Exception inner) : base(message, inner) { }
		protected MathGraphException(
			SerializationInfo info,
			StreamingContext context) : base(info, context) { }
	}
}
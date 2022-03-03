using System.Runtime.Serialization;

namespace Funcable.Core;

[Serializable]
public class InvalidPatternException : Exception
{
	public InvalidPatternException()
	{
	}

	public InvalidPatternException(string message) : base(message) { }

	public InvalidPatternException(string? message, Exception? innerException) : base(message, innerException)
	{
	}

	public InvalidPatternException(Type invokedFromType, string functionName, Type patternType)
		: base($"{invokedFromType.Name}.{functionName}: {patternType.Name}") { }

	protected InvalidPatternException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
}

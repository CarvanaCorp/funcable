namespace Funcable.Core;

public record Error(string Message, string Code = "", object? Context = null) :
	IComparable
{
	public static implicit operator Error(string message) => new(message);

	public override string ToString() => Code switch
	{
		var code when string.IsNullOrWhiteSpace(code) => $"Error {Message}",
		_ => $"Error {Code} {Message}"
	};

	public int CompareTo(object? obj) => obj switch
	{
		Error error => CompareTo(error),
		_ => -1
	};

	public int CompareTo(Error? other)
	{
		if (this is null && other is null) { return 0; }
		if (this is null) { return 1; }
		if (other is null) { return -1; }

		var messageComparison = Message.CompareTo(other.Message);
		if (messageComparison != 0) { return messageComparison; }

		var codeComparison = Code.CompareTo(other.Code);
		if (messageComparison != 0) { return codeComparison; }

		return 0;
	}
}

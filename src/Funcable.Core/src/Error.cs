namespace Funcable.Core;

public record Error(string Message, string Code = "", object? Context = null)
{
	public static implicit operator Error(string message) => new(message);

	public override string ToString() => Code switch
	{
		var code when string.IsNullOrWhiteSpace(code) => $"Error {Message}",
		_ => $"Error {Code} {Message}"
	};
}

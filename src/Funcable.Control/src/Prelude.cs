namespace Funcable.Control;

public static partial class Prelude
{
	public static Error Error(string message, string code = "") =>
		new(message, code);

	public static Unit Unit => new();
}

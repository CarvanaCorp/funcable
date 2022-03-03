using System.Diagnostics.Contracts;

namespace Funcable.Core;

public static class Option
{
	[Pure]
	public static IOption<T> Some<T>(T value)
		where T : notnull =>
		new Some<T>(value);

	[Pure]
	public static IOption<T> None<T>()
		where T : notnull =>
		new None<T>();
}

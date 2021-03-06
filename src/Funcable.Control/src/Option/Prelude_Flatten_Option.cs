using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IOption<T> Flatten<T>(
		IOption<IOption<T>> option)
		where T : notnull =>
		Match(
			option,
			o => o,
			None<T>()
		);
}

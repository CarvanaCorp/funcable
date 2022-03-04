using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IOption<V> Map<T, U, V>(IOption<T> optionT, IOption<U> optionU, Func<T, U, V> mapping)
		where T : notnull
		where U : notnull
		where V : notnull =>
		Match(
			optionT,
			t => Match(
				optionU,
				u => Some(mapping(t, u)),
				None<V>()
			),
			None<V>()
		);

	[Pure]
	public static IOption<X> Map<T, U, V, X>(
		IOption<T> optionT,
		IOption<U> optionU,
		IOption<V> optionV,
		Func<T, U, V, X> mapping)
		where T : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		Match(
			optionT,
			t => Match(
				optionU,
				u => Match(
					optionV,
					v => Some(mapping(t, u, v)),
					None<X>()
				),
				None<X>()
			),
			None<X>()
		);
}

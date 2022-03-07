using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IOption<V>> Map<T, U, V>(
		Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Func<T, U, V> mapping)
		where T : notnull
		where U : notnull
		where V : notnull =>
		Map(
			optionT,
			optionU,
			async (t, u) => await Task.FromResult(mapping(t, u)).ConfigureAwait(false)
		);

	[Pure]
	public static Task<IOption<V>> Map<T, U, V>(
		Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Func<T, U, Task<V>> mapping)
		where T : notnull
		where U : notnull
		where V : notnull =>
		Match(
			optionT,
			async t => await Match(
				optionU,
				async u => await AsyncSome(await mapping(t, u).ConfigureAwait(false)).ConfigureAwait(false),
				async () => await AsyncNone<V>().ConfigureAwait(false)
			)
			.ConfigureAwait(false),
			async () => await AsyncNone<V>().ConfigureAwait(false)
		);

	[Pure]
	public static Task<IOption<X>> Map<T, U, V, X>(
		Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Task<IOption<V>> optionV,
		Func<T, U, V, X> mapping)
		where T : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		Map(
			optionT,
			optionU,
			optionV,
			async (t, u, v) => await Task.FromResult(mapping(t, u, v)).ConfigureAwait(false)
		);

	[Pure]
	public static Task<IOption<X>> Map<T, U, V, X>(
		Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Task<IOption<V>> optionV,
		Func<T, U, V, Task<X>> mapping)
		where T : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		Match(
			optionT,
			async t => await Match(
				optionU,
				async u => await Match(
					optionV,
					async v => await AsyncSome(await mapping(t, u, v).ConfigureAwait(false)).ConfigureAwait(false),
					async () => await AsyncNone<X>().ConfigureAwait(false)
				)
				.ConfigureAwait(false),
				async () => await AsyncNone<X>().ConfigureAwait(false)
			)
			.ConfigureAwait(false),
			async () => await AsyncNone<X>().ConfigureAwait(false)
		);
}

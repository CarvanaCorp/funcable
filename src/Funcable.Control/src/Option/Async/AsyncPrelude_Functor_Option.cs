using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IOption<U>> Map<T, U>(
		Task<IOption<T>> option,
		Func<T, U> mapping)
		where T : notnull
		where U : notnull =>
		Map(
			option,
			async t => await Task.FromResult(mapping(t)).ConfigureAwait(false)
		);

	[Pure]
	public static Task<IOption<U>> Map<T, U>(
		Task<IOption<T>> option,
		Func<T, Task<U>> mapping)
		where T : notnull
		where U : notnull =>
		Match(
			option,
			async t => await AsyncSome(await mapping(t).ConfigureAwait(false)).ConfigureAwait(false),
			async () => await AsyncNone<U>().ConfigureAwait(false)
		);
}

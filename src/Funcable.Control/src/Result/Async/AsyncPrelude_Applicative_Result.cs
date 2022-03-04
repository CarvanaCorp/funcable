using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IResult<V, TError>> Map<T, TError, U, V>(
		Task<IResult<T, TError>> resultT,
		Task<IResult<U, TError>> resultU,
		Func<T, U, V> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where V : notnull =>
		Map(resultT, resultU, async (t, u) => await Task.FromResult(mapping(t, u)).ConfigureAwait(false));

	[Pure]
	public static Task<IResult<V, TError>> Map<T, TError, U, V>(
		Task<IResult<T, TError>> resultT,
		Task<IResult<U, TError>> resultU,
		Func<T, U, Task<V>> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where V : notnull =>
		Match(
			resultT,
			async t => await Match(
				resultU,
				async u => await AsyncOk<V, TError>(await mapping(t, u).ConfigureAwait(false)).ConfigureAwait(false),
				async e => await AsyncError<V, TError>(e).ConfigureAwait(false)
			)
			.ConfigureAwait(false),
			async e => await AsyncError<V, TError>(e).ConfigureAwait(false)
		);

	[Pure]
	public static Task<IResult<X, TError>> Map<T, TError, U, V, X>(
		Task<IResult<T, TError>> resultT,
		Task<IResult<U, TError>> resultU,
		Task<IResult<V, TError>> resultV,
		Func<T, U, V, X> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		Map(resultT, resultU, resultV, async (t, u, v) => await Task.FromResult(mapping(t, u, v)).ConfigureAwait(false));

	[Pure]
	public static Task<IResult<X, TError>> Map<T, TError, U, V, X>(
		Task<IResult<T, TError>> resultT,
		Task<IResult<U, TError>> resultU,
		Task<IResult<V, TError>> resultV,
		Func<T, U, V, Task<X>> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		Match(
			resultT,
			async t => await Match(
				resultU,
				async u => await Match(
					resultV,
					async v => await AsyncOk<X, TError>(await mapping(t, u, v).ConfigureAwait(false)).ConfigureAwait(false),
					async e => await AsyncError<X, TError>(e).ConfigureAwait(false)
				)
				.ConfigureAwait(false),
				async e => await AsyncError<X, TError>(e).ConfigureAwait(false)
			)
			.ConfigureAwait(false),
			async e => await AsyncError<X, TError>(e).ConfigureAwait(false)
		);
}

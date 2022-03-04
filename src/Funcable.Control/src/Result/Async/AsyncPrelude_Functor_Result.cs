using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IResult<U, TError>> Map<T, TError, U>(
		Task<IResult<T, TError>> result,
		Func<T, U> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Map(result, async t => await Task.FromResult(mapping(t)).ConfigureAwait(false));

	[Pure]
	public static Task<IResult<U, TError>> Map<T, TError, U>(
		Task<IResult<T, TError>> result,
		Func<T, Task<U>> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Match(
			result,
			async t => await AsyncOk<U, TError>(await mapping(t).ConfigureAwait(false)).ConfigureAwait(false),
			async e => await AsyncError<U, TError>(e).ConfigureAwait(false)
		);
}

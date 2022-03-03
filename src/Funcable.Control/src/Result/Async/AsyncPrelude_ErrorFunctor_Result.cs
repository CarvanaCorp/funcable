using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IResult<T, UError>> MapError<T, TError, UError>(
		Task<IResult<T, TError>> result,
		Func<TError, UError> mapping)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		MapError(result, async e => await Task.FromResult(mapping(e)).ConfigureAwait(false));

	[Pure]
	public static Task<IResult<T, UError>> MapError<T, TError, UError>(
		Task<IResult<T, TError>> result,
		Func<TError, Task<UError>> mapping)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		Match(
			result,
			async t => await AsyncOk<T, UError>(t).ConfigureAwait(false),
			async e => await AsyncError<T, UError>(await mapping(e).ConfigureAwait(false)).ConfigureAwait(false)
		);
}

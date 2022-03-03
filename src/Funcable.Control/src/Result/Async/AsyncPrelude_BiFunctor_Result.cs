using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IResult<U, UError>> BiMap<T, TError, U, UError>(
		Task<IResult<T, TError>> result,
		Func<T, U> okMapping,
		Func<TError, UError> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		BiMap(
			result,
			async t => await Task.FromResult(okMapping(t)).ConfigureAwait(false),
			async e => await Task.FromResult(errorMapping(e)).ConfigureAwait(false)
		);

	[Pure]
	public static Task<IResult<U, UError>> BiMap<T, TError, U, UError>(
		Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMapping,
		Func<TError, UError> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		BiMap(
			result,
			async t => await okMapping(t).ConfigureAwait(false),
			async e => await Task.FromResult(errorMapping(e)).ConfigureAwait(false)
		);

	[Pure]
	public static Task<IResult<U, UError>> BiMap<T, TError, U, UError>(
		Task<IResult<T, TError>> result,
		Func<T, U> okMapping,
		Func<TError, Task<UError>> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		BiMap(
			result,
			async t => await Task.FromResult(okMapping(t)).ConfigureAwait(false),
			async e => await errorMapping(e).ConfigureAwait(false)
		);


	[Pure]
	public static Task<IResult<U, UError>> BiMap<T, TError, U, UError>(
		Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMapping,
		Func<TError, Task<UError>> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Match(
			result,
			async t => await AsyncOk<U, UError>(await okMapping(t).ConfigureAwait(false)).ConfigureAwait(false),
			async e => await AsyncError<U, UError>(await errorMapping(e).ConfigureAwait(false)).ConfigureAwait(false)
		);
}

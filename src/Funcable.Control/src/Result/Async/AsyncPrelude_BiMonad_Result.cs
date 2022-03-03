using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IResult<U, UError>> BiBind<T, TError, U, UError>(
		Task<IResult<T, TError>> result,
		Func<T, IResult<U, UError>> okBinder,
		Func<TError, IResult<U, UError>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		BiBind(
			result,
			async t => await Task.FromResult(okBinder(t)).ConfigureAwait(false),
			async e => await Task.FromResult(errorBinder(e)).ConfigureAwait(false)
		);

	[Pure]
	public static Task<IResult<U, UError>> BiBind<T, TError, U, UError>(
		Task<IResult<T, TError>> result,
		Func<T, IResult<U, UError>> okBinder,
		Func<TError, Task<IResult<U, UError>>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		BiBind(
			result,
			async t => await Task.FromResult(okBinder(t)).ConfigureAwait(false),
			async e => await errorBinder(e).ConfigureAwait(false)
		);

	[Pure]
	public static Task<IResult<U, UError>> BiBind<T, TError, U, UError>(
		Task<IResult<T, TError>> result,
		Func<T, Task<IResult<U, UError>>> okBinder,
		Func<TError, IResult<U, UError>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		BiBind(
			result,
			async t => await okBinder(t).ConfigureAwait(false),
			async e => await Task.FromResult(errorBinder(e)).ConfigureAwait(false)
		);

	[Pure]
	public static Task<IResult<U, UError>> BiBind<T, TError, U, UError>(
		Task<IResult<T, TError>> result,
		Func<T, Task<IResult<U, UError>>> okBinder,
		Func<TError, Task<IResult<U, UError>>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Match(
			result,
			async t => await okBinder(t).ConfigureAwait(false),
			async e => await errorBinder(e).ConfigureAwait(false)
		);
}

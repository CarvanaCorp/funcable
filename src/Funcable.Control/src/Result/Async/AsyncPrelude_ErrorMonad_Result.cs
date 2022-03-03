using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IResult<T, UError>> BindError<T, TError, UError>(
		Task<IResult<T, TError>> result,
		Func<TError, IResult<T, UError>> binder)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		BindError(result, async e => await Task.FromResult(binder(e)).ConfigureAwait(false));

	[Pure]
	public static Task<IResult<T, UError>> BindError<T, TError, UError>(
		Task<IResult<T, TError>> result,
		Func<TError, Task<IResult<T, UError>>> binder)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		Match(
			result,
			async t => await AsyncOk<T, UError>(t).ConfigureAwait(false),
			async e => await binder(e).ConfigureAwait(false)
		);
}

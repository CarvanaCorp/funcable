using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IResult<U, TError>> Bind<T, TError, U>(
		Task<IResult<T, TError>> result,
		Func<T, IResult<U, TError>> binder)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Bind(result, async t => await Task.FromResult(binder(t)).ConfigureAwait(false));

	[Pure]
	public static Task<IResult<U, TError>> Bind<T, TError, U>(
		Task<IResult<T, TError>> result,
		Func<T, Task<IResult<U, TError>>> binder)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Match(
			result,
			async t => await binder(t).ConfigureAwait(false),
			async e => await AsyncError<U, TError>(e).ConfigureAwait(false)
		);
}

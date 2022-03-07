using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IResult<T, TError>> Flatten<T, TError>(
		Task<IResult<Task<IResult<T, TError>>, TError>> result)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			async r => await r.ConfigureAwait(false),
			async e => await AsyncError<T, TError>(e).ConfigureAwait(false)
		);

	[Pure]
	public static Task<IResult<T, TError>> Flatten<T, TError>(
		Task<IResult<IResult<T, TError>, TError>> result)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			r => r,
			e => Error<T, TError>(e)
		);

	[Pure]
	public static Task<IResult<T, TError>> Flatten<T, TError>(
		IResult<Task<IResult<T, TError>>, TError> result)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			r => r,
			e => AsyncError<T, TError>(e)
		);
}

using System.Diagnostics.Contracts;

namespace Funcable.Core;

public static class Result
{
	[Pure]
	public static IResult<T, TError> Ok<T, TError>(T value)
		where T : notnull
		where TError : notnull =>
		new Ok<T, TError>(value);

	[Pure]
	public static IResult<T, TError> Error<T, TError>(TError error)
		where T : notnull
		where TError : notnull =>
		new Error<T, TError>(error);
}

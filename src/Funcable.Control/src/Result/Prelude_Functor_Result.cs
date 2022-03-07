using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IResult<U, TError> Map<T, TError, U>(
		IResult<T, TError> result,
		Func<T, U> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Match(
			result,
			t => Ok<U, TError>(mapping(t)),
			e => Error<U, TError>(e)
		);
}

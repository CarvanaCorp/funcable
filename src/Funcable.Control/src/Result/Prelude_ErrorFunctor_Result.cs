using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IResult<T, UError> MapError<T, TError, UError>(
		IResult<T, TError> result,
		Func<TError, UError> mapping)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		Match(
			result,
			t => Ok<T, UError>(t),
			e => Error<T, UError>(mapping(e))
		);
}

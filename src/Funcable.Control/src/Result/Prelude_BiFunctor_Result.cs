using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IResult<U, UError> BiMap<T, TError, U, UError>(
		IResult<T, TError> result,
		Func<T, U> okMapping,
		Func<TError, UError> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Match(
			result,
			t => Ok<U, UError>(okMapping(t)),
			e => Error<U, UError>(errorMapping(e))
		);
}

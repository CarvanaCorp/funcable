using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IResult<T, TError> Flatten<T, TError>(
		IResult<IResult<T, TError>, TError> result)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			r => r,
			e => Error<T, TError>(e)
		);
}

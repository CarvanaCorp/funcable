using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IResult<T, UError> BindError<T, TError, UError>(
		IResult<T, TError> result,
		Func<TError, IResult<T, UError>> binder)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		Match(
			result,
			t => Ok<T, UError>(t),
			binder
		);
}

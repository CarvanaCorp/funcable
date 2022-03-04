using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IResult<U, TError> Bind<T, TError, U>(
		IResult<T, TError> result,
		Func<T, IResult<U, TError>> binder)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Match(
			result,
			binder,
			e => Error<U, TError>(e)
		);
}

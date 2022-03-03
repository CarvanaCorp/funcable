using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IResult<U, UError> BiBind<T, TError, U, UError>(
		IResult<T, TError> result,
		Func<T, IResult<U, UError>> okBinder,
		Func<TError, IResult<U, UError>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Match(
			result,
			okBinder,
			errorBinder
		);
}

using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IResult<V, TError> Map<T, TError, U, V>(
		IResult<T, TError> resultT,
		IResult<U, TError> resultU,
		Func<T, U, V> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where V : notnull =>
		Match(
			resultT,
			t => Match(
				resultU,
				u => Ok<V, TError>(mapping(t, u)),
				e => Error<V, TError>(e)
			),
			e => Error<V, TError>(e)
		);

	[Pure]
	public static IResult<X, TError> Map<T, TError, U, V, X>(
		IResult<T, TError> resultT,
		IResult<U, TError> resultU,
		IResult<V, TError> resultV,
		Func<T, U, V, X> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		Match(
			resultT,
			t => Match(
				resultU,
				u => Match(
					resultV,
					v => Ok<X, TError>(mapping(t, u, v)),
					e => Error<X, TError>(e)
				),
				e => Error<X, TError>(e)
			),
			e => Error<X, TError>(e)
		);
}

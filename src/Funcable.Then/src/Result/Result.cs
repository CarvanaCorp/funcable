using System.Diagnostics.Contracts;
using Funcable.Control;
using Funcable.Core;

namespace Funcable.Then;

public static class Result
{
	[Pure]
	public static IResult<U, TError> Then<T, TError, U>(
		this IResult<T, TError> result,
		Func<T, U> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result.Map(mapping);

	[Pure]
	public static IResult<V, TError> Then<T, TError, U, V>(
		this IResult<T, TError> resultT,
		IResult<U, TError> resultU,
		Func<T, U, V> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where V : notnull =>
		resultT.Map(resultU, mapping);

	[Pure]
	public static IResult<X, TError> Then<T, TError, U, V, X>(
		this IResult<T, TError> resultT,
		IResult<U, TError> resultU,
		IResult<V, TError> resultV,
		Func<T, U, V, X> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		resultT.Map(resultU, resultV, mapping);

	[Pure]
	public static IResult<U, UError> Then<T, TError, U, UError>(
		this IResult<T, TError> result,
		Func<T, U> okMapping,
		Func<TError, UError> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		result.BiMap(okMapping, errorMapping);

	[Pure]
	public static IResult<U, TError> Then<T, TError, U>(
		this IResult<T, TError> result,
		Func<T, IResult<U, TError>> binder)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result.Bind(binder);

	[Pure]
	public static IResult<U, UError> Then<T, TError, U, UError>(
		this IResult<T, TError> result,
		Func<T, IResult<U, UError>> okBinder,
		Func<TError, IResult<U, UError>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		result.BiBind(okBinder, errorBinder);

	[Pure]
	public static IResult<T, UError> Catch<T, TError, UError>(
		this IResult<T, TError> result,
		Func<TError, UError> mapping)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		result.MapError(mapping);

	[Pure]
	public static IResult<T, UError> Catch<T, TError, UError>(
		this IResult<T, TError> result,
		Func<TError, IResult<T, UError>> binder)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		result.BindError(binder);

	[Pure]
	public static U Finally<T, TError, U>(
		this IResult<T, TError> result,
		Func<T, U> okMatch,
		Func<TError, U> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result.Match(okMatch, errorMatch);
}

using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static class IResultExtensions
{
	[Pure]
	public static IResult<U, TError> Map<T, TError, U>(
		this IResult<T, TError> result,
		Func<T, U> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Prelude.Map(result, mapping);

	[Pure]
	public static IResult<V, TError> Map<T, TError, U, V>(
		this IResult<T, TError> resultT,
		IResult<U, TError> resultU,
		Func<T, U, V> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where V : notnull =>
		Prelude.Map(resultT, resultU, mapping);

	[Pure]
	public static IResult<X, TError> Map<T, TError, U, V, X>(
		this IResult<T, TError> resultT,
		IResult<U, TError> resultU,
		IResult<V, TError> resultV,
		Func<T, U, V, X> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		Prelude.Map(resultT, resultU, resultV, mapping);

	[Pure]
	public static IResult<T, UError> MapError<T, TError, UError>(
		this IResult<T, TError> result,
		Func<TError, UError> mapping)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		Prelude.MapError(result, mapping);

	[Pure]
	public static IResult<U, UError> BiMap<T, TError, U, UError>(
		this IResult<T, TError> result,
		Func<T, U> okMapping,
		Func<TError, UError> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Prelude.BiMap(result, okMapping, errorMapping);

	[Pure]
	public static IResult<U, TError> Bind<T, TError, U>(
		this IResult<T, TError> result,
		Func<T, IResult<U, TError>> binder)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Prelude.Bind(result, binder);

	[Pure]
	public static IResult<T, UError> BindError<T, TError, UError>(
		this IResult<T, TError> result,
		Func<TError, IResult<T, UError>> binder)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		Prelude.BindError(result, binder);

	[Pure]
	public static IResult<U, UError> BiBind<T, TError, U, UError>(
		this IResult<T, TError> result,
		Func<T, IResult<U, UError>> okBinder,
		Func<TError, IResult<U, UError>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Prelude.BiBind(result, okBinder, errorBinder);

	[Pure]
	public static TState Fold<T, TError, TState>(
		this IResult<T, TError> result,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		Prelude.Fold(result, state, folder);

	[Pure]
	public static TState FoldError<T, TError, TState>(
		this IResult<T, TError> result,
		TState state,
		Func<TState, TError, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		Prelude.FoldError(result, state, folder);

	[Pure]
	public static TState BiFold<T, TError, TState>(
		this IResult<T, TError> result,
		TState state,
		Func<TState, T, TState> okFolder,
		Func<TState, TError, TState> errorFolder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		Prelude.BiFold(result, state, okFolder, errorFolder);

	public static Unit Iterate<T, TError>(
		this IResult<T, TError> result,
		Action<T> iterator)
		where T : notnull
		where TError : notnull =>
		Prelude.Iterate(result, iterator);

	public static Unit IterateError<T, TError>(
		this IResult<T, TError> result,
		Action<TError> iterator)
		where T : notnull
		where TError : notnull =>
		Prelude.IterateError(result, iterator);

	public static Unit BiIterate<T, TError>(
		this IResult<T, TError> result,
		Action<T> okIterator,
		Action<TError> errorIterator)
		where T : notnull
		where TError : notnull =>
		Prelude.BiIterate(result, okIterator, errorIterator);

	[Pure]
	public static IResult<T, TError> Flatten<T, TError>(
		this IResult<IResult<T, TError>, TError> result)
		where T : notnull
		where TError : notnull =>
		Prelude.Flatten(result);

	[Pure]
	public static T FromOk<T, TError>(this IResult<T, TError> result)
		where T : notnull
		where TError : notnull =>
		Prelude.FromOk(result);

	[Pure]
	public static TError FromError<T, TError>(this IResult<T, TError> result)
		where T : notnull
		where TError : notnull =>
		Prelude.FromError(result);

	[Pure]
	public static bool IsOk<T, TError>(this IResult<T, TError> result)
		where T : notnull
		where TError : notnull =>
		Prelude.IsOk(result);

	[Pure]
	public static bool IsError<T, TError>(this IResult<T, TError> result)
		where T : notnull
		where TError : notnull =>
		Prelude.IsError(result);

	[Pure]
	public static IOption<T> AsOption<T, TError>(this IResult<T, TError> result)
		where T : notnull
		where TError : notnull =>
		Prelude.AsOption(result);

	[Pure]
	public static IResult<T, TError> OnOk<T, TError>(this IResult<T, TError> result, Action<T> handler)
		where T : notnull
		where TError : notnull =>
		Prelude.OnOk(result, handler);

	[Pure]
	public static IResult<T, TError> OnError<T, TError>(this IResult<T, TError> result, Action<TError> handler)
		where T : notnull
		where TError : notnull =>
		Prelude.OnError(result, handler);

	[Pure]
	public static U Match<T, TError, U>(
		this IResult<T, TError> result,
		Func<T, U> okMatch,
		Func<TError, U> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Prelude.Match(result, okMatch, errorMatch);
}

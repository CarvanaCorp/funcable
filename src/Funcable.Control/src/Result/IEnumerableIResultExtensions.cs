using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static class IEnumerableIResultExtensions
{
	[Pure]
	public static TState Fold<T, TError, TState>(
		this IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		Prelude.Fold(results, state, folder);

	[Pure]
	public static TState FoldError<T, TError, TState>(
		this IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, TError, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		Prelude.FoldError(results, state, folder);

	[Pure]
	public static TState BiFold<T, TError, TState>(
		this IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, T, TState> okFolder,
		Func<TState, TError, TState> errorFolder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		Prelude.BiFold(results, state, okFolder, errorFolder);

	[Pure]
	public static TState FoldBack<T, TError, TState>(
		this IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		Prelude.FoldBack(results, state, folder);

	[Pure]
	public static TState FoldErrorBack<T, TError, TState>(
		this IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, TError, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		Prelude.FoldErrorBack(results, state, folder);

	[Pure]
	public static TState BiFoldBack<T, TError, TState>(
		this IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, T, TState> okFolder,
		Func<TState, TError, TState> errorFolder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		Prelude.BiFoldBack(results, state, okFolder, errorFolder);

	public static Unit Iterate<T, TError>(
		this IEnumerable<IResult<T, TError>> results,
		Action<T> iterator)
		where T : notnull
		where TError : notnull =>
		Prelude.Iterate(results, iterator);

	public static Unit IterateError<T, TError>(
		this IEnumerable<IResult<T, TError>> results,
		Action<TError> iterator)
		where T : notnull
		where TError : notnull =>
		Prelude.IterateError(results, iterator);

	public static Unit BiIterate<T, TError>(
		this IEnumerable<IResult<T, TError>> results,
		Action<T> okIterator,
		Action<TError> errorIterator)
		where T : notnull
		where TError : notnull =>
		Prelude.BiIterate(results, okIterator, errorIterator);

	[Pure]
	public static (IEnumerable<T> Oks, IEnumerable<TError> Errors) Partition<T, TError>(
		this IEnumerable<IResult<T, TError>> results)
		where T : notnull
		where TError : notnull =>
		Prelude.Partition(results);
}

using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static TState Fold<T, TError, TState>(
		IResult<T, TError> result,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		Fold(new[] { result }, state, folder);

	[Pure]
	public static TState Fold<T, TError, TState>(
		IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull => results.Count() switch
		{
			> 0 => results.Aggregate(state, (state, result) =>
				result.Match(t => folder(state, t), _ => state)),
			_ => state
		};

	[Pure]
	public static TState FoldError<T, TError, TState>(
		IResult<T, TError> result,
		TState state,
		Func<TState, TError, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		FoldError(new[] { result }, state, folder);

	[Pure]
	public static TState FoldError<T, TError, TState>(
		IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, TError, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull => results.Count() switch
		{
			> 0 => results.Aggregate(state, (state, result) =>
				result.Match(_ => state, error => folder(state, error))),
			_ => state
		};

	[Pure]
	public static TState BiFold<T, TError, TState>(
		IResult<T, TError> result,
		TState state,
		Func<TState, T, TState> okFolder,
		Func<TState, TError, TState> errorFolder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		BiFold(new[] { result }, state, okFolder, errorFolder);

	[Pure]
	public static TState BiFold<T, TError, TState>(
		IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, T, TState> okFolder,
		Func<TState, TError, TState> errorFolder)
		where T : notnull
		where TError : notnull
		where TState : notnull => results.Count() switch
		{
			> 0 => results.Aggregate(state, (state, result) =>
				result.Match(t => okFolder(state, t), error => errorFolder(state, error))),
			_ => state
		};

	[Pure]
	public static TState FoldBack<T, TError, TState>(
		IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		Fold(results.Reverse(), state, folder);

	[Pure]
	public static TState FoldErrorBack<T, TError, TState>(
		IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, TError, TState> folder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		FoldError(results.Reverse(), state, folder);

	[Pure]
	public static TState BiFoldBack<T, TError, TState>(
		IEnumerable<IResult<T, TError>> results,
		TState state,
		Func<TState, T, TState> okFolder,
		Func<TState, TError, TState> errorFolder)
		where T : notnull
		where TError : notnull
		where TState : notnull =>
		BiFold(results.Reverse(), state, okFolder, errorFolder);
}

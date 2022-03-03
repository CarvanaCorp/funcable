using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static TState Fold<T, TState>(
		IOption<T> option,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TState : notnull =>
		Fold(new[] { option }, state, folder);

	[Pure]
	public static TState Fold<T, TState>(
		IEnumerable<IOption<T>> options,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TState : notnull => options.Count() switch
		{
			> 0 => options.Aggregate(state, (state, option) =>
				option.Match(t => folder(state, t), () => state)),
			_ => state
		};

	[Pure]
	public static TState FoldBack<T, TState>(
		IOption<T> option,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TState : notnull =>
		FoldBack(new[] { option }, state, folder);

	[Pure]
	public static TState FoldBack<T, TState>(
		IEnumerable<IOption<T>> options,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TState : notnull =>
		Fold(options.Reverse(), state, folder);
}

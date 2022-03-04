using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static class IEnumerableIOptionExtensions
{
	[Pure]
	public static TState Fold<T, TState>(
		this IEnumerable<IOption<T>> options,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TState : notnull =>
		Prelude.Fold(options, state, folder);

	[Pure]
	public static TState FoldBack<T, TState>(
		this IEnumerable<IOption<T>> options,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TState : notnull =>
		Prelude.FoldBack(options, state, folder);

	public static Unit Iterate<T>(
		this IEnumerable<IOption<T>> options,
		Action<T> iterator)
		where T : notnull =>
		Prelude.Iterate(options, iterator);
}

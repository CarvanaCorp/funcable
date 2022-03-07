using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static class IOptionExtensions
{
	[Pure]
	public static IOption<U> Map<T, U>(
		this IOption<T> option,
		Func<T, U> mapping)
		where T : notnull
		where U : notnull =>
		Prelude.Map(option, mapping);

	[Pure]
	public static IOption<V> Map<T, U, V>(
		this IOption<T> optionT,
		IOption<U> optionU,
		Func<T, U, V> mapping)
		where T : notnull
		where U : notnull
		where V : notnull =>
		Prelude.Map(optionT, optionU, mapping);

	[Pure]
	public static IOption<X> Map<T, U, V, X>(
		this IOption<T> optionT,
		IOption<U> optionU,
		IOption<V> optionV,
		Func<T, U, V, X> mapping)
		where T : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		Prelude.Map(optionT, optionU, optionV, mapping);

	[Pure]
	public static IOption<U> Bind<T, U>(
		this IOption<T> option,
		Func<T, IOption<U>> binder)
		where T : notnull
		where U : notnull =>
		Prelude.Bind(option, binder);

	[Pure]
	public static TState Fold<T, TState>(
		this IOption<T> option,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TState : notnull =>
		Prelude.Fold(option, state, folder);

	[Pure]
	public static TState FoldBack<T, TState>(
		this IOption<T> option,
		TState state,
		Func<TState, T, TState> folder)
		where T : notnull
		where TState : notnull =>
		Prelude.FoldBack(option, state, folder);

	public static Unit Iterate<T>(
		this IOption<T> option,
		Action<T> iterator)
		where T : notnull =>
		Prelude.Iterate(option, iterator);

	[Pure]
	public static IOption<T> Flatten<T>(
		this IOption<IOption<T>> option)
		where T : notnull =>
		Prelude.Flatten(option);

	[Pure]
	public static T FromSome<T>(this IOption<T> option)
		where T : notnull =>
		Prelude.FromSome(option);

	[Pure]
	public static bool IsSome<T>(this IOption<T> option)
		where T : notnull =>
		Prelude.IsSome(option);

	[Pure]
	public static bool IsNone<T>(this IOption<T> option)
		where T : notnull =>
		Prelude.IsNone(option);

	[Pure]
	public static Task<IResult<T, Error>> AsAsyncResult<T>(this IOption<T> option)
		where T : notnull =>
		Prelude.AsAsyncResult(option);

	[Pure]
	public static IResult<T, Error> AsResult<T>(this IOption<T> option)
		where T : notnull =>
		Prelude.AsResult(option);

	[Pure]
	public static IOption<T> OnSome<T>(this IOption<T> option, Action<T> handler)
		where T : notnull =>
		Prelude.OnSome(option, handler);

	[Pure]
	public static IOption<T> OnNone<T>(this IOption<T> option, Action handler)
		where T : notnull =>
		Prelude.OnNone(option, handler);

	[Pure]
	public static U Match<T, U>(
		this IOption<T> option,
		Func<T, U> someMatch,
		U defaultValue)
		where T : notnull
		where U : notnull =>
		Prelude.Match(option, someMatch, defaultValue);

	[Pure]
	public static U Match<T, U>(
		this IOption<T> option,
		Func<T, U> someMatch,
		Func<U> noneMatch)
		where T : notnull
		where U : notnull =>
		Prelude.Match(option, someMatch, noneMatch);
}

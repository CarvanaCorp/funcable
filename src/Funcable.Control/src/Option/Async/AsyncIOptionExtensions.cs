using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static class TaskIOptionExtensions
{
	[Pure]
	public static Task<IOption<U>> Map<T, U>(
		this Task<IOption<T>> option,
		Func<T, U> mapping)
		where T : notnull
		where U : notnull =>
		Prelude.Map(option, mapping);

	[Pure]
	public static Task<IOption<U>> Map<T, U>(
		this Task<IOption<T>> option,
		Func<T, Task<U>> mapping)
		where T : notnull
		where U : notnull =>
		Prelude.Map(option, mapping);

	[Pure]
	public static Task<IOption<V>> Map<T, U, V>(
		this Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Func<T, U, V> mapping)
		where T : notnull
		where U : notnull
		where V : notnull =>
		Prelude.Map(optionT, optionU, mapping);

	[Pure]
	public static Task<IOption<V>> Map<T, U, V>(
		this Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Func<T, U, Task<V>> mapping)
		where T : notnull
		where U : notnull
		where V : notnull =>
		Prelude.Map(optionT, optionU, mapping);

	[Pure]
	public static Task<IOption<X>> Map<T, U, V, X>(
		this Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Task<IOption<V>> optionV,
		Func<T, U, V, X> mapping)
		where T : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		Prelude.Map(optionT, optionU, optionV, mapping);

	[Pure]
	public static Task<IOption<X>> Map<T, U, V, X>(
		this Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Task<IOption<V>> optionV,
		Func<T, U, V, Task<X>> mapping)
		where T : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		Prelude.Map(optionT, optionU, optionV, mapping);

	[Pure]
	public static Task<IOption<U>> Bind<T, U>(
		this Task<IOption<T>> option,
		Func<T, IOption<U>> binder)
		where T : notnull
		where U : notnull =>
		Prelude.Bind(option, binder);

	[Pure]
	public static Task<IOption<U>> Bind<T, U>(
		this Task<IOption<T>> option,
		Func<T, Task<IOption<U>>> binder)
		where T : notnull
		where U : notnull =>
		Prelude.Bind(option, binder);

	[Pure]
	public static Task<IOption<T>> Flatten<T>(
		this Task<IOption<Task<IOption<T>>>> option)
		where T : notnull =>
		Prelude.Flatten(option);

	[Pure]
	public static Task<IOption<T>> Flatten<T>(
		this Task<IOption<IOption<T>>> option)
		where T : notnull =>
		Prelude.Flatten(option);

	[Pure]
	public static Task<IOption<T>> Flatten<T>(
		this IOption<Task<IOption<T>>> option)
		where T : notnull =>
		Prelude.Flatten(option);

	[Pure]
	public static Task<bool> IsSome<T>(this Task<IOption<T>> option)
		where T : notnull =>
		Prelude.IsSome(option);

	[Pure]
	public static Task<bool> IsNone<T>(this Task<IOption<T>> option)
		where T : notnull =>
		Prelude.IsNone(option);

	[Pure]
	public static Task<T> FromSome<T>(this Task<IOption<T>> option)
		where T : notnull =>
		Prelude.FromSome(option);

	[Pure]
	public static Task<IOption<T>> OnSome<T>(
		this Task<IOption<T>> option,
		Action<T> handler)
		where T : notnull =>
		Prelude.OnSome(option, handler);

	[Pure]
	public static Task<IOption<T>> OnSome<T>(
		this Task<IOption<T>> option,
		Func<T, Task> handler)
		where T : notnull =>
		Prelude.OnSome(option, handler);

	[Pure]
	public static Task<IOption<T>> OnNone<T>(
		this Task<IOption<T>> option,
		Action handler)
		where T : notnull =>
		Prelude.OnNone(option, handler);

	[Pure]
	public static Task<IOption<T>> OnNone<T>(
		this Task<IOption<T>> option,
		Func<Task> handler)
		where T : notnull =>
		Prelude.OnNone(option, handler);

	[Pure]
	public static Task<U> Match<T, U>(
		this Task<IOption<T>> option,
		Func<T, U> someMatch,
		Func<U> noneMatch)
		where T : notnull
		where U : notnull =>
		Prelude.Match(option, someMatch, noneMatch);

	[Pure]
	public static Task<U> Match<T, U>(
		this Task<IOption<T>> option,
		Func<T, Task<U>> someMatch,
		Func<U> noneMatch)
		where T : notnull
		where U : notnull =>
		Prelude.Match(option, someMatch, noneMatch);

	[Pure]
	public static Task<U> Match<T, U>(
		this Task<IOption<T>> option,
		Func<T, U> someMatch,
		Func<Task<U>> noneMatch)
		where T : notnull
		where U : notnull =>
		Prelude.Match(option, someMatch, noneMatch);

	[Pure]
	public static Task<U> Match<T, U>(
		this Task<IOption<T>> option,
		Func<T, Task<U>> someMatch,
		Func<Task<U>> noneMatch)
		where T : notnull
		where U : notnull =>
		Prelude.Match(option, someMatch, noneMatch);
}

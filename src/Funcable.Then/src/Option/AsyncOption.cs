using System.Diagnostics.Contracts;

namespace Funcable.Then;

public static class AsyncOption
{
	[Pure]
	public static Task<IOption<U>> Then<T, U>(
		this Task<IOption<T>> option,
		Func<T, U> mapping)
		where T : notnull
		where U : notnull =>
		option.Map(mapping);

	[Pure]
	public static Task<IOption<U>> Then<T, U>(
		this Task<IOption<T>> option,
		Func<T, Task<U>> mapping)
		where T : notnull
		where U : notnull =>
		option.Map(mapping);

	[Pure]
	public static Task<IOption<V>> Then<T, U, V>(
		this Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Func<T, U, V> mapping)
		where T : notnull
		where U : notnull
		where V : notnull =>
		optionT.Map(optionU, mapping);

	[Pure]
	public static Task<IOption<V>> Then<T, U, V>(
		this Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Func<T, U, Task<V>> mapping)
		where T : notnull
		where U : notnull
		where V : notnull =>
		optionT.Map(optionU, mapping);

	[Pure]
	public static Task<IOption<X>> Then<T, U, V, X>(
		this Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Task<IOption<V>> optionV,
		Func<T, U, V, X> mapping)
		where T : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		optionT.Map(optionU, optionV, mapping);

	[Pure]
	public static Task<IOption<X>> Then<T, U, V, X>(
		this Task<IOption<T>> optionT,
		Task<IOption<U>> optionU,
		Task<IOption<V>> optionV,
		Func<T, U, V, Task<X>> mapping)
		where T : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		optionT.Map(optionU, optionV, mapping);

	[Pure]
	public static Task<IOption<U>> Then<T, U>(
		this Task<IOption<T>> option,
		Func<T, IOption<U>> binder)
		where T : notnull
		where U : notnull =>
		option.Bind(binder);

	[Pure]
	public static Task<IOption<U>> Then<T, U>(
		this Task<IOption<T>> option,
		Func<T, Task<IOption<U>>> binder)
		where T : notnull
		where U : notnull =>
		option.Bind(binder);

	[Pure]
	public static Task<U> Finally<T, U>(
		this Task<IOption<T>> option,
		Func<T, U> someMatch,
		Func<U> noneMatch)
		where T : notnull
		where U : notnull =>
		option.Match(someMatch, noneMatch);

	[Pure]
	public static Task<U> Finally<T, U>(
		this Task<IOption<T>> option,
		Func<T, Task<U>> someMatch,
		Func<U> noneMatch)
		where T : notnull
		where U : notnull =>
		option.Match(someMatch, noneMatch);

	[Pure]
	public static Task<U> Finally<T, U>(
		this Task<IOption<T>> option,
		Func<T, U> someMatch,
		Func<Task<U>> noneMatch)
		where T : notnull
		where U : notnull =>
		option.Match(someMatch, noneMatch);

	[Pure]
	public static Task<U> Finally<T, U>(
		this Task<IOption<T>> option,
		Func<T, Task<U>> someMatch,
		Func<Task<U>> noneMatch)
		where T : notnull
		where U : notnull =>
		option.Match(someMatch, noneMatch);
}

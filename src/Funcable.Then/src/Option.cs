using System.Diagnostics.Contracts;
using Funcable.Control;
using Funcable.Core;

namespace Funcable.Then;

public static class Option
{
	[Pure]
	public static IOption<U> Then<T, U>(
		this IOption<T> option,
		Func<T, U> mapping)
		where T : notnull
		where U : notnull =>
		option.Map(mapping);

	[Pure]
	public static IOption<V> Then<T, U, V>(
		this IOption<T> optionT,
		IOption<U> optionU,
		Func<T, U, V> mapping)
		where T : notnull
		where U : notnull
		where V : notnull =>
		optionT.Map(optionU, mapping);

	[Pure]
	public static IOption<X> Then<T, U, V, X>(
		this IOption<T> optionT,
		IOption<U> optionU,
		IOption<V> optionV,
		Func<T, U, V, X> mapping)
		where T : notnull
		where U : notnull
		where V : notnull
		where X : notnull =>
		optionT.Map(optionU, optionV, mapping);

	[Pure]
	public static IOption<U> Then<T, U>(
		this IOption<T> option,
		Func<T, IOption<U>> binder)
		where T : notnull
		where U : notnull =>
		option.Bind(binder);

	[Pure]
	public static U Finally<T, U>(
		this IOption<T> option,
		Func<T, U> someMatch,
		U defaultValue)
		where T : notnull
		where U : notnull =>
		option.Match(someMatch, defaultValue);

	[Pure]
	public static U Finally<T, U>(
		this IOption<T> option,
		Func<T, U> someMatch,
		Func<U> noneMatch)
		where T : notnull
		where U : notnull =>
		option.Match(someMatch, noneMatch);
}

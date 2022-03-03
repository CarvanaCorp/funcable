using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IOption<T> Some<T>(T value)
		where T : notnull =>
		Option.Some<T>(value);

	[Pure]
	public static IOption<T> None<T>()
		where T : notnull =>
		Option.None<T>();

	[Pure]
	public static bool IsSome<T>(IOption<T> option)
		where T : notnull =>
		Match(
			option,
			_ => true,
			false
		);

	[Pure]
	public static bool IsNone<T>(IOption<T> option)
		where T : notnull =>
		Match(
			option,
			_ => false,
			true
		);

	[Pure]
	public static T FromSome<T>(IOption<T> option)
		where T : notnull =>
		option switch
		{
			Some<T> some => (T)some,
			None<T> => throw new InvalidOperationException($"{typeof(IOption<T>).Name}.{nameof(FromSome)}: {option.GetType().Name}"),
			_ => throw new InvalidPatternException(typeof(IOption<T>), nameof(FromSome), option.GetType())
		};

	[Pure]
	public static T FromOption<T>(IOption<T> option, T defaultValue)
		where T : notnull =>
		Match(
			option,
			t => t,
			defaultValue
		);

	[Pure]
	public static async Task<IResult<T, Error>> AsAsyncResult<T>(IOption<T> option)
		where T : notnull =>
		await Task.FromResult(AsResult(option)).ConfigureAwait(false);

	[Pure]
	public static IResult<T, Error> AsResult<T>(IOption<T> option)
		where T : notnull =>
		Match(
			option,
			t => Ok<T, Error>(t),
			Error<T, Error>(new Error($"{typeof(IOption<T>).Name}.{nameof(AsResult)}: None"))
		);

	[Pure]
	public static IOption<T> OnSome<T>(IOption<T> option, Action<T> handler)
		where T : notnull =>
		Match(
			option,
			t => { handler(t); return option; },
			option
		);

	[Pure]
	public static IOption<T> OnNone<T>(IOption<T> option, Action handler)
		where T : notnull =>
		Match(
			option,
			_ => option,
			() => { handler(); return option; }
		);

	[Pure]
	public static U Match<T, U>(
		IOption<T> option,
		Func<T, U> someMatch,
		U defaultValue)
		where T : notnull
		where U : notnull =>
		Match(
			option,
			t => someMatch(t),
			() => defaultValue
		);

	[Pure]
	public static U Match<T, U>(
		IOption<T> option,
		Func<T, U> someMatch,
		Func<U> noneMatch)
		where T : notnull
		where U : notnull =>
		option switch
		{
			Some<T> some => someMatch(FromSome(some)),
			None<T> => noneMatch(),
			_ => throw new InvalidPatternException(typeof(IOption<T>), nameof(Match), option.GetType())
		};
}

using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IOption<T>> AsyncSome<T>(T value)
		where T : notnull =>
		Task.FromResult(Some(value));

	[Pure]
	public static Task<IOption<T>> AsyncNone<T>()
		where T : notnull =>
		Task.FromResult(None<T>());

	[Pure]
	public static async Task<bool> IsSome<T>(Task<IOption<T>> option)
		where T : notnull =>
		IsSome(await option.ConfigureAwait(false));

	[Pure]
	public static async Task<bool> IsNone<T>(Task<IOption<T>> option)
		where T : notnull =>
		IsNone(await option.ConfigureAwait(false));

	[Pure]
	public static async Task<T> FromSome<T>(Task<IOption<T>> option)
		where T : notnull =>
		FromSome(await option.ConfigureAwait(false));

	[Pure]
	public static Task<IOption<T>> OnSome<T>(
		Task<IOption<T>> option,
		Action<T> handler)
		where T : notnull =>
		Match(
			option,
			t => { handler(t); return option; },
			() => option
		);

	[Pure]
	public static async Task<IOption<T>> OnSome<T>(
		Task<IOption<T>> option,
		Func<T, Task> handler)
		where T : notnull =>
		await (await Match(
			option,
			async t =>
			{
				await handler(t).ConfigureAwait(false);
				return option;
			},
			() => option
		)
		.ConfigureAwait(false)).ConfigureAwait(false);

	[Pure]
	public static Task<IOption<T>> OnNone<T>(
		Task<IOption<T>> option,
		Action handler)
		where T : notnull =>
		Match(
			option,
			_ => option,
			() => { handler(); return option; }
		);

	[Pure]
	public static async Task<IOption<T>> OnNone<T>(
		Task<IOption<T>> option,
		Func<Task> handler)
		where T : notnull =>
		await (await Match(
			option,
			_ => option,
			async () =>
			{
				await handler().ConfigureAwait(false);
				return option;
			}
		).ConfigureAwait(false)).ConfigureAwait(false);

	[Pure]
	public static Task<U> Match<T, U>(
		Task<IOption<T>> option,
		Func<T, U> someMatch,
		Func<U> noneMatch)
		where T : notnull
		where U : notnull =>
		Match(
			option,
			async t => await Task.FromResult(someMatch(t)).ConfigureAwait(false),
			async () => await Task.FromResult(noneMatch()).ConfigureAwait(false)
		);

	[Pure]
	public static Task<U> Match<T, U>(
		Task<IOption<T>> option,
		Func<T, Task<U>> someMatch,
		Func<U> noneMatch)
		where T : notnull
		where U : notnull =>
		Match(
			option,
			someMatch,
			async () => await Task.FromResult(noneMatch()).ConfigureAwait(false)
		);

	[Pure]
	public static Task<U> Match<T, U>(
		Task<IOption<T>> option,
		Func<T, U> someMatch,
		Func<Task<U>> noneMatch)
		where T : notnull
		where U : notnull =>
		Match(
			option,
			async t => await Task.FromResult(someMatch(t)).ConfigureAwait(false),
			noneMatch
		);

	[Pure]
	public static async Task<U> Match<T, U>(
		Task<IOption<T>> option,
		Func<T, Task<U>> someMatch,
		Func<Task<U>> noneMatch)
		where T : notnull
		where U : notnull =>
		await Match(
			await option.ConfigureAwait(false),
			async t => await someMatch(t).ConfigureAwait(false),
			async () => await noneMatch().ConfigureAwait(false)
		)
		.ConfigureAwait(false);
}

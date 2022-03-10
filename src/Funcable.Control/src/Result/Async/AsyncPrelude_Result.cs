using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IResult<T, Error>> AsyncOk<T>(T value)
		where T : notnull =>
		Task.FromResult(Ok(value));

	[Pure]
	public static Task<IResult<T, TError>> AsyncOk<T, TError>(T value)
		where T : notnull
		where TError : notnull =>
		Task.FromResult(Ok<T, TError>(value));

	[Pure]
	public static Task<IResult<T, Error>> AsyncError<T>(
		string message,
		string code = "",
		object? context = null)
		where T : notnull =>
		Task.FromResult(Error<T>(message, code, context));

	[Pure]
	public static Task<IResult<T, TError>> AsyncError<T, TError>(TError error)
		where T : notnull
		where TError : notnull =>
		Task.FromResult(Error<T, TError>(error));

	[Pure]
	public static async Task<bool> IsOk<T, TError>(Task<IResult<T, TError>> result)
		where T : notnull
		where TError : notnull =>
		IsOk(await result.ConfigureAwait(false));

	[Pure]
	public static async Task<bool> IsError<T, TError>(Task<IResult<T, TError>> result)
		 where T : notnull
		 where TError : notnull =>
		IsError(await result.ConfigureAwait(false));

	[Pure]
	public static async Task<T> FromOk<T, TError>(Task<IResult<T, TError>> result)
		where T : notnull
		where TError : notnull =>
		FromOk(await result.ConfigureAwait(false));

	[Pure]
	public static async Task<TError> FromError<T, TError>(Task<IResult<T, TError>> result)
		where T : notnull
		where TError : notnull =>
		FromError(await result.ConfigureAwait(false));

	[Pure]
	public static Task<IResult<T, TError>> OnOk<T, TError>(Task<IResult<T, TError>> result, Action<T> handler)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			t => { handler(t); return result; },
			_ => result
		);

	[Pure]
	public static async Task<IResult<T, TError>> OnOk<T, TError>(Task<IResult<T, TError>> result, Func<T, Task> handler)
		where T : notnull
		where TError : notnull =>
		await (await Match(
			result,
			async t => { await handler(t).ConfigureAwait(false); return result; },
			_ => result
		)
		.ConfigureAwait(false)).ConfigureAwait(false);

	[Pure]
	public static Task<IResult<T, TError>> OnError<T, TError>(Task<IResult<T, TError>> result, Action<TError> handler)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			_ => result,
			e => { handler(e); return result; }
		);


	[Pure]
	public static async Task<IResult<T, TError>> OnError<T, TError>(Task<IResult<T, TError>> result, Func<TError, Task> handler)
		where T : notnull
		where TError : notnull =>
		await (await Match(
			result,
			_ => result,
			async e => { await handler(e).ConfigureAwait(false); return result; }
		)
		.ConfigureAwait(false)).ConfigureAwait(false);

	[Pure]
	public static Task<U> Match<T, TError, U>(
		Task<IResult<T, TError>> result,
		Func<T, U> okMatch,
		Func<TError, U> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Match(
			result,
			async t => await Task.FromResult(okMatch(t)).ConfigureAwait(false),
			async e => await Task.FromResult(errorMatch(e)).ConfigureAwait(false)
		);

	[Pure]
	public static Task<U> Match<T, TError, U>(
		Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMatch,
		Func<TError, U> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Match(
			result,
			okMatch,
			async e => await Task.FromResult(errorMatch(e)).ConfigureAwait(false)
		);

	[Pure]
	public static Task<U> Match<T, TError, U>(
		Task<IResult<T, TError>> result,
		Func<T, U> okMatch,
		Func<TError, Task<U>> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Match(
			result,
			async t => await Task.FromResult(okMatch(t)).ConfigureAwait(false),
			errorMatch
		);

	[Pure]
	public static async Task<U> Match<T, TError, U>(
		Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMatch,
		Func<TError, Task<U>> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		await Match(
			await result.ConfigureAwait(false),
			async t => await okMatch(t).ConfigureAwait(false),
			async e => await errorMatch(e).ConfigureAwait(false)
		)
		.ConfigureAwait(false);
}

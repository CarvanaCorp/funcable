using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static class TaskIResultExtensions
{
	[Pure]
	public static Task<IResult<U, TError>> Map<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, U> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Prelude.Map(result, mapping);

	[Pure]
	public static Task<IResult<U, TError>> Map<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<U>> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Prelude.Map(result, mapping);

	[Pure]
	public static Task<IResult<T, UError>> MapError<T, TError, UError>(
		this Task<IResult<T, TError>> result,
		Func<TError, UError> mapping)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		Prelude.MapError(result, mapping);

	[Pure]
	public static Task<IResult<T, UError>> MapError<T, TError, UError>(
		this Task<IResult<T, TError>> result,
		Func<TError, Task<UError>> mapping)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		Prelude.MapError(result, mapping);

	[Pure]
	public static Task<IResult<U, UError>> BiMap<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, U> okMapping,
		Func<TError, UError> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Prelude.BiMap(result, okMapping, errorMapping);

	[Pure]
	public static Task<IResult<U, UError>> BiMap<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMapping,
		Func<TError, UError> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Prelude.BiMap(result, okMapping, errorMapping);

	[Pure]
	public static Task<IResult<U, UError>> BiMap<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, U> okMapping,
		Func<TError, Task<UError>> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Prelude.BiMap(result, okMapping, errorMapping);

	[Pure]
	public static Task<IResult<U, UError>> BiMap<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMapping,
		Func<TError, Task<UError>> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Prelude.BiMap(result, okMapping, errorMapping);

	[Pure]
	public static Task<IResult<U, TError>> Bind<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, IResult<U, TError>> binder)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Prelude.Bind(result, binder);

	[Pure]
	public static Task<IResult<U, TError>> Bind<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<IResult<U, TError>>> binder)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Prelude.Bind(result, binder);

	[Pure]
	public static Task<IResult<T, UError>> BindError<T, TError, UError>(
		this Task<IResult<T, TError>> result,
		Func<TError, IResult<T, UError>> binder)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		Prelude.BindError(result, binder);

	[Pure]
	public static Task<IResult<T, UError>> BindError<T, TError, UError>(
		this Task<IResult<T, TError>> result,
		Func<TError, Task<IResult<T, UError>>> binder)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		Prelude.BindError(result, binder);

	[Pure]
	public static Task<IResult<U, UError>> BiBind<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, IResult<U, UError>> okBinder,
		Func<TError, IResult<U, UError>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Prelude.BiBind(result, okBinder, errorBinder);

	[Pure]
	public static Task<IResult<U, UError>> BiBind<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, IResult<U, UError>> okBinder,
		Func<TError, Task<IResult<U, UError>>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Prelude.BiBind(result, okBinder, errorBinder);

	[Pure]
	public static Task<IResult<U, UError>> BiBind<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<IResult<U, UError>>> okBinder,
		Func<TError, IResult<U, UError>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Prelude.BiBind(result, okBinder, errorBinder);

	[Pure]
	public static Task<IResult<U, UError>> BiBind<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<IResult<U, UError>>> okBinder,
		Func<TError, Task<IResult<U, UError>>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		Prelude.BiBind(result, okBinder, errorBinder);

	[Pure]
	public static Task<IResult<T, TError>> Flatten<T, TError>(
		this Task<IResult<Task<IResult<T, TError>>, TError>> result)
		where T : notnull
		where TError : notnull =>
		Prelude.Flatten(result);

	[Pure]
	public static Task<IResult<T, TError>> Flatten<T, TError>(
		this Task<IResult<IResult<T, TError>, TError>> result)
		where T : notnull
		where TError : notnull =>
		Prelude.Flatten(result);

	[Pure]
	public static Task<IResult<T, TError>> Flatten<T, TError>(
		this IResult<Task<IResult<T, TError>>, TError> result)
		where T : notnull
		where TError : notnull =>
		Prelude.Flatten(result);

	[Pure]
	public static Task<bool> IsOk<T, TError>(this Task<IResult<T, TError>> result)
		where T : notnull
		where TError : notnull =>
		Prelude.IsOk(result);

	[Pure]
	public static Task<bool> IsError<T, TError>(this Task<IResult<T, TError>> result)
		 where T : notnull
		 where TError : notnull =>
		 Prelude.IsError(result);

	[Pure]
	public static Task<T> FromOk<T, TError>(this Task<IResult<T, TError>> result)
		where T : notnull
		where TError : notnull =>
		Prelude.FromOk(result);

	[Pure]
	public static Task<TError> FromError<T, TError>(this Task<IResult<T, TError>> result)
		where T : notnull
		where TError : notnull =>
		Prelude.FromError(result);

	[Pure]
	public static Task<IResult<T, TError>> OnOk<T, TError>(this Task<IResult<T, TError>> result, Action<T> handler)
		where T : notnull
		where TError : notnull =>
		Prelude.OnOk(result, handler);

	[Pure]
	public static Task<IResult<T, TError>> OnOk<T, TError>(this Task<IResult<T, TError>> result, Func<T, Task> handler)
		where T : notnull
		where TError : notnull =>
		Prelude.OnOk(result, handler);

	[Pure]
	public static Task<IResult<T, TError>> OnError<T, TError>(this Task<IResult<T, TError>> result, Action<TError> handler)
		where T : notnull
		where TError : notnull =>
		Prelude.OnError(result, handler);

	[Pure]
	public static Task<IResult<T, TError>> OnError<T, TError>(this Task<IResult<T, TError>> result, Func<TError, Task> handler)
		where T : notnull
		where TError : notnull =>
		Prelude.OnError(result, handler);

	[Pure]
	public static Task<U> Match<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, U> okMatch,
		Func<TError, U> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Prelude.Match(result, okMatch, errorMatch);

	[Pure]
	public static Task<U> Match<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMatch,
		Func<TError, U> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Prelude.Match(result, okMatch, errorMatch);

	[Pure]
	public static Task<U> Match<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, U> okMatch,
		Func<TError, Task<U>> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Prelude.Match(result, okMatch, errorMatch);

	[Pure]
	public static Task<U> Match<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMatch,
		Func<TError, Task<U>> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		Prelude.Match(result, okMatch, errorMatch);
}

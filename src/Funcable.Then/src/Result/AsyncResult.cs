using System.Diagnostics.Contracts;
using Funcable.Control;
using Funcable.Core;

namespace Funcable.Then;

public static class AsyncResult
{
	[Pure]
	public static Task<IResult<U, TError>> Then<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, U> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result.Map(mapping);

	[Pure]
	public static Task<IResult<U, TError>> Then<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<U>> mapping)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result.Map(mapping);

	[Pure]
	public static Task<IResult<U, UError>> Then<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, U> okMapping,
		Func<TError, UError> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		result.BiMap(okMapping, errorMapping);

	[Pure]
	public static Task<IResult<U, UError>> Then<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMapping,
		Func<TError, UError> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		result.BiMap(okMapping, errorMapping);

	[Pure]
	public static Task<IResult<U, UError>> Then<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, U> okMapping,
		Func<TError, Task<UError>> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		result.BiMap(okMapping, errorMapping);

	[Pure]
	public static Task<IResult<U, UError>> Then<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMapping,
		Func<TError, Task<UError>> errorMapping)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		result.BiMap(okMapping, errorMapping);

	[Pure]
	public static Task<IResult<U, TError>> Then<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, IResult<U, TError>> binder)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result.Bind(binder);

	[Pure]
	public static Task<IResult<U, TError>> Then<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<IResult<U, TError>>> binder)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result.Bind(binder);

	[Pure]
	public static Task<IResult<U, UError>> Then<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, IResult<U, UError>> okBinder,
		Func<TError, IResult<U, UError>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		result.BiBind(okBinder, errorBinder);

	[Pure]
	public static Task<IResult<U, UError>> Then<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, IResult<U, UError>> okBinder,
		Func<TError, Task<IResult<U, UError>>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		result.BiBind(okBinder, errorBinder);

	[Pure]
	public static Task<IResult<U, UError>> Then<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<IResult<U, UError>>> okBinder,
		Func<TError, IResult<U, UError>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		result.BiBind(okBinder, errorBinder);

	[Pure]
	public static Task<IResult<U, UError>> Then<T, TError, U, UError>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<IResult<U, UError>>> okBinder,
		Func<TError, Task<IResult<U, UError>>> errorBinder)
		where T : notnull
		where TError : notnull
		where U : notnull
		where UError : notnull =>
		result.BiBind(okBinder, errorBinder);

	[Pure]
	public static Task<IResult<T, UError>> Catch<T, TError, UError>(
		this Task<IResult<T, TError>> result,
		Func<TError, UError> mapping)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		result.MapError(mapping);

	[Pure]
	public static Task<IResult<T, UError>> Catch<T, TError, UError>(
		this Task<IResult<T, TError>> result,
		Func<TError, Task<UError>> mapping)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		result.MapError(mapping);

	[Pure]
	public static Task<IResult<T, UError>> Catch<T, TError, UError>(
		this Task<IResult<T, TError>> result,
		Func<TError, IResult<T, UError>> binder)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		result.BindError(binder);

	[Pure]
	public static Task<IResult<T, UError>> Catch<T, TError, UError>(
		this Task<IResult<T, TError>> result,
		Func<TError, Task<IResult<T, UError>>> binder)
		where T : notnull
		where TError : notnull
		where UError : notnull =>
		result.BindError(binder);

	[Pure]
	public static Task<U> Finally<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, U> okMatch,
		Func<TError, U> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result.Match(okMatch, errorMatch);

	[Pure]
	public static Task<U> Finally<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMatch,
		Func<TError, U> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result.Match(okMatch, errorMatch);

	[Pure]
	public static Task<U> Finally<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, U> okMatch,
		Func<TError, Task<U>> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result.Match(okMatch, errorMatch);

	[Pure]
	public static Task<U> Finally<T, TError, U>(
		this Task<IResult<T, TError>> result,
		Func<T, Task<U>> okMatch,
		Func<TError, Task<U>> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result.Match(okMatch, errorMatch);
}

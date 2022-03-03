using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static class GenericExtensions
{
	[Pure]
	public static IOption<T> Some<T>(this T value)
		where T : notnull =>
		Option.Some(value);

	[Pure]
	public static IOption<T> None<T>(this T _)
		where T : notnull =>
		Option.None<T>();

	[Pure]
	public static IResult<T, Error> Ok<T>(this T value)
		where T : notnull =>
		Result.Ok<T, Error>(value);

	[Pure]
	public static IResult<T, TError> Ok<T, TError>(this T value)
		where T : notnull
		where TError : notnull =>
		Result.Ok<T, TError>(value);

	[Pure]
	public static IResult<T, TError> Error<T, TError>(this TError error)
		where T : notnull
		where TError : notnull =>
		Result.Error<T, TError>(error);

	[Pure]
	public static Task<IResult<T, TError>> AsyncOk<T, TError>(this T value)
		where T : notnull
		where TError : notnull =>
		Task.FromResult(Result.Ok<T, TError>(value));

	[Pure]
	public static Task<IResult<T, TError>> AsyncError<T, TError>(this TError error)
		where T : notnull
		where TError : notnull =>
		Task.FromResult(Result.Error<T, TError>(error));

	[Pure]
	public static Task<T> AsTask<T>(this T value)
		where T : notnull =>
		Task.FromResult(value);
}

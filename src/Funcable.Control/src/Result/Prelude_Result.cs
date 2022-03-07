using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IResult<T, TError> Ok<T, TError>(T value)
		where T : notnull
		where TError : notnull =>
		Result.Ok<T, TError>(value);

	[Pure]
	public static IResult<T, Error> Error<T>(string message, string code = "", object? context = null)
		where T : notnull =>
		Error<T, Error>(new Error(message, code, context));

	[Pure]
	public static IResult<T, TError> Error<T, TError>(TError error)
		where T : notnull
		where TError : notnull =>
		Result.Error<T, TError>(error);

	[Pure]
	public static bool IsOk<T, TError>(IResult<T, TError> result)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			_ => true,
			_ => false
		);

	[Pure]
	public static bool IsError<T, TError>(IResult<T, TError> result)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			_ => false,
			_ => true
		);

	[Pure]
	public static T FromOk<T, TError>(IResult<T, TError> result)
		where T : notnull
		where TError : notnull =>
		result switch
		{
			Ok<T, TError> ok => (T)ok,
			Error<T, TError> => throw new InvalidOperationException(
				$"{typeof(IResult<T, TError>).Name}.{nameof(FromOk)}: {result.GetType().Name}"
			),
			_ => throw new InvalidPatternException(typeof(IResult<T, TError>), nameof(FromOk), result.GetType())
		};

	[Pure]
	public static TError FromError<T, TError>(IResult<T, TError> result)
		where T : notnull
		where TError : notnull =>
		result switch
		{
			Ok<T, TError> => throw new InvalidOperationException(
				$"{typeof(IResult<T, TError>).Name}.{nameof(FromError)}: {result.GetType().Name}"
			),
			Error<T, TError> error => (TError)error,
			_ => throw new InvalidPatternException(typeof(IResult<T, TError>), nameof(FromError), result.GetType())
		};

	[Pure]
	public static IOption<T> AsOption<T, TError>(IResult<T, TError> result)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			t => Option.Some(t),
			_ => Option.None<T>()
		);

	[Pure]
	public static IResult<T, TError> OnOk<T, TError>(IResult<T, TError> result, Action<T> handler)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			t => { handler(t); return result; },
			_ => result
		);

	[Pure]
	public static IResult<T, TError> OnError<T, TError>(IResult<T, TError> result, Action<TError> handler)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			_ => result,
			error => { handler(error); return result; }
		);

	[Pure]
	public static U Match<T, TError, U>(
		IResult<T, TError> result,
		Func<T, U> okMatch,
		Func<TError, U> errorMatch)
		where T : notnull
		where TError : notnull
		where U : notnull =>
		result switch
		{
			Ok<T, TError> ok => okMatch(FromOk(ok)),
			Error<T, TError> error => errorMatch(FromError(error)),
			_ => throw new InvalidPatternException(typeof(IResult<T, TError>), nameof(Match), result.GetType())
		};
}

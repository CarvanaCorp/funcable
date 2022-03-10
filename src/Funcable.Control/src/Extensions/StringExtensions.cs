using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static class StringExtensions
{
	[Pure]
	public static IResult<T, Error> Error<T>(
		this string message,
		string code = "",
		object? context = null)
		where T : notnull =>
		Result.Error<T, Error>(new Error(message, code, context));

	[Pure]
	public static Task<IResult<T, Error>> AsyncError<T>(
		this string message,
		string code = "",
		object? context = null)
		where T : notnull =>
		Task.FromResult(Result.Error<T, Error>(new Error(message, code, context)));
}

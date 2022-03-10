using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static class ErrorExtensions
{
	[Pure]
	public static IResult<T, Error> Error<T>(this Error error)
		where T : notnull =>
		Result.Error<T, Error>(error);

	[Pure]
	public static Task<IResult<T, Error>> AsyncError<T>(this Error error)
		where T : notnull =>
		Task.FromResult(Result.Error<T, Error>(error));
}

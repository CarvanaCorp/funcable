using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	public static IResult<T, Error> Try<T>(Func<T> func)
		where T : notnull
	{
		try { return Ok<T, Error>(func()); }
		catch (Exception ex) { return Error<T, Error>(new Error(ex.Message, Context: ex)); }
	}

	public static async Task<IResult<T, Error>> Try<T>(Func<Task<T>> func)
		where T : notnull
	{
		try { return await AsyncOk<T, Error>(await func().ConfigureAwait(false)).ConfigureAwait(false); }
		catch (Exception ex) { return await AsyncError<T, Error>(new Error(ex.Message, Context: ex)).ConfigureAwait(false); }
	}
}

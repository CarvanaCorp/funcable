using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	public static Unit Iterate<T, TError>(
		IResult<T, TError> result,
		Action<T> iterator)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			t => { iterator(t); return Unit; },
			_ => Unit
		);

	public static Unit Iterate<T, TError>(
		IEnumerable<IResult<T, TError>> results,
		Action<T> iterator)
		where T : notnull
		where TError : notnull
	{
		foreach (var result in results) { Iterate(result, iterator); }
		return Unit;
	}

	public static Unit IterateError<T, TError>(
		IResult<T, TError> result,
		Action<TError> iterator)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			_ => Unit,
			error => { iterator(error); return Unit; }
		);

	public static Unit IterateError<T, TError>(
		IEnumerable<IResult<T, TError>> results,
		Action<TError> iterator)
		where T : notnull
		where TError : notnull
	{
		foreach (var result in results) { IterateError(result, iterator); }
		return Unit;
	}

	public static Unit BiIterate<T, TError>(
		IResult<T, TError> result,
		Action<T> okIterator,
		Action<TError> errorIterator)
		where T : notnull
		where TError : notnull =>
		Match(
			result,
			t => { okIterator(t); return Unit; },
			error => { errorIterator(error); return Unit; }
		);

	public static Unit BiIterate<T, TError>(
		IEnumerable<IResult<T, TError>> results,
		Action<T> okIterator,
		Action<TError> errorIterator)
		where T : notnull
		where TError : notnull
	{
		foreach (var result in results) { BiIterate(result, okIterator, errorIterator); }
		return Unit;
	}
}

using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static (IEnumerable<T> Oks, IEnumerable<TError> Errors) Partition<T, TError>(
		IEnumerable<IResult<T, TError>> results)
		where T : notnull
		where TError : notnull =>
		BiFold<T, TError, (List<T> Oks, List<TError> Errors)>(
			results,
			(new List<T>(), new List<TError>()),
			(partitions, t) => { partitions.Oks.Add(t); return partitions; },
			(partitions, error) => { partitions.Errors.Add(error); return partitions; }
		);
}

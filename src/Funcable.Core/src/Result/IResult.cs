namespace Funcable.Core;

public interface IResult<T, TError> :
	IEnumerable<T>,
	IComparable<IResult<T, TError>>,
	IComparable<T>,
	IComparable,
	IEquatable<IResult<T, TError>>,
	IEquatable<T>
	where T : notnull
	where TError : notnull
{
	bool IsOk { get; }

	bool IsError { get; }
}

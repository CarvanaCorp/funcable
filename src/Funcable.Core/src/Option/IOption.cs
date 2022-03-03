namespace Funcable.Core;

public interface IOption<T> :
	IEnumerable<T>,
	IComparable<IOption<T>>,
	IComparable<T>,
	IComparable,
	IEquatable<IOption<T>>,
	IEquatable<T>
	where T : notnull
{
	bool IsSome { get; }

	bool IsNone { get; }
}

using System.Collections;

namespace Funcable.Core;

public readonly struct None<T> : IOption<T>
	where T : notnull
{
	public bool IsSome => false;

	public bool IsNone => true;

	public int CompareTo(object? obj) => obj switch
	{
		IOption<T> option => CompareTo(option),
		_ => -1
	};

	public int CompareTo(IOption<T>? other) => other switch
	{
		None<T> => 0,
		_ => 1
	};

	public int CompareTo(T? other) => other switch
	{
		not null => 1,
		_ => 0
	};

	public override bool Equals(object? obj) => obj switch
	{
		IOption<T> option => Equals(option),
		_ => false
	};

	public bool Equals(IOption<T>? other) => other switch
	{
		None<T> => true,
		_ => false
	};


	public bool Equals(T? other) => false;

	public override int GetHashCode()
	{
		unchecked
		{
			return 12 * 16 ^ typeof(T).GetHashCode();
		}
	}

	public override string ToString() => "None";

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	public IEnumerator<T> GetEnumerator() { yield break; }

	public static explicit operator T(None<T> _) =>
		throw new InvalidCastException($"{typeof(IOption<T>).Name}: None");

	public static bool operator ==(None<T> left, None<T> right) => left.Equals(right);

	public static bool operator !=(None<T> left, None<T> right) => !(left == right);

	public static bool operator ==(IOption<T> left, None<T> right) => left.Equals(right);

	public static bool operator !=(IOption<T> left, None<T> right) => !(left == right);

	public static bool operator ==(None<T> left, IOption<T> right) => left.Equals(right);

	public static bool operator !=(None<T> left, IOption<T> right) => !(left == right);
}

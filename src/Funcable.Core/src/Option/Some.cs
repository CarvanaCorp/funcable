using System.Collections;

namespace Funcable.Core;

public readonly struct Some<T> : IOption<T>
	where T : notnull
{
	private readonly T _value;

	internal Some(T value) => _value = value switch
	{
		not null => value,
		_ => throw new ArgumentNullException(nameof(value), "Some: null")
	};

	public int CompareTo(object? obj) => obj switch
	{
		IOption<T> option => CompareTo(option),
		_ => -1
	};

	public int CompareTo(IOption<T>? other) => other switch
	{
		Some<T> some => CompareTo(some._value),
		_ => -1
	};

	public int CompareTo(T? other) => other switch
	{
		not null => Comparer<T>.Default.Compare(_value, other),
		_ => -1
	};

	public override bool Equals(object? obj) => obj switch
	{
		IOption<T> option => Equals(option),
		_ => false
	};

	public bool Equals(IOption<T>? other) => other switch
	{
		Some<T> some => Equals(some._value),
		_ => false
	};


	public bool Equals(T? other) => other switch
	{
		null => false,
		_ => _value.Equals(other)
	};

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	public IEnumerator<T> GetEnumerator() { yield return _value; }

	public override int GetHashCode()
	{
		unchecked
		{
			return 82 * 51 ^ _value.GetHashCode();
		}
	}

	public override string ToString() => $"Some: {_value}";

	public static implicit operator Some<T>(T value) => new(value);

	public static explicit operator T(Some<T> some) => some._value switch
	{
		null => throw new InvalidCastException($"{typeof(Some<T>).Name} cast: null"),
		_ => some._value
	};

	public static bool operator ==(Some<T> left, Some<T> right) => left.Equals(right);

	public static bool operator !=(Some<T> left, Some<T> right) => !(left == right);

	public static bool operator ==(IOption<T> left, Some<T> right) => left.Equals(right);

	public static bool operator !=(IOption<T> left, Some<T> right) => !(left == right);

	public static bool operator ==(Some<T> left, IOption<T> right) => left.Equals(right);

	public static bool operator !=(Some<T> left, IOption<T> right) => !(left == right);
}

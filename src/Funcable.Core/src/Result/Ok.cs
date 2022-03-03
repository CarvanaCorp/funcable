using System.Collections;

namespace Funcable.Core;

public readonly struct Ok<T, TError> : IResult<T, TError>
	where T : notnull
	where TError : notnull
{
	private readonly T _value;

	internal Ok(T value) => _value = value switch
	{
		not null => value,
		_ => throw new ArgumentNullException(nameof(value), "Ok: null")
	};

	public bool IsOk => true;

	public bool IsError => false;

	public int CompareTo(object? obj) => obj switch
	{
		IResult<T, TError> either => CompareTo(either),
		_ => -1
	};

	public int CompareTo(IResult<T, TError>? other) => other switch
	{
		Ok<T, TError> right => CompareTo(right._value),
		_ => -1
	};

	public int CompareTo(T? other) => other switch
	{
		not null => Comparer<T>.Default.Compare(_value, other),
		_ => -1
	};

	public override bool Equals(object? obj) => obj switch
	{
		IResult<T, TError> either => Equals(either),
		_ => false
	};

	public bool Equals(IResult<T, TError>? other) => other switch
	{
		Ok<T, TError> right => Equals(right._value),
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
			return 12 * 15 ^ _value.GetHashCode();
		}
	}

	public override string ToString() => $"Ok: {_value}";

	public static implicit operator Ok<T, TError>(T value) => new(value);

	public static explicit operator T(Ok<T, TError> ok) => ok._value switch
	{
		null => throw new InvalidCastException($"{typeof(Ok<T, TError>).Name} cast: null"),
		_ => ok._value
	};

	public static bool operator ==(Ok<T, TError> left, Ok<T, TError> right) => left.Equals(right);

	public static bool operator !=(Ok<T, TError> left, Ok<T, TError> right) => !(left == right);

	public static bool operator ==(IResult<T, TError> left, Ok<T, TError> right) => left.Equals(right);

	public static bool operator !=(IResult<T, TError> left, Ok<T, TError> right) => !(left == right);

	public static bool operator ==(Ok<T, TError> left, IResult<T, TError> right) => left.Equals(right);

	public static bool operator !=(Ok<T, TError> left, IResult<T, TError> right) => !(left == right);
}

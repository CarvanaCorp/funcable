using System.Collections;

namespace Funcable.Core;

public readonly struct Error<T, TError> : IResult<T, TError>
	where T : notnull
	where TError : notnull
{
	private readonly TError _error;

	internal Error(TError error) => _error = error switch
	{
		not null => error,
		_ => throw new ArgumentNullException(nameof(error), "Error: null")
	};

	public bool IsOk => false;

	public bool IsError => true;

	public int CompareTo(object? obj) => obj switch
	{
		IResult<T, TError> either => CompareTo(either),
		_ => -1
	};

	public int CompareTo(IResult<T, TError>? other) => other switch
	{
		Error<T, TError> left => Comparer<TError>.Default.Compare(_error, left._error),
		_ => 1
	};

	public int CompareTo(T? other) => 1;

	public override bool Equals(object? obj) => obj switch
	{
		IResult<T, TError> either => Equals(either),
		_ => false
	};

	public bool Equals(IResult<T, TError>? other) => other switch
	{
		Error<T, TError> left => Equals(left._error),
		_ => false
	};

	public bool Equals(T? other) => false;

	public bool Equals(TError? other) => other switch
	{
		null => false,
		_ => _error.Equals(other)
	};

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	public IEnumerator<T> GetEnumerator() { yield break; }

	public override int GetHashCode()
	{
		unchecked
		{
			return 7 * 14 ^ _error.GetHashCode();
		}
	}

	public override string ToString() => $"Error: {_error}";

	public static implicit operator Error<T, TError>(TError value) => new(value);

	public static explicit operator TError(Error<T, TError> error) => error._error switch
	{
		null => throw new InvalidCastException($"{typeof(Error<T, TError>).Name} cast: null"),
		_ => error._error
	};

	public static bool operator ==(Error<T, TError> left, Error<T, TError> right) => left.Equals(right);

	public static bool operator !=(Error<T, TError> left, Error<T, TError> right) => !(left == right);

	public static bool operator ==(IResult<T, TError> left, Error<T, TError> right) => left.Equals(right);

	public static bool operator !=(IResult<T, TError> left, Error<T, TError> right) => !(left == right);

	public static bool operator ==(Error<T, TError> left, IResult<T, TError> right) => left.Equals(right);

	public static bool operator !=(Error<T, TError> left, IResult<T, TError> right) => !(left == right);
}

using System.Collections;

namespace Funcable.Core.Tests;

public static class FuncableTestFixture
{
	public sealed record TestRecord() :
		IComparable<TestRecord>,
		IComparable
	{
		public int CompareTo(object? obj) =>
			obj switch
			{
				TestRecord t => CompareTo(t),
				_ => 1
			};

		public int CompareTo(TestRecord? other) =>
			other switch
			{
				null => 1,
				_ => 0
			};
	}

	public readonly struct TestStruct { }

	public class TestParentClass { }

	public sealed class TestChildClass : TestParentClass, IEquatable<TestChildClass>
	{
		public string Value { get; set; }

		public TestChildClass(string value = "") =>
			Value = value;

		public override bool Equals(object? obj) => obj switch
		{
			TestChildClass testChildClass => Equals(testChildClass),
			_ => false
		};

		public bool Equals(TestChildClass? other) => other switch
		{
			var testChildClass when testChildClass is not null => Value.Equals(testChildClass.Value),
			_ => false
		};

		public override int GetHashCode() { unchecked { return 38 ^ Value.GetHashCode(); } }
	}

	public readonly struct TestSome<T> : IOption<T>
		where T : notnull
	{
		public int CompareTo(IOption<T>? other)
		{
			throw new NotImplementedException();
		}

		public int CompareTo(T? other)
		{
			throw new NotImplementedException();
		}

		public int CompareTo(object? obj)
		{
			throw new NotImplementedException();
		}

		public bool Equals(IOption<T>? other)
		{
			throw new NotImplementedException();
		}

		public bool Equals(T? other)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}

	public readonly struct TestOk<T, TError> : IResult<T, TError>
		where T : notnull
		where TError : notnull
	{
		public int CompareTo(IResult<T, TError>? other)
		{
			throw new NotImplementedException();
		}

		public int CompareTo(T? other)
		{
			throw new NotImplementedException();
		}

		public int CompareTo(object? obj)
		{
			throw new NotImplementedException();
		}

		public bool Equals(IResult<T, TError>? other)
		{
			throw new NotImplementedException();
		}

		public bool Equals(T? other)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}

	public const char A = 'A';

	public const string HelloWorld = "Hello, World!";

	public const string HolaMundo = " Hola, Mundo!";

	public const int FortyTwo = 42;

	public const int NegativeOne = -1;

	public const double Pi = 3.14;

#pragma warning disable IDE0060 // Disabled for Test Helpers.
	public static int ToInt(string t) => FortyTwo;

	public static int ToInt(int t) => NegativeOne;

	public static Task<int> ToAsyncInt(string t) => Task.FromResult(FortyTwo);

	public static Task<int> ToAsyncInt(int t) => Task.FromResult(NegativeOne);

	public static double ToDouble(string t, int u) => Pi;

	public static char ToChar(string t, int u, double v) => A;
#pragma warning restore IDE0060 // Disabled for Test Helpers.
}

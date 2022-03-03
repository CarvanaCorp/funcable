using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class None_CompareTo_Should
{
	[Fact]
	public void Return_Negative_1_When_None_T_Not_Equals_Object() =>
		((None<string>)Option.None<string>())
			.CompareTo(NegativeOne)
			.Should()
			.Be(-1);

	[Fact]
	public void Return_0_When_None_T_Equals_None_T() =>
		((None<string>)Option.None<string>())
			.CompareTo(Option.None<string>())
			.Should()
			.Be(0);

	[Fact]
	public void Return_1_When_None_T_Equals_T() =>
		((None<int>)Option.None<int>())
			.CompareTo(1)
			.Should()
			.Be(1);

	[Fact]
	public void Return_0_When_None_T_Equals_Null() =>
		((None<string>)Option.None<string>())
			.CompareTo((string)null)
			.Should()
			.Be(0);

	[Fact]
	public void Return_0_When_None_T_Equals_Not_None_T() =>
		((None<string>)Option.None<string>())
			.CompareTo(Option.Some("Hello"))
			.Should()
			.Be(1);
}

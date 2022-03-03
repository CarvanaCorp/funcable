using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Some_CompareTo_Should
{
	[Fact]
	public void Return_0_When_Some_T_Equals_Object() =>
		((Some<string>)Option.Some(HelloWorld))
			.CompareTo((object)Option.Some(HelloWorld))
			.Should()
			.Be(0);

	[Fact]
	public void Return_Negative_1_When_Some_T_Not_Equals_Object() =>
		((Some<int>)Option.Some(FortyTwo))
			.CompareTo(HelloWorld)
			.Should()
			.Be(-1);

	[Fact]
	public void Return_0_When_Some_T_Equals_Some_T() =>
		((Some<string>)Option.Some(HelloWorld))
			.CompareTo((Some<string>)Option.Some(HelloWorld))
			.Should()
			.Be(0);

	[Fact]
	public void Return_0_When_Some_T_Equals_Not_Some_T() =>
		((Some<string>)Option.Some(HelloWorld))
			.CompareTo((None<string>)Option.None<string>())
			.Should()
			.Be(-1);

	[Fact]
	public void Return_0_When_Some_T_Equals_T() =>
		((Some<int>)Option.Some(FortyTwo))
			.CompareTo(FortyTwo)
			.Should()
			.Be(0);

	[Fact]
	public void Return_Negative_1_When_Some_T_Equals_Null() =>
		((Some<string>)Option.Some(HelloWorld))
			.CompareTo((string)null)
			.Should()
			.Be(-1);
}

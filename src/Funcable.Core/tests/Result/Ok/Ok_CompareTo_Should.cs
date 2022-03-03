using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Ok_CompareTo_Should
{
	[Fact]
	public void Return_0_When_Ok_T_Equals_Object() =>
		((Ok<string, int>)Result.Ok<string, int>(HelloWorld))
			.CompareTo((object)Result.Ok<string, int>(HelloWorld))
			.Should()
			.Be(0);

	[Fact]
	public void Return_Negative_1_When_Ok_T_Not_Equals_Object() =>
		((Ok<int, string>)Result.Ok<int, string>(FortyTwo))
			.CompareTo(HelloWorld)
			.Should()
			.Be(-1);

	[Fact]
	public void Return_0_When_Ok_T_Equals_Ok_T() =>
		((Ok<string, int>)Result.Ok<string, int>(HelloWorld))
			.CompareTo((Ok<string, int>)Result.Ok<string, int>(HelloWorld))
			.Should()
			.Be(0);

	[Fact]
	public void Return_0_When_Ok_T_Equals_Not_Ok_T() =>
		((Ok<string, int>)Result.Ok<string, int>(HelloWorld))
			.CompareTo((Error<string, int>)Result.Error<string, int>(FortyTwo))
			.Should()
			.Be(-1);

	[Fact]
	public void Return_0_When_Ok_T_Equals_T() =>
		((Ok<int, string>)Result.Ok<int, string>(FortyTwo))
			.CompareTo(FortyTwo)
			.Should()
			.Be(0);

	[Fact]
	public void Return_Negative_1_When_Ok_T_Equals_Null() =>
		((Ok<string, int>)Result.Ok<string, int>(HelloWorld))
			.CompareTo((string)null)
			.Should()
			.Be(-1);
}

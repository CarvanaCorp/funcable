using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Error_CompareTo_Should
{
	[Fact]
	public void Return_0_When_Error_T_Equals_Object() =>
		((Error<string, int>)Result.Error<string, int>(FortyTwo))
			.CompareTo((object)Result.Error<string, int>(FortyTwo))
			.Should()
			.Be(0);

	[Fact]
	public void Return_Negative_1_When_Error_TError_Not_Equals_Object() =>
		((Error<int, string>)Result.Error<int, string>(HelloWorld))
			.CompareTo(HelloWorld)
			.Should()
			.Be(-1);

	[Fact]
	public void Return_0_When_Error_TError_Equals_Error_TError() =>
		((Error<string, int>)Result.Error<string, int>(FortyTwo))
			.CompareTo((Error<string, int>)Result.Error<string, int>(FortyTwo))
			.Should()
			.Be(0);

	[Fact]
	public void Return_0_When_Error_TError_Equals_Not_Error_T() =>
		((Error<string, int>)Result.Error<string, int>(FortyTwo))
			.CompareTo((Ok<string, int>)Result.Ok<string, int>(HelloWorld))
			.Should()
			.Be(1);

	[Fact]
	public void Return_1_When_Error_TError_Equals_T() =>
		((Error<int, string>)Result.Error<int, string>(HelloWorld))
			.CompareTo(FortyTwo)
			.Should()
			.Be(1);

	[Fact]
	public void Return_Negative_1_When_Ok_T_Equals_Null() =>
		((Error<int, string>)Result.Error<int, string>(HelloWorld))
			.CompareTo((string)null)
			.Should()
			.Be(-1);
}

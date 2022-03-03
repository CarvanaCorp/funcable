using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_IsOk_Should
{
	[Fact]
	public void Return_True_When_IResult_T_Is_Ok_T() =>
		IsOk(Ok<string, int>(HelloWorld))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IResult_T_Is_Not_Ok_T() =>
		IsOk(Error<string, int>(FortyTwo))
			.Should()
			.BeFalse();
}

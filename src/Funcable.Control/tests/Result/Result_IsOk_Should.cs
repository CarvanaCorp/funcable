using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Result_IsOk_Should
{
	[Fact]
	public void Return_True_When_IResult_T_Is_Ok_T() =>
		Ok<string, int>(HelloWorld).IsOk()
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IResult_T_Is_Not_Ok_T() =>
		Error<string, int>(FortyTwo).IsOk()
			.Should()
			.BeFalse();
}

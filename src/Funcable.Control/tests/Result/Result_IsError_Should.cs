using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Result_IsError_Should
{
	[Fact]
	public void Return_True_When_IResult_TError_Is_Error_TError() =>
		Error<string, int>(FortyTwo).IsError()
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IResult_TError_Is_Not_Error_TError() =>
		Ok<string, int>(HelloWorld).IsError()
			.Should()
			.BeFalse();
}

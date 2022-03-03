using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_IsError_Should
{
	[Fact]
	public void Return_True_When_IResult_TError_Is_Error_TError() =>
		IsError(Error<string, int>(FortyTwo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IResult_TError_Is_Not_Error_TError() =>
		IsError(Ok<string, int>(HelloWorld))
			.Should()
			.BeFalse();
}

using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class TaskResult_IsError_Should
{
	[Fact]
	public async Task Return_True_When_IResult_TError_Is_Error_TError() =>
		(await AsyncError<string, int>(FortyTwo).IsError())
			.Should()
			.BeTrue();

	[Fact]
	public async Task Return_False_When_IResult_TError_Is_Not_Error_TError() =>
		(await AsyncOk<string, int>(HelloWorld).IsError())
			.Should()
			.BeFalse();
}

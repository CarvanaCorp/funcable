using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_IsError_Should
{
	[Fact]
	public async Task Return_True_When_IResult_TError_Is_Error_TError() =>
		(await IsError(AsyncError<string, int>(FortyTwo)))
			.Should()
			.BeTrue();

	[Fact]
	public async Task Return_False_When_IResult_TError_Is_Not_Error_TError() =>
		(await IsError(AsyncOk<string, int>(HelloWorld)))
			.Should()
			.BeFalse();
}

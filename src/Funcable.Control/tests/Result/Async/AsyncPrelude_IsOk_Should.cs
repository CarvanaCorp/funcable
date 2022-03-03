using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class AsyncPrelude_IsOk_Should
{
	[Fact]
	public async Task Return_True_When_IResult_T_Is_Ok_T() =>
		(await IsOk(AsyncOk<string, int>(HelloWorld)))
			.Should()
			.BeTrue();

	[Fact]
	public async Task Return_False_When_IResult_T_Is_Not_Ok_T() =>
		(await IsOk(AsyncError<string, int>(FortyTwo)))
			.Should()
			.BeFalse();
}

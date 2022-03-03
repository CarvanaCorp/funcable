using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class ValueResult_IsOk_Should
{
	[Fact]
	public async Task Return_True_When_IResult_T_Is_Ok_T() =>
		(await AsyncOk<string, int>(HelloWorld).IsOk())
			.Should()
			.BeTrue();

	[Fact]
	public async Task Return_False_When_IResult_T_Is_Not_Ok_T() =>
		(await AsyncError<string, int>(FortyTwo).IsOk())
			.Should()
			.BeFalse();
}

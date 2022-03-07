using Xunit;

namespace Funcable.Control.Tests;

public class TaskOption_IsNone_Should
{
	[Fact]
	public async Task Return_True_When_IOption_T_Is_IsNone() =>
		(await AsyncNone<string>().IsNone())
			.Should()
			.BeTrue();

	[Fact]
	public async Task Return_False_When_IOption_T_Is_Not_IsNone() =>
		(await AsyncSome(HelloWorld).IsNone())
			.Should()
			.BeFalse();
}

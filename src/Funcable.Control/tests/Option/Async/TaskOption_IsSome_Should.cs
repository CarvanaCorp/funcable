using Xunit;

namespace Funcable.Control.Tests;

public class TaskOption_IsSome_Should
{
	[Fact]
	public async Task Return_True_When_IOption_T_Is_Some_T() =>
		(await AsyncSome(HelloWorld).IsSome())
			.Should()
			.BeTrue();

	[Fact]
	public async Task Return_False_When_IOption_T_Is_Not_Some_T() =>
		(await AsyncNone<string>().IsSome())
			.Should()
			.BeFalse();
}

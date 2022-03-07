using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_IsNone_Should
{
	[Fact]
	public async Task Return_True_When_IOption_T_Is_None() =>
		(await IsNone(AsyncNone<string>()))
			.Should()
			.BeTrue();

	[Fact]
	public async Task Return_False_When_IOption_T_Is_Not_None() =>
		(await IsNone(AsyncSome(HelloWorld)))
			.Should()
			.BeFalse();
}

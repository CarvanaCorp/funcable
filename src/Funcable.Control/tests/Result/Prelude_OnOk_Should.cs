using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_OnOk_Should
{
	[Fact]
	public void Invoke_Handler_And_Return_Self_When_Ok() =>
		OnOk(
			Ok<string, int>(HelloWorld),
			t => t.Should().Be(HelloWorld)
		);

	[Fact]
	public void Not_Invoke_Handler_And_Return_Self_When_Error()
	{
		var greeting = string.Empty;
		OnOk(
			Error<string, int>(FortyTwo),
			_ => greeting = HelloWorld
		);
		greeting.Should().Be(string.Empty);
	}
}

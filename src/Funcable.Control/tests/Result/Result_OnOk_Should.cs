using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Result_OnOk_Should
{
	[Fact]
	public void Invoke_Handler_And_Return_Self_When_Ok() =>
		Ok<string, int>(HelloWorld).OnOk(
			t => t.Should().Be(HelloWorld)
		);

	[Fact]
	public void Not_Invoke_Handler_And_Return_Self_When_Error()
	{
		var greeting = string.Empty;
		Error<string, int>(FortyTwo).OnOk(
			_ => greeting = HelloWorld
		);
		greeting.Should().Be(string.Empty);
	}
}

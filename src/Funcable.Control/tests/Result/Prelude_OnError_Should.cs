using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_OnError_Should
{
	[Fact]
	public void Invoke_Handler_And_Return_Self_When_Error()
	{
		var greeting = string.Empty;
		OnError(
			Error<string, int>(FortyTwo),
			error => greeting = error.ToString()
		);
		greeting.Should().Be(FortyTwo.ToString());
	}

	[Fact]
	public void Not_Invoke_Handler_And_Return_Self_When_Ok()
	{
		var greeting = string.Empty;
		OnError(
			Ok<string, int>(HolaMundo),
			error => greeting = error.ToString()
		);
		greeting.Should().Be(string.Empty);
	}
}

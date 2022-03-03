using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Result_OnError_Should
{
	[Fact]
	public void Invoke_Handler_And_Return_Self_When_Error()
	{
		var greeting = string.Empty;
		Error<string, int>(FortyTwo).OnError(
			error => greeting = error.ToString()
		);
		greeting.Should().Be(FortyTwo.ToString());
	}

	[Fact]
	public void Not_Invoke_Handler_And_Return_Self_When_Ok()
	{
		var greeting = string.Empty;
		Ok<string, int>(HolaMundo).OnError(
			error => greeting = error.ToString()
		);
		greeting.Should().Be(string.Empty);
	}
}

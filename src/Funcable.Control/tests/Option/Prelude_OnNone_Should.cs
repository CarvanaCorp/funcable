using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_OnNone_Should
{
	[Fact]
	public void Invoke_Handler_And_Return_Self_When_None()
	{
		var greeting = string.Empty;
		OnNone(
			None<string>(),
			() => greeting = HelloWorld
		);
		greeting.Should().Be(HelloWorld);
	}

	[Fact]
	public void Not_Invoke_Handler_And_Return_Self_When_Some()
	{
		var greeting = string.Empty;
		OnNone(
			Some(HolaMundo),
			() => greeting = HelloWorld
		);
		greeting.Should().Be(string.Empty);
	}
}

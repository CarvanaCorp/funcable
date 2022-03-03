using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Option_OnSome_Should
{
	[Fact]
	public void Invoke_Handler_And_Return_Self_When_Some() =>
		Some(HelloWorld).OnSome(
			t => t.Should().Be(HelloWorld)
		);

	[Fact]
	public void Not_Invoke_Handler_And_Return_Self_When_None()
	{
		var greeting = string.Empty;
		None<string>().OnSome(
			_ => greeting = HelloWorld
		);
		greeting.Should().Be(string.Empty);
	}
}

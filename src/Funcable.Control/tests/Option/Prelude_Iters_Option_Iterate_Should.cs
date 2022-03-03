using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Iters_Option_Iterate_Should
{
	[Fact]
	public void Iteratate_T_In_IOption_T_When_IOption_Is_Some()
	{
		var greeting = string.Empty;
		Iterate(
			Some(HelloWorld),
			t => greeting = t
		);
		greeting.Should().Be(HelloWorld);
	}

	[Fact]
	public void Iteratate_T_In_IOption_T_When_IOption_Is_None()
	{
		var greeting = string.Empty;
		Iterate(
			None<string>(),
			t => greeting = t
		);
		greeting.Should().Be(string.Empty);
	}

	[Fact]
	public void Iterate_Ts_In_IOption_T_When_IOption_Is_Some()
	{
		var greeting = string.Empty;
		Iterate(
			new[]
			{
					Some(HelloWorld),
					None<string>(),
					Some(HolaMundo)
			},
			t => greeting = greeting switch { { Length: 0 } => t, _ => $"{greeting} {t}" }
		);
		greeting.Should().Be("Hello, World! Hola, Mundo!");
	}
}

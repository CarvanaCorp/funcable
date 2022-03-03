using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Iters_Result_Iterate_Should
{
	[Fact]
	public void Iterate_T_In_IResult_T_When_IResult_Is_Ok()
	{
		var greeting = string.Empty;
		Iterate(
			Ok<string, int>(HelloWorld),
			t => greeting = t
		);
		greeting.Should().Be(HelloWorld);
	}

	[Fact]
	public void Iterate_T_In_IResult_T_When_IResult_Is_Error()
	{
		var greeting = string.Empty;
		Iterate(
			Error<string, int>(FortyTwo),
			t => greeting = t
		);
		greeting.Should().Be(string.Empty);
	}

	[Fact]
	public void Iterate_Ts_In_IResult_T_When_IResult_Is_Ok()
	{
		var greeting = string.Empty;
		Iterate(
			new[]
			{
					Ok<string, int>(HelloWorld),
					Error<string, int>(-1),
					Ok<string, int>(HolaMundo)
			},
			t => greeting = greeting switch { { Length: 0 } => t, _ => $"{greeting} {t}" }
		);
		greeting.Should().Be("Hello, World! Hola, Mundo!");
	}
}

using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Iters_Result_BiIterate_Should
{
	[Fact]
	public void Iterate_T_In_IResult_When_IResult_Is_Ok_T()
	{
		var greeting = string.Empty;
		BiIterate(
			Ok<string, int>(HelloWorld),
			t => greeting = greeting switch { { Length: 0 } => t, _ => $"{greeting} {t}" },
			error => greeting = greeting switch { { Length: 0 } => error.ToString(), _ => $"{greeting} {error}" }
		);
		greeting.Should().Be(HelloWorld);
	}

	[Fact]
	public void Iterate_TError_In_IResult_When_IResult_Is_Error_TError()
	{
		var greeting = string.Empty;
		BiIterate(
			Error<string, int>(-1),
			t => greeting = greeting switch { { Length: 0 } => t, _ => $"{greeting} {t}" },
			error => greeting = greeting switch { { Length: 0 } => error.ToString(), _ => $"{greeting} {error}" }
		);
		greeting.Should().Be("-1");
	}

	[Fact]
	public void Iterate_Ts_And_TErrors_In_IResults()
	{
		var greeting = string.Empty;
		BiIterate(
			new[]
			{
					Ok<string, int>(HelloWorld),
					Error<string, int>(-1),
					Ok<string, int>(HolaMundo),
					Error<string, int>(-20),
			},
			t => greeting = greeting switch { { Length: 0 } => t, _ => $"{greeting} {t}" },
			error => greeting = greeting switch { { Length: 0 } => error.ToString(), _ => $"{greeting} {error}" }
		);
		greeting.Should().Be("Hello, World! -1 Hola, Mundo! -20");
	}
}

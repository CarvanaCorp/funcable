using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Iters_Result_IterateError_Should
{
	[Fact]
	public void Iterate_TError_In_IResult_T_When_IResult_Is_Error()
	{
		var greeting = string.Empty;
		IterateError(
			Error<int, string>(HelloWorld),
			t => greeting = t
		);
		greeting.Should().Be(HelloWorld);
	}

	[Fact]
	public void Iterate_T_In_IResult_T_When_IResult_Is_Ok()
	{
		var greeting = string.Empty;
		IterateError(
			Ok<int, string>(FortyTwo),
			t => greeting = t
		);
		greeting.Should().Be(string.Empty);
	}

	[Fact]
	public void Iterate_Ts_In_IResult_T_When_IResult_Is_Error()
	{
		var greeting = string.Empty;
		IterateError(
			new[]
			{
					Ok<int, string>(FortyTwo),
					Error<int, string>(HelloWorld),
					Ok<int, string>(NegativeOne)
			},
			t => greeting = greeting switch { { Length: 0 } => t, _ => $"{greeting} {t}" }
		);
		greeting.Should().Be(HelloWorld);
	}
}

using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Results_IterateError_Should
	{
		[Fact]
		public void Iterate_TError_In_IResult_T_When_IResult_Is_Error()
		{
			var greeting = string.Empty;
			Error<int, string>(HelloWorld).IterateError(
				t => greeting = t
			);
			greeting.Should().Be(HelloWorld);
		}

		[Fact]
		public void Iterate_T_In_IResult_T_When_IResult_Is_Ok()
		{
			var greeting = string.Empty;
			Ok<int, string>(FortyTwo).IterateError(
				t => greeting = t
			);
			greeting.Should().Be(string.Empty);
		}

		[Fact]
		public void Iterate_Ts_In_IResult_T_When_IResult_Is_Error()
		{
			var greeting = string.Empty;
			new[]
			{
				Ok<int, string>(FortyTwo),
				Error<int, string>(HelloWorld),
				Ok<int, string>(NegativeOne)
			}.IterateError(
				t => greeting = greeting switch { { Length: 0 } => t, _ => $"{greeting} {t}" }
			);
			greeting.Should().Be(HelloWorld);
		}
	}

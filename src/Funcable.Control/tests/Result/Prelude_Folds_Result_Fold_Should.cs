using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Folds_Result_Fold_Should
{
	[Fact]
	public void Reduce_T_In_IResult_T_When_IResult_Is_Ok() =>
		Fold(
			Ok<string, int>(HelloWorld),
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be(HelloWorld);

	[Fact]
	public void Reduce_Ts_In_IResult_T_When_IResult_Is_Ok() =>
		Fold(
			new[]
			{
					Ok<string, int>(HelloWorld),
					Error<string, int>(-1),
					Ok<string, int>(HolaMundo)
			},
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be("Hello, World! Hola, Mundo!");
}

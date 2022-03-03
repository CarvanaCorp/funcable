using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Folds_Result_FoldBack_Should
{
	[Fact]
	public void Reverse_Reduce_Ts_In_IResult_T_When_IResult_Is_Ok() =>
		FoldBack(
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
		.Be("Hola, Mundo! Hello, World!");
}

using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Folds_Result_FoldErrorBack_Should
{
	[Fact]
	public void Reverse_Reduce_TErrors_In_IResult_TError_When_IResult_Is_Error() =>
		FoldErrorBack(
			new[]
			{
					Ok<int, string>(-1),
					Error<int, string>(HelloWorld),
					Ok<int, string>(-1),
					Error<int, string>(HolaMundo),
			},
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be("Hola, Mundo! Hello, World!");
}

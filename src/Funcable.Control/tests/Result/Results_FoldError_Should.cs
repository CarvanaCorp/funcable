using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Results_FoldError_Should
{
	[Fact]
	public void Reduce_TError_In_IResult_TError_When_IResult_Is_Error() =>
		Error<int, string>(HelloWorld).FoldError(
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be(HelloWorld);

	[Fact]
	public void Reduce_TErrors_In_IResult_TError_When_IResult_Is_Error() =>
		new[]
		{
				Ok<int, string>(-1),
				Error<int, string>(HelloWorld),
				Ok<int, string>(-1),
				Error<int, string>(HolaMundo),
		}
		.FoldError(
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be("Hello, World! Hola, Mundo!");
}

using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Folds_Option_FoldBack_Should
{
	[Fact]
	public void Reverse_Reduce_T_In_IOption_T_When_IOption_Is_Some() =>
		FoldBack(
			Some(HelloWorld),
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be(HelloWorld);

	[Fact]
	public void Reverse_Reduce_T_In_IOption_T_When_IOption_Is_None() =>
		FoldBack(
			None<string>(),
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be(string.Empty);

	[Fact]
	public void Reverse_Reduce_Ts_In_IOption_T_When_IOption_Is_Some() =>
		FoldBack(
			new[]
			{
					Some(HelloWorld),
					None<string>(),
					Some(HolaMundo)
			},
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be("Hola, Mundo! Hello, World!");
}

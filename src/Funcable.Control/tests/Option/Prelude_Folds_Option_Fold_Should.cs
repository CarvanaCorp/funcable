using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Folds_Option_Fold_Should
{
	[Fact]
	public void Reduce_T_In_IOption_T_When_IOption_Is_Some() =>
		Fold(
			Some(HelloWorld),
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be(HelloWorld);

	[Fact]
	public void Reduce_T_In_IOption_T_When_IOption_Is_None() =>
		Fold(
			None<string>(),
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be(string.Empty);

	[Fact]
	public void Reduce_Ts_In_IOption_T_When_IOption_Is_Some() =>
		Fold(
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
		.Be("Hello, World! Hola, Mundo!");
}

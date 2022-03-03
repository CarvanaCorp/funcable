using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Options_FoldBack_Should
{
	[Fact]
	public void Reverse_Reduce_T_In_IOption_T_When_IOption_Is_Some() =>
		Some(HelloWorld).FoldBack(
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be(HelloWorld);

	[Fact]
	public void Reverse_Reduce_T_In_IOption_T_When_IOption_Is_None() =>
		None<string>().FoldBack(
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be(string.Empty);

	[Fact]
	public void Reverse_Reduce_Ts_In_IOption_T_When_IOption_Is_Some() =>
		new[]
		{
				Some(HelloWorld),
				None<string>(),
				Some(HolaMundo)
		}
		.FoldBack(
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" }
		)
		.Should()
		.Be("Hola, Mundo! Hello, World!");
}

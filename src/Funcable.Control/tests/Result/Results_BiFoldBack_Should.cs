using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Results_BiFoldBack_Should
{
	[Fact]
	public void Reverse_Reduce_Ts_And_TErrors_In_IResults() =>
		new[]
		{
				Ok<string, int>(HelloWorld),
				Error<string, int>(-1),
				Ok<string, int>(HolaMundo),
				Error<string, int>(-20),
		}
		.BiFoldBack(
			string.Empty,
			(state, t) => state switch { { Length: 0 } => t, _ => $"{state} {t}" },
			(state, error) => state switch { { Length: 0 } => error.ToString(), _ => $"{state} {error}" }
		)
		.Should()
		.Be("-20 Hola, Mundo! -1 Hello, World!");
}

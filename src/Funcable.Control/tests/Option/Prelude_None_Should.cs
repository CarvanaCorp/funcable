using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;

namespace Funcable.Control.Tests;

public class Prelude_None_Should
{
	[Fact]
	public void Construct_A_None_Of_T() =>
		None<string>()
			.Should()
			.BeOfType<None<string>>();
}

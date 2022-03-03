using FluentAssertions;
using Funcable.Core;
using Xunit;

namespace Funcable.Control.Tests;

public class Prelude_Unit_Should
{
	[Fact]
	public void Return_A_Unit() =>
		Prelude.Unit.Should().Be(new Unit());
}

using FluentAssertions;
using Funcable.Core;
using Xunit;

namespace Funcable.Control.Tests;

public class Prelude_Error2_Should
{
	[Fact]
	public void Return_A_Error() =>
		Prelude
			.Error("Ouch", "1234")
			.Should()
			.Be(new Error("Ouch", "1234"));
}

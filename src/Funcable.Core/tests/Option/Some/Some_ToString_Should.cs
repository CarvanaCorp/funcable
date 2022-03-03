using FluentAssertions;
using Xunit;

namespace Funcable.Core.Tests;

public class Some_ToString_Should
{
	[Fact]
	public void Return_Some_With_Wrapped_To_String() =>
		Option.Some("Hello")
			.ToString()
			.Should()
			.Be("Some: Hello");
}

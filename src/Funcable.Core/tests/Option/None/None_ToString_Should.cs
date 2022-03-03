using FluentAssertions;
using Xunit;

namespace Funcable.Core.Tests;

public class None_ToString_Should
{
	[Fact]
	public void Return_None() =>
		Option.None<string>()
			.ToString()
			.Should()
			.Be("None");
}

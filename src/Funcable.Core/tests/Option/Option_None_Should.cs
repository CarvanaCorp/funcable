using FluentAssertions;
using Xunit;

namespace Funcable.Core.Tests;

public class Option_None_Should
{
	[Fact]
	public void Construct_A_None_Of_T() =>
		Option.None<string>()
			.Should()
			.BeOfType<None<string>>();
}

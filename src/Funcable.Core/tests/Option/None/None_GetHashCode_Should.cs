using FluentAssertions;
using Xunit;

namespace Funcable.Core.Tests;

public class None_GetHashCode_Should
{
	[Fact]
	public void Return_Same_HashCode_By_Type() =>
		(Option.None<string>().GetHashCode() == Option.None<string>().GetHashCode())
			.Should()
			.BeTrue();
}

using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Some_GetHashCode_Should
{
	[Fact]
	public void Return_Same_HashCode_By_Type() =>
		(Option.Some(HelloWorld).GetHashCode() == Option.Some(HelloWorld).GetHashCode())
			.Should()
			.BeTrue();
}

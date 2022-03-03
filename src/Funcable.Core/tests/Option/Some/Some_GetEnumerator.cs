using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Some_GetEnumerator_Should
{
	[Fact]
	public void Return_An_Enumerator() =>
		Option.Some(HelloWorld)
			.First()
			.Should()
			.Be(HelloWorld);
}

using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Ok_GetEnumerator_Should
{
	[Fact]
	public void Return_An_Enumerator() =>
		Result.Ok<string, int>(HelloWorld)
			.First()
			.Should()
			.Be(HelloWorld);
}

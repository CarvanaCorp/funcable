using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Ok_GetHashCode_Should
{
	[Fact]
	public void Return_Same_HashCode_By_Type() =>
		(Result.Ok<string, int>(HelloWorld).GetHashCode() == Result.Ok<string, int>(HelloWorld).GetHashCode())
			.Should()
			.BeTrue();
}

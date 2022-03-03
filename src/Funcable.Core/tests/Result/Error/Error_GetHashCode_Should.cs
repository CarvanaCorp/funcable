using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Error_GetHashCode_Should
{
	[Fact]
	public void Return_Error_HashCode_By_Type() =>
		(Result.Error<int, string>(HelloWorld).GetHashCode() == Result.Error<int, string>(HelloWorld).GetHashCode())
			.Should()
			.BeTrue();
}

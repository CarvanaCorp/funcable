using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class ResultError_ToString_Should
{
	[Fact]
	public void Return_Error_With_Wrapped_To_String() =>
		Result.Error<string, int>(FortyTwo)
			.ToString()
			.Should()
			.Be("Error: 42");
}

using FluentAssertions;
using Xunit;

namespace Funcable.Core.Tests;

public class Ok_ToString_Should
{
	[Fact]
	public void Return_Ok_With_Wrapped_To_String() =>
		Result.Ok<string, int>("Hello")
			.ToString()
			.Should()
			.Be("Ok: Hello");
}

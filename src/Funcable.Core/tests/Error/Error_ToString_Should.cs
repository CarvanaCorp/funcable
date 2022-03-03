using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Error_ToString_Should
{
	[Fact]
	public void Return_Error_Message_When_Error_Has_No_Code() =>
		new Error(HelloWorld)
			.ToString()
			.Should()
			.Be($"Error {HelloWorld}");

	[Fact]
	public void Return_Error_Code_Message_When_Error_Has_Code() =>
		new Error(HelloWorld, Code: HolaMundo)
			.ToString()
			.Should()
			.Be($"Error {HolaMundo} {HelloWorld}");
}

using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Ok_Explicit_Cast_Should
{
	[Fact]
	public void Return_Wrapped_T() =>
		((string)(Ok<string, int>)Result.Ok<string, int>(HelloWorld))
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Throw_InvalidCastException_When_Wrapped_Is_Null() =>
		new Action(() => { var t = (string)new Ok<string, int>(); })
			.Should()
			.Throw<InvalidCastException>()
			.WithMessage("Ok`2 cast: null");
}

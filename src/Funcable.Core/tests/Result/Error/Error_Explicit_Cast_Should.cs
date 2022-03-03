using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Error_Explicit_Cast_Should
{
	[Fact]
	public void Return_Wrapped_T() =>
		((string)(Error<int, string>)Result.Error<int, string>(HelloWorld))
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Throw_InvalidCastException_When_Wrapped_Is_Null() =>
		new Action(() => { var t = (string)new Error<int, string>(); })
			.Should()
			.Throw<InvalidCastException>()
			.WithMessage("Error`2 cast: null");
}

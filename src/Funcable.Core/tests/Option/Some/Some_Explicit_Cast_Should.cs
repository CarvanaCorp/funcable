using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Some_Explicit_Cast_Should
{
	[Fact]
	public void Return_Wrapped_T() =>
		((string)(Some<string>)Option.Some(HelloWorld))
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Throw_InvalidCastException_When_Wrapped_Is_Null() =>
		new Action(() => { var t = (string)new Some<string>(); })
			.Should()
			.Throw<InvalidCastException>()
			.WithMessage("Some`1 cast: null");
}

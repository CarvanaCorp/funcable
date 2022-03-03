using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_IsNone_Should
{
	[Fact]
	public void Return_True_When_IOption_T_Is_None_T() =>
		IsNone(None<string>())
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IOption_T_Is_Not_None_T() =>
		IsNone(Some(HelloWorld))
			.Should()
			.BeFalse();
}

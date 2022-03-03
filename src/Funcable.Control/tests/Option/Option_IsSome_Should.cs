using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Option_IsSome_Should
{
	[Fact]
	public void Return_True_When_IOption_T_Is_Some_T() =>
		Some(HelloWorld).IsSome()
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IOption_T_Is_Not_Some_T() =>
		None<string>().IsSome()
			.Should()
			.BeFalse();
}

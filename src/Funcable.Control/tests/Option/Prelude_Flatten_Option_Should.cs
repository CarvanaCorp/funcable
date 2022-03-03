using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Flatten_Option_Should
{
	[Fact]
	public void Extract_Some_When_T_Is_Some() =>
		Flatten(
			Some(Some(HelloWorld))
		)
		.Should<IOption<string>>()
		.Be(Some(HelloWorld));

	[Fact]
	public void Return_None_When_T_Is_None() =>
		Flatten(
			Some(None<string>())
		)
		.Should<IOption<string>>()
		.Be(None<string>());

	[Fact]
	public void Return_None_When_Is_None() =>
		Flatten(
			None<IOption<string>>()
		)
		.Should<IOption<string>>()
		.Be(None<string>());
}

using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Option_Flatten_Should
{
	[Fact]
	public void Extract_Some_When_T_Is_Some() =>
		Some(Some(HelloWorld))
			.Flatten()
			.Should<IOption<string>>()
			.Be(Some(HelloWorld));

	[Fact]
	public void Return_None_When_T_Is_None() =>
		Some(None<string>())
			.Flatten()
			.Should<IOption<string>>()
			.Be(None<string>());

	[Fact]
	public void Return_None_When_Is_None() =>
		None<IOption<string>>()
			.Flatten()
			.Should<IOption<string>>()
			.Be(None<string>());
}

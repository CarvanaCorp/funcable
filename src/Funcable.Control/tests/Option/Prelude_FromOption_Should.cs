using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_FromOption_Should
{
	[Fact]
	public void Return_T_When_IOption_Of_T_Is_Some_Of_T() =>
		FromOption(Some(HelloWorld), HolaMundo)
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Return_DefaultValue_When_IOption_Of_T_Is_None_Of_T() =>
		FromOption(None<string>(), HolaMundo)
			.Should()
			.Be(HolaMundo);

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled() =>
		new Action(() => FromOption(new TestSome<string>(), HolaMundo))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");
}

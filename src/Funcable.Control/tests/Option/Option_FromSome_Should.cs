using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Option_FromSome_Should
{
	[Fact]
	public void Return_T_When_IOption_Of_T_Is_Some_Of_T() =>
		Some(HelloWorld)
			.FromSome()
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Throw_InvalidOperationException_When_IOption_Of_T_Is_None_Of_T() =>
		new Action(() => None<string>().FromSome())
			.Should()
			.Throw<InvalidOperationException>()
			.WithMessage("IOption`1.FromSome: None`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled() =>
		new Action(() => new TestSome<string>().FromSome())
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.FromSome: TestSome`1");
}

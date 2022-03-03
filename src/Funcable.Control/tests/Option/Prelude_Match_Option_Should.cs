using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Match_Option_Should
{
	[Fact]
	public void Invoke_SomeMatch_And_Return_U_When_IOption_Of_T_Is_Some_Of_T() =>
		Match(Some(FortyTwo), _ => HelloWorld, HolaMundo)
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Invoke_SomeMatch_And_Return_U_When_IOption_Of_T_Is_Some_Of_T_2() =>
		Match(Some(FortyTwo), _ => HelloWorld, () => HolaMundo)
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Return_DefaultValue_When_Option_Of_T_Is_None_Of_T() =>
		Match(None<string>(), _ => HelloWorld, HolaMundo)
			.Should()
			.Be(HolaMundo);

	[Fact]
	public void Invoke_NoneMatch_And_Return_U_When_IOption_Of_T_IsNone_Of_T() =>
		Match(None<string>(), _ => HelloWorld, () => HolaMundo)
			.Should()
			.Be(HolaMundo);

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled() =>
		new Action(() => Match(new TestSome<string>(), _ => HelloWorld, HolaMundo))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");
}

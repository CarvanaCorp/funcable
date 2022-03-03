using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Match_Result_Should
{
	[Fact]
	public void Invoke_OkMatch_And_Return_U_When_IResult_Of_T_Is_Ok_Of_T() =>
		Match(Ok<int, int>(FortyTwo), a => HelloWorld, e => HolaMundo)
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Return_DefaultValue_When_Result_Of_T_Is_Error_Of_T() =>
		Match(Error<string, int>(FortyTwo), a => HelloWorld, e => HolaMundo)
			.Should()
			.Be(HolaMundo);

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Action(() => Match(new TestOk<int, string>(), a => HelloWorld, e => HolaMundo))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

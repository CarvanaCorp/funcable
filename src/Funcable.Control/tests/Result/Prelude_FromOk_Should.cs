using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_FromOk_Should
{
	[Fact]
	public void Return_T_When_IResult_Of_T_Is_Ok_Of_T() =>
		FromOk(Ok<string, int>(HelloWorld))
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Throw_InvalidOperationException_When_IResult_Of_T_Is_Error_Of_T() =>
		new Action(() => FromOk(Error<string, int>(NegativeOne)))
			.Should()
			.Throw<InvalidOperationException>()
			.WithMessage("IResult`2.FromOk: Error`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Action(() => FromOk(new TestOk<string, int>()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.FromOk: TestOk`2");
}

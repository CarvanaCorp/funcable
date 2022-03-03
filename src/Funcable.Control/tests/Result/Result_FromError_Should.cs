using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Result_FromError_Should
{
	[Fact]
	public void Return_TError_When_IResult_Of_TError_Is_Error_Of_TError() =>
		Error<string, int>(NegativeOne)
			.FromError()
			.Should()
			.Be(NegativeOne);

	[Fact]
	public void Throw_InvalidOperationException_When_IResult_Of_TError_Is_Ok_Of_T() =>
		new Action(() => Ok<string, int>(HelloWorld).FromError())
			.Should()
			.Throw<InvalidOperationException>()
			.WithMessage("IResult`2.FromError: Ok`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Action(() => new TestOk<string, int>().FromError())
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.FromError: TestOk`2");
}

using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_ErrorMonad_Result_Should
{
	[Fact]
	public void Unwrap_TError_In_IResult_Of_TError_And_Invoke_Binder_And_Return_Result_In_IResult_Of_UError() =>
		BindError(Error<string, int>(FortyTwo), i => Error<string, double>(ToInt(i)))
			.Should<IResult<string, double>>()
			.Be(Error<string, double>(NegativeOne));

	[Fact]
	public void Not_Unwrap_TError_In_IResult_Of_T_But_Return_An_IResult_Of_UError_When_IResult_Of_T_Is_Ok() =>
		BindError(Ok<string, int>(HelloWorld), s => Error<string, int>(ToInt(s)))
			.Should<IResult<string, int>>()
			.Be(Ok<string, int>(HelloWorld));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Action(() => BindError(new TestOk<string, int>(), s => Error<string, int>(ToInt(s))))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

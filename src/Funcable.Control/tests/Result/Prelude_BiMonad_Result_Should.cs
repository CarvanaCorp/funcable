using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_BiMonad_Result_Should
{
	[Fact]
	public void Unwrap_T_In_IResult_Of_T_And_Invoke_OkBinder_And_Return_Result_In_IResult_Of_U() =>
		BiBind(Ok<string, int>(HelloWorld), s => Ok<int, int>(ToInt(s)), i => Error<int, int>(i))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public void Unwrap_TError_In_IResult_Of_TError_And_Invoke_ErrorBinder_And_Return_Result_In_IResult_Of_UError() =>
		BiBind(Error<string, int>(FortyTwo), s => Ok<int, double>(ToInt(s)), i => Error<int, double>(ToInt(i)))
			.Should<IResult<int, double>>()
			.Be(Error<int, double>(NegativeOne));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Action(() => BiBind(new TestOk<string, int>(), s => Error<string, int>(ToInt(s)), i => Ok<string, int>(HelloWorld)))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

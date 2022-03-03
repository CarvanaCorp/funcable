using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Result_Bind_Should
{
	[Fact]
	public void Unwrap_T_In_IResult_Of_T_And_Invoke_Binder_And_Return_Result_In_IResult_Of_U() =>
		Ok<string, int>(HelloWorld).Bind(s => Ok<int, int>(ToInt(s)))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public void Not_Unwrap_T_In_IResult_Of_T_But_Return_An_IResult_Of_U_When_IResult_Of_T_Is_Error() =>
		Error<string, int>(NegativeOne).Bind(s => Ok<int, int>(ToInt(s)))
			.Should<IResult<int, int>>()
			.Be(Error<int, int>(NegativeOne));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Action(() => new TestOk<string, int>().Bind(s => Ok<int, int>(ToInt(s))))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

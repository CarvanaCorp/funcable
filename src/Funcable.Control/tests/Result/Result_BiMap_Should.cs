using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Result_BiMap_Should
{
	[Fact]
	public void Unwrap_T_In_IResult_Of_T_And_Invoke_OkMapping_And_Return_Result_In_IResult_Of_U() =>
		Ok<string, int>(HelloWorld).BiMap(ToInt, ToInt)
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public void Unwrap_TError_In_IResult_Of_TError_And_Invoke_ErrorMapping_And_Return_Result_In_IResult_Of_UError() =>
		Error<string, int>(FortyTwo).BiMap(ToInt, ToInt)
			.Should<IResult<int, int>>()
			.Be(Error<int, int>(NegativeOne));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Action(() => new TestOk<string, int>().BiMap(ToInt, ToInt))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

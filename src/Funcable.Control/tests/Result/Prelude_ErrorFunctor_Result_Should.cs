using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_ErrorFunctor_Result_Should
{
	[Fact]
	public void Unwrap_TError_In_IResult_Of_TError_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_UError() =>
		MapError(Error<string, int>(FortyTwo), ToInt)
			.Should<IResult<string, int>>()
			.BeOfType<Error<string, int>>()
			.And
			.Be(Error<string, int>(NegativeOne));

	[Fact]
	public void Not_Unwrap_TError_In_IResult_Of_TError_But_Return_An_IResult_Of_UError_When_IResult_Of_T_Is_Ok() =>
		MapError(Ok<string, int>(HelloWorld), ToInt)
			.Should<IResult<string, int>>()
			.BeOfType<Ok<string, int>>()
			.And
			.Be(Ok<string, int>(HelloWorld));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Action(() => MapError(new TestOk<string, int>(), ToInt))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Functor_Result_Should
{
	[Fact]
	public void Unwrap_T_In_IResult_Of_T_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_U() =>
		Map(Ok<string, int>(HelloWorld), ToInt)
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public void Not_Unwrap_T_In_IResult_Of_T_But_Return_An_IResult_Of_U_When_IResult_Of_T_Is_Error() =>
		Map(Error<string, int>(NegativeOne), ToInt)
			.Should()
			.BeOfType<Error<int, int>>();

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Action(() => Map(new TestOk<string, int>(), ToInt))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

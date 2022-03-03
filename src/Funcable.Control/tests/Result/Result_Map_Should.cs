using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Result_Map_Should
{
	[Fact]
	public void Unwrap_T_In_IResult_Of_T_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_U() =>
		Ok<string, int>(HelloWorld).Map(ToInt)
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public void Not_Unwrap_T_In_IResult_Of_T_But_Return_An_IResult_Of_U_When_IResult_Of_T_Is_Errors() =>
		Error<string, int>(NegativeOne).Map(ToInt)
			.Should<IResult<int, int>>()
			.BeOfType<Error<int, int>>();

	[Fact]
	public void Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_V() =>
		Ok<string, int>(HelloWorld).Map(Ok<int, int>(FortyTwo), ToDouble)
			.Should<IResult<double, int>>()
			.Be(Ok<double, int>(Pi));

	[Fact]
	public void Not_Unwrap_Types_But_Return_An_IResult_Of_V_When_IResult_Of_T_Is_Error() =>
		Error<string, int>(NegativeOne).Map(Ok<int, int>(FortyTwo), ToDouble)
			.Should<IResult<double, int>>()
			.Be(Error<double, int>(NegativeOne));

	[Fact]
	public void Not_Unwrap_Types_But_Return_An_IResult_Of_V_When_IResult_Of_U_Is_Error() =>
		Ok<string, int>(HelloWorld).Map(Error<int, int>(NegativeOne), ToDouble)
			.Should<IResult<double, int>>()
			.Be(Error<double, int>(NegativeOne));

	[Fact]
	public void Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_X() =>
		Ok<string, int>(HelloWorld).Map(Ok<int, int>(FortyTwo), Ok<double, int>(Pi), ToChar)
			.Should<IResult<char, int>>()
			.Be(Ok<char, int>(A));

	[Fact]
	public void Not_Unwrap_Types_But_Return_An_IResult_Of_X_When_IResult_Of_T_Is_Error() =>
		Error<string, int>(NegativeOne).Map(Ok<int, int>(FortyTwo), Ok<double, int>(Pi), ToChar)
			.Should<IResult<char, int>>()
			.Be(Error<char, int>(NegativeOne));

	[Fact]
	public void Not_Unwrap_Types_But_Return_An_IResult_Of_X_When_IResult_Of_U_Is_Error() =>
		Ok<string, int>(HelloWorld).Map(Error<int, int>(NegativeOne), Ok<double, int>(Pi), ToChar)
			.Should<IResult<char, int>>()
			.Be(Error<char, int>(NegativeOne));

	[Fact]
	public void Not_Unwrap_Types_But_Return_An_IResult_Of_X_When_IResult_Of_V_Is_Error() =>
		Ok<string, int>(HelloWorld).Map(Ok<int, int>(FortyTwo), Error<double, int>(NegativeOne), ToChar)
			.Should<IResult<char, int>>()
			.Be(Error<char, int>(NegativeOne));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled_1() =>
		new Action(() => new TestOk<string, int>().Map(Ok<int, int>(FortyTwo), ToDouble))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_U_Pattern_Not_Handled_1() =>
		new Action(() => Ok<string, int>(HelloWorld).Map(new TestOk<int, int>(), ToDouble))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled_2() =>
		new Action(() => new TestOk<string, int>().Map(Ok<int, int>(FortyTwo), Ok<double, int>(Pi), ToChar))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_U_Pattern_Not_Handled_2() =>
		new Action(() => Ok<string, int>(HelloWorld).Map(Ok<int, int>(FortyTwo), new TestOk<double, int>(), ToChar))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Action(() => new TestOk<string, int>().Map(ToInt))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

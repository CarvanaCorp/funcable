using Xunit;

namespace Funcable.Control.Tests;

public class TaskResult_Map_Should
{
	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_U() =>
		(await AsyncOk<string, int>(HelloWorld).Map(async s => await ToInt(s).AsTask()))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_U_2() =>
		(await AsyncOk<string, int>(HelloWorld).Map(ToInt))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Not_Unwrap_T_In_IResult_Of_T_But_Return_An_IResult_Of_U_When_IResult_Of_T_Is_Error() =>
		(await AsyncError<string, int>(NegativeOne).Map(async s => await ToInt(s).AsTask()))
			.Should()
			.BeOfType<Error<int, int>>();

	[Fact]
	public async Task Not_Unwrap_T_In_IResult_Of_T_But_Return_An_IResult_Of_U_When_IResult_Of_T_Is_Error_2() =>
		(await AsyncError<string, int>(NegativeOne).Map(ToInt))
			.Should()
			.BeOfType<Error<int, int>>();

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await ((IResult<string, int>)new TestOk<string, int>()).AsTask().Map(ToInt))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

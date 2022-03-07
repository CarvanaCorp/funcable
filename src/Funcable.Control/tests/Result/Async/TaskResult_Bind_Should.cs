using Xunit;

namespace Funcable.Control.Tests;

public class TaskResult_Bind_Should
{
	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_Binder_And_Return_Result_In_IResult_Of_U() =>
		(await AsyncOk<string, int>(HelloWorld).Bind(s => AsyncOk<int, int>(ToInt(s))))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_Binder_And_Return_Result_In_IResult_Of_U_2() =>
		(await AsyncOk<string, int>(HelloWorld).Bind(s => Ok<int, int>(ToInt(s))))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Not_Unwrap_T_In_IResult_Of_T_But_Return_An_IResult_Of_U_When_IResult_Of_T_Is_Error() =>
		(await AsyncError<string, int>(NegativeOne).Bind(s => AsyncOk<int, int>(ToInt(s))))
			.Should<IResult<int, int>>()
			.Be(Error<int, int>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_T_In_IResult_Of_T_But_Return_An_IResult_Of_U_When_IResult_Of_T_Is_Error_2() =>
		(await AsyncError<string, int>(NegativeOne).Bind(s => Ok<int, int>(ToInt(s))))
			.Should<IResult<int, int>>()
			.Be(Error<int, int>(NegativeOne));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await ((IResult<string, int>)new TestOk<string, int>()).AsTask().Bind(s => Ok<int, int>(ToInt(s))))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

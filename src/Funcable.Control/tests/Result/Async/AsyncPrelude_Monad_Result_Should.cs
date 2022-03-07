using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Monad_Result_Should
{
	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_Binder_And_Return_Result_In_IResult_Of_U() =>
		(await Bind(AsyncOk<string, int>(HelloWorld), s => AsyncOk<int, int>(ToInt(s))))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_Binder_And_Return_Result_In_IResult_Of_U_2() =>
		(await Bind(AsyncOk<string, int>(HelloWorld), s => Ok<int, int>(ToInt(s))))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Not_Unwrap_T_In_IResult_Of_T_But_Return_An_IResult_Of_U_When_IResult_Of_T_Is_Error() =>
		(await Bind(AsyncError<string, int>(NegativeOne), s => AsyncOk<int, int>(ToInt(s))))
			.Should<IResult<int, int>>()
			.Be(Error<int, int>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_T_In_IResult_Of_T_But_Return_An_IResult_Of_U_When_IResult_Of_T_Is_Error_2() =>
		(await Bind(AsyncError<string, int>(NegativeOne), s => Ok<int, int>(ToInt(s))))
			.Should<IResult<int, int>>()
			.Be(Error<int, int>(NegativeOne));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await Bind(((IResult<string, int>)new TestOk<string, int>()).AsTask(), s => Ok<int, int>(ToInt(s))))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

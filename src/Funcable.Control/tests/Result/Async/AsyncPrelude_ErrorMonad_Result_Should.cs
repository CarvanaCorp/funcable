using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_ErrorMonad_Result_Should
{
	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_Binder_And_Return_Result_In_IResult_Of_UError() =>
		(await BindError(AsyncError<string, int>(FortyTwo), async i => await AsyncError<string, double>(ToInt(i))))
			.Should<IResult<string, double>>()
			.Be(Error<string, double>(NegativeOne));

	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_Binder_And_Return_Result_In_IResult_Of_UError_2() =>
		(await BindError(AsyncError<string, int>(FortyTwo), i => Error<string, double>(ToInt(i))))
			.Should<IResult<string, double>>()
			.Be(Error<string, double>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_TError_In_IResult_Of_T_But_Return_An_IResult_Of_UError_When_IResult_Of_T_Is_Ok() =>
		(await BindError(AsyncOk<string, int>(HelloWorld), async s => await AsyncError<string, int>(ToInt(s))))
			.Should<IResult<string, int>>()
			.Be(Ok<string, int>(HelloWorld));

	[Fact]
	public async Task Not_Unwrap_TError_In_IResult_Of_T_But_Return_An_IResult_Of_UError_When_IResult_Of_T_Is_Ok_2() =>
		(await BindError(AsyncOk<string, int>(HelloWorld), s => Error<string, int>(ToInt(s))))
			.Should<IResult<string, int>>()
			.Be(Ok<string, int>(HelloWorld));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await BindError(
			((IResult<string, int>)new TestOk<string, int>()).AsTask(),
			s => Error<string, int>(ToInt(s))))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class AsyncPrelude_BiMonad_Result_Should
{
	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_OkBinder_And_Return_Result_In_IResult_Of_U_1() =>
		(await BiBind(
			AsyncOk<string, int>(HelloWorld),
			async s => await AsyncOk<int, int>(ToInt(s)),
			async i => await AsyncError<int, int>(i)))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_OkBinder_And_Return_Result_In_IResult_Of_U_2() =>
		(await BiBind(
			AsyncOk<string, int>(HelloWorld),
			s => Ok<int, int>(ToInt(s)),
			async i => await AsyncError<int, int>(i)))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_OkBinder_And_Return_Result_In_IResult_Of_U_3() =>
		(await BiBind(
			AsyncOk<string, int>(HelloWorld),
			async s => await AsyncOk<int, int>(ToInt(s)),
			i => Error<int, int>(i)))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_OkBinder_And_Return_Result_In_IResult_Of_U_4() =>
		(await BiBind(AsyncOk<string, int>(HelloWorld), s => Ok<int, int>(ToInt(s)), i => Error<int, int>(i)))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_ErrorBinder_And_Return_Result_In_IResult_Of_UError_1() =>
		(await BiBind(
			AsyncError<string, int>(FortyTwo),
			async s => await AsyncOk<int, double>(ToInt(s)),
			async i => await AsyncError<int, double>(ToInt(i))))
			.Should<IResult<int, double>>()
			.Be(Error<int, double>(NegativeOne));

	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_ErrorBinder_And_Return_Result_In_IResult_Of_UError_2() =>
		(await BiBind(
			AsyncError<string, int>(FortyTwo),
			s => Ok<int, double>(ToInt(s)),
			async i => await AsyncError<int, double>(ToInt(i))))
			.Should<IResult<int, double>>()
			.Be(Error<int, double>(NegativeOne));

	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_ErrorBinder_And_Return_Result_In_IResult_Of_UError_3() =>
		(await BiBind(
			AsyncError<string, int>(FortyTwo),
			async s => await AsyncOk<int, double>(ToInt(s)),
			i => Error<int, double>(ToInt(i))))
			.Should<IResult<int, double>>()
			.Be(Error<int, double>(NegativeOne));

	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_ErrorBinder_And_Return_Result_In_IResult_Of_UError_4() =>
		(await BiBind(AsyncError<string, int>(FortyTwo), s => Ok<int, double>(ToInt(s)), i => Error<int, double>(ToInt(i))))
			.Should<IResult<int, double>>()
			.Be(Error<int, double>(NegativeOne));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await BiBind(
			((IResult<string, int>)new TestOk<string, int>()).AsTask(),
			s => Error<string, int>(ToInt(s)),
			i => Ok<string, int>(HelloWorld)))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class TaskResult_BindError_Should
{
	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_Binder_And_Return_Result_In_IResult_Of_UError() =>
		(await AsyncError<string, int>(FortyTwo).BindError(async i => await AsyncError<string, double>(ToInt(i))))
			.Should<IResult<string, double>>()
			.Be(Error<string, double>(NegativeOne));

	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_Binder_And_Return_Result_In_IResult_Of_UError_2() =>
		(await AsyncError<string, int>(FortyTwo).BindError(i => Error<string, double>(ToInt(i))))
			.Should<IResult<string, double>>()
			.Be(Error<string, double>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_TError_In_IResult_Of_T_But_Return_An_IResult_Of_UError_When_IResult_Of_T_Is_Ok() =>
		(await AsyncOk<string, int>(HelloWorld).BindError(async s => await AsyncError<string, int>(ToInt(s))))
			.Should<IResult<string, int>>()
			.Be(Ok<string, int>(HelloWorld));

	[Fact]
	public async Task Not_Unwrap_TError_In_IResult_Of_T_But_Return_An_IResult_Of_UError_When_IResult_Of_T_Is_Ok_2() =>
		(await AsyncOk<string, int>(HelloWorld).BindError(s => Error<string, int>(ToInt(s))))
			.Should<IResult<string, int>>()
			.Be(Ok<string, int>(HelloWorld));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await
			((IResult<string, int>)new TestOk<string, int>()).AsTask().BindError(
			s => Error<string, int>(ToInt(s))))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

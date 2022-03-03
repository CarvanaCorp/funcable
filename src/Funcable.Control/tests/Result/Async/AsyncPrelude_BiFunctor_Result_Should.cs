using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class AsyncPrelude_BiFunctor_Result_Should
{
	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_OkMapping_And_Return_Result_In_IResult_Of_U_1() =>
		(await BiMap(
			AsyncOk<string, int>(HelloWorld),
			async t => await ToInt(t).AsTask(),
			async e => await ToInt(e).AsTask()))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_OkMapping_And_Return_Result_In_IResult_Of_U_2() =>
		(await BiMap(
			AsyncOk<string, int>(HelloWorld),
			ToInt,
			async e => await ToInt(e).AsTask()))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_OkMapping_And_Return_Result_In_IResult_Of_U_3() =>
		(await BiMap(
			AsyncOk<string, int>(HelloWorld),
			async t => await ToInt(t).AsTask(),
			ToInt))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_OkMapping_And_Return_Result_In_IResult_Of_U_4() =>
		(await BiMap(AsyncOk<string, int>(HelloWorld), ToInt, ToInt))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_ErrorMapping_And_Return_Result_In_IResult_Of_UError_1() =>
		(await BiMap(
			AsyncError<string, int>(FortyTwo),
			async t => await ToInt(t).AsTask(),
			async e => await ToInt(e).AsTask()))
			.Should<IResult<int, int>>()
			.Be(Error<int, int>(NegativeOne));

	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_ErrorMapping_And_Return_Result_In_IResult_Of_UError_2() =>
		(await BiMap(
			AsyncError<string, int>(FortyTwo),
			ToInt,
			async e => await ToInt(e).AsTask()))
			.Should<IResult<int, int>>()
			.Be(Error<int, int>(NegativeOne));

	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_ErrorMapping_And_Return_Result_In_IResult_Of_UError_3() =>
		(await BiMap(
			AsyncError<string, int>(FortyTwo),
			async t => await ToInt(t).AsTask(),
			ToInt))
			.Should<IResult<int, int>>()
			.Be(Error<int, int>(NegativeOne));

	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_ErrorMapping_And_Return_Result_In_IResult_Of_UError_4() =>
		(await BiMap(AsyncError<string, int>(FortyTwo), ToInt, ToInt))
			.Should<IResult<int, int>>()
			.Be(Error<int, int>(NegativeOne));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await BiMap(((IResult<string, int>)new TestOk<string, int>()).AsTask(), ToInt, ToInt))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

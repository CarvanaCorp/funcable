using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_ErrorFunctor_Result_Should
{
	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_UError() =>
		(await MapError(AsyncError<string, int>(FortyTwo), async e => await ToInt(e).AsTask()))
			.Should<IResult<string, int>>()
			.BeOfType<Error<string, int>>()
			.And
			.Be(Error<string, int>(NegativeOne));

	[Fact]
	public async Task Unwrap_TError_In_IResult_Of_TError_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_UError_2() =>
		(await MapError(AsyncError<string, int>(FortyTwo), ToInt))
			.Should<IResult<string, int>>()
			.BeOfType<Error<string, int>>()
			.And
			.Be(Error<string, int>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_TError_In_IResult_Of_TError_But_Return_An_IResult_Of_UError_When_IResult_Of_T_Is_Ok() =>
		(await MapError(AsyncOk<string, int>(HelloWorld), async e => await ToInt(e).AsTask()))
			.Should<IResult<string, int>>()
			.BeOfType<Ok<string, int>>()
			.And
			.Be(Ok<string, int>(HelloWorld));


	[Fact]
	public async Task Not_Unwrap_TError_In_IResult_Of_TError_But_Return_An_IResult_Of_UError_When_IResult_Of_T_Is_Ok_2() =>
		(await MapError(AsyncOk<string, int>(HelloWorld), ToInt))
			.Should<IResult<string, int>>()
			.BeOfType<Ok<string, int>>()
			.And
			.Be(Ok<string, int>(HelloWorld));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await MapError(((IResult<string, int>)new TestOk<string, int>()).AsTask(), ToInt))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Functor_Result_Should
{
	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_U() =>
		(await Map(AsyncOk<string, int>(HelloWorld), async s => await ToInt(s).AsTask()))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IResult_Of_T_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_U_2() =>
		(await Map(AsyncOk<string, int>(HelloWorld), ToInt))
			.Should<IResult<int, int>>()
			.Be(Ok<int, int>(FortyTwo));

	[Fact]
	public async Task Not_Unwrap_T_In_IResult_Of_T_But_Return_An_IResult_Of_U_When_IResult_Of_T_Is_Error() =>
		(await Map(AsyncError<string, int>(NegativeOne), async s => await ToInt(s).AsTask()))
			.Should()
			.BeOfType<Error<int, int>>();

	[Fact]
	public async Task Not_Unwrap_T_In_IResult_Of_T_But_Return_An_IResult_Of_U_When_IResult_Of_T_Is_Error_2() =>
		(await Map(AsyncError<string, int>(NegativeOne), ToInt))
			.Should()
			.BeOfType<Error<int, int>>();

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await Map(((IResult<string, int>)new TestOk<string, int>()).AsTask(), ToInt))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

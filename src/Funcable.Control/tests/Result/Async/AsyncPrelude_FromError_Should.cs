using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_FromError_Should
{
	[Fact]
	public async Task Return_TError_When_IResult_Of_TError_Is_Error_Of_TError() =>
		(await FromError(AsyncError<string, int>(NegativeOne)))
			.Should()
			.Be(NegativeOne);

	[Fact]
	public void Throw_InvalidOperationException_When_IResult_Of_TError_Is_Ok_Of_T() =>
		new Func<Task>(async () => await FromError(AsyncOk<string, int>(HelloWorld)))
			.Should()
			.Throw<InvalidOperationException>()
			.WithMessage("IResult`2.FromError: Ok`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await FromError(((IResult<string, int>)new TestOk<string, int>()).AsTask()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.FromError: TestOk`2");
}

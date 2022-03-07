using Xunit;

namespace Funcable.Control.Tests;

public class TaskResult_FromOk_Should
{
	[Fact]
	public async Task Return_T_When_IResult_Of_T_Is_Ok_Of_T() =>
		(await AsyncOk<string, int>(HelloWorld).FromOk())
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Throw_InvalidOperationException_When_IResult_Of_T_Is_Error_Of_T() =>
		new Func<Task>(async () => await AsyncError<string, int>(NegativeOne).FromOk())
			.Should()
			.Throw<InvalidOperationException>()
			.WithMessage("IResult`2.FromOk: Error`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await ((IResult<string, int>)new TestOk<string, int>()).AsTask().FromOk())
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.FromOk: TestOk`2");
}

using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class AsyncPrelude_FromOk_Should
{
	[Fact]
	public async Task Return_Task_T_When_IResult_Of_T_Is_AsyncOk_Of_T() =>
		(await FromOk(AsyncOk<string, int>(HelloWorld)))
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Throw_InvalidOperationException_When_IResult_Of_T_Is_Error_Of_T() =>
		new Func<Task>(async () => await FromOk(AsyncError<string, int>(NegativeOne)))
			.Should()
			.Throw<InvalidOperationException>()
			.WithMessage("IResult`2.FromOk: Error`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await FromOk(((IResult<string, int>)new TestOk<string, int>()).AsTask()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.FromOk: TestOk`2");
}

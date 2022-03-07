using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_FromSome_Should
{
	[Fact]
	public async Task Return_Task_T_When_IOption_Of_T_Is_AsyncSome_Of_T() =>
		(await FromSome(AsyncSome(HelloWorld)))
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Throw_InvalidOperationException_When_IOption_Of_T_Is_None_Of_T() =>
		new Func<Task>(async () => await FromSome(AsyncNone<string>()))
			.Should()
			.Throw<InvalidOperationException>()
			.WithMessage("IOption`1.FromSome: None`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await FromSome(((IOption<string>)new TestSome<string>()).AsTask()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.FromSome: TestSome`1");
}

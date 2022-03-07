using Xunit;

namespace Funcable.Control.Tests;

public class TaskOption_FromSome_Should
{
	[Fact]
	public async Task Return_T_When_IOption_Of_T_Is_Some_Of_T() =>
		(await AsyncSome(HelloWorld).FromSome())
			.Should()
			.Be(HelloWorld);

	[Fact]
	public void Throw_InvalidOperationException_When_IOption_Of_T_Is_None_Of_T() =>
		new Func<Task>(async () => await AsyncNone<string>().FromSome())
			.Should()
			.Throw<InvalidOperationException>()
			.WithMessage("IOption`1.FromSome: None`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await ((IOption<string>)new TestSome<string>()).AsTask().FromSome())
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.FromSome: TestSome`1");
}

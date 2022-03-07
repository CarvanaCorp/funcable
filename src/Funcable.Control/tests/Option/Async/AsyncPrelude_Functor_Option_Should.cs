using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Functor_Option_Should
{
	[Fact]
	public async Task Unwrap_T_In_IOption_Of_T_And_Invoke_Mapping_And_Return_Result_In_IOption_Of_U() =>
		(await Map(AsyncSome(HelloWorld), async s => await ToInt(s).AsTask()))
			.Should<IOption<int>>()
			.Be(Some(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IOption_Of_T_And_Invoke_Mapping_And_Return_Result_In_IOption_Of_U_2() =>
		(await Map(AsyncSome(HelloWorld), ToInt))
			.Should<IOption<int>>()
			.Be(Some(FortyTwo));

	[Fact]
	public async Task Not_Unwrap_T_In_IOption_Of_T_But_Return_An_IOption_Of_U_When_IOption_Of_T_Is_None() =>
		(await Map(AsyncNone<string>(), async s => await ToInt(s).AsTask()))
			.Should()
			.BeOfType<None<int>>();

	[Fact]
	public async Task Not_Unwrap_T_In_IOption_Of_T_But_Return_An_IOption_Of_U_When_IOption_Of_T_Is_None_2() =>
		(await Map(AsyncNone<string>(), ToInt))
			.Should()
			.BeOfType<None<int>>();

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await Map(((IOption<string>)new TestSome<string>()).AsTask(), ToInt))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");
}

using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Monad_Option_Should
{
	[Fact]
	public async Task Unwrap_T_In_IOption_Of_T_And_Invoke_Binder_And_Return_Result_In_IOption_Of_U() =>
		(await Bind(AsyncSome(HelloWorld), s => AsyncSome(ToInt(s))))
			.Should<IOption<int>>()
			.Be(Some(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IOption_Of_T_And_Invoke_Binder_And_Return_Result_In_IOption_Of_U_2() =>
		(await Bind(AsyncSome(HelloWorld), s => Some(ToInt(s))))
			.Should<IOption<int>>()
			.Be(Some(FortyTwo));

	[Fact]
	public async Task Not_Unwrap_T_In_IOption_Of_T_But_Return_An_IOption_Of_U_When_IOption_Of_T_Is_None() =>
		(await Bind(AsyncNone<string>(), s => AsyncSome(ToInt(s))))
			.Should<IOption<int>>()
			.Be(None<int>());

	[Fact]
	public async Task Not_Unwrap_T_In_IOption_Of_T_But_Return_An_IOption_Of_U_When_IOption_Of_T_Is_None_2() =>
		(await Bind(AsyncNone<string>(), s => Some(ToInt(s))))
			.Should<IOption<int>>()
			.Be(None<int>());

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await Bind(((IOption<string>)new TestSome<string>()).AsTask(), s => Some(ToInt(s))))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");
}

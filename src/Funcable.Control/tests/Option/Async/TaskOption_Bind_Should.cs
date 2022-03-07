using Xunit;

namespace Funcable.Control.Tests;

public class TaskOption_Bind_Should
{
	[Fact]
	public async Task Unwrap_T_In_IOption_Of_T_And_Invoke_Binder_And_Return_Result_In_IOption_Of_U() =>
		(await AsyncSome(HelloWorld).Bind(s => AsyncSome(ToInt(s))))
			.Should<IOption<int>>()
			.Be(Some(FortyTwo));

	[Fact]
	public async Task Unwrap_T_In_IOption_Of_T_And_Invoke_Binder_And_Return_Result_In_IOption_Of_U_2() =>
		(await AsyncSome(HelloWorld).Bind(s => Some(ToInt(s))))
			.Should<IOption<int>>()
			.Be(Some(FortyTwo));

	[Fact]
	public async Task Not_Unwrap_T_In_IOption_Of_T_But_Return_An_IOption_Of_U_When_IOption_Of_T_Is_None() =>
		(await AsyncNone<string>().Bind(s => AsyncSome(ToInt(s))))
			.Should<IOption<int>>()
			.Be(None<int>());

	[Fact]
	public async Task Not_Unwrap_T_In_IOption_Of_T_But_Return_An_IOption_Of_U_When_IOption_Of_T_Is_None_2() =>
		(await AsyncNone<string>().Bind(s => Some(ToInt(s))))
			.Should<IOption<int>>()
			.Be(None<int>());

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled() =>
		new Func<Task>(async () => await ((IOption<string>)new TestSome<string>()).AsTask().Bind(s => Some(ToInt(s))))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");
}

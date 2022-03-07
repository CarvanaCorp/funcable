using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Applicative_Option_Should
{
	[Fact]
	public async Task Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IOption_Of_V() =>
		(await Map(AsyncSome(HelloWorld), AsyncSome(FortyTwo), async (t, u) => await ToDouble(t, u).AsTask()))
			.Should<IOption<double>>()
			.Be(Some(Pi));

	[Fact]
	public async Task Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IOption_Of_V_2() =>
		(await Map(AsyncSome(HelloWorld), AsyncSome(FortyTwo), ToDouble))
			.Should<IOption<double>>()
			.Be(Some(Pi));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IOption_Of_V_When_IOption_Of_T_Is_None() =>
		(await Map(AsyncNone<string>(), AsyncSome(FortyTwo), async (t, u) => await ToDouble(t, u).AsTask()))
			.Should<IOption<double>>()
			.Be(None<double>());

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IOption_Of_V_When_IOption_Of_T_Is_None_2() =>
		(await Map(AsyncNone<string>(), AsyncSome(FortyTwo), ToDouble))
			.Should<IOption<double>>()
			.Be(None<double>());

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IOption_Of_V_When_IOption_Of_U_Is_None() =>
		(await Map(AsyncSome(HelloWorld), AsyncNone<int>(), async (t, u) => await ToDouble(t, u).AsTask()))
			.Should<IOption<double>>()
			.Be(None<double>());

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IOption_Of_V_When_IOption_Of_U_Is_None_2() =>
		(await Map(AsyncSome(HelloWorld), AsyncNone<int>(), ToDouble))
			.Should<IOption<double>>()
			.Be(None<double>());

	[Fact]
	public async Task Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IOption_Of_X() =>
		(await Map(
			AsyncSome(HelloWorld),
			AsyncSome(FortyTwo),
			AsyncSome(Pi),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should<IOption<char>>()
			.Be(Some(A));

	[Fact]
	public async Task Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IOption_Of_X_2() =>
		(await Map(AsyncSome(HelloWorld), AsyncSome(FortyTwo), AsyncSome(Pi), ToChar))
			.Should<IOption<char>>()
			.Be(Some(A));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IOption_Of_X_When_IOption_Of_T_Is_None() =>
		(await Map(
			AsyncNone<string>(),
			AsyncSome(FortyTwo),
			AsyncSome(Pi),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should<IOption<char>>()
			.Be(None<char>());

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IOption_Of_X_When_IOption_Of_T_Is_None_2() =>
		(await Map(AsyncNone<string>(), AsyncSome(FortyTwo), AsyncSome(Pi), ToChar))
			.Should<IOption<char>>()
			.Be(None<char>());

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IOption_Of_X_When_IOption_Of_U_Is_None() =>
		(await Map(
			AsyncSome(HelloWorld),
			AsyncNone<int>(),
			AsyncSome(Pi),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should<IOption<char>>()
			.Be(None<char>());

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IOption_Of_X_When_IOption_Of_U_Is_None_2() =>
		(await Map(AsyncSome(HelloWorld), AsyncNone<int>(), AsyncSome(Pi), ToChar))
			.Should<IOption<char>>()
			.Be(None<char>());

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IOption_Of_X_When_IOption_Of_V_Is_None() =>
		(await Map(
			AsyncSome(HelloWorld),
			AsyncSome(FortyTwo),
			AsyncNone<double>(),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should<IOption<char>>()
			.Be(None<char>());

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IOption_Of_X_When_IOption_Of_V_Is_None_2() =>
		(await Map(AsyncSome(HelloWorld), AsyncSome(FortyTwo), AsyncNone<double>(), ToChar))
			.Should<IOption<char>>()
			.Be(None<char>());

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled_1() =>
		new Func<Task>(async () => await Map(
			((IOption<string>)new TestSome<string>()).AsTask(),
			AsyncSome(FortyTwo),
			async (t, u) => await ToDouble(t, u).AsTask()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled_2() =>
		new Func<Task>(async () => await Map(
			((IOption<string>)new TestSome<string>()).AsTask(),
			AsyncSome(FortyTwo),
			ToDouble))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_U_Pattern_Not_Handled_1() =>
		new Func<Task>(async () => await Map(
			AsyncSome(HelloWorld),
			((IOption<int>)new TestSome<int>()).AsTask(),
			ToDouble))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_U_Pattern_Not_Handled_2() =>
		new Func<Task>(async () => await Map(
			AsyncSome(HelloWorld),
			((IOption<int>)new TestSome<int>()).AsTask(),
			async (t, u) => await ToDouble(t, u).AsTask()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled_3() =>
		new Func<Task>(async () => await Map(
			((IOption<string>)new TestSome<string>()).AsTask(),
			AsyncSome(FortyTwo),
			AsyncSome(Pi),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled_4() =>
		new Func<Task>(async () => await Map(
			((IOption<string>)new TestSome<string>()).AsTask(),
			AsyncSome(FortyTwo),
			AsyncSome(Pi),
			ToChar))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_U_Pattern_Not_Handled_5() =>
		new Func<Task>(async () => await Map(
			AsyncSome(HelloWorld),
			AsyncSome(FortyTwo),
			((IOption<double>)new TestSome<double>()).AsTask(),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_U_Pattern_Not_Handled_6() =>
		new Func<Task>(async () => await Map(
			AsyncSome(HelloWorld),
			AsyncSome(FortyTwo),
			((IOption<double>)new TestSome<double>()).AsTask(),
			ToChar))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");
}

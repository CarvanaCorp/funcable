using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Applicative_Result_Should
{
	[Fact]
	public async Task Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_V() =>
		(await Map(AsyncOk<string, int>(HelloWorld), AsyncOk<int, int>(FortyTwo), async (t, u) => await ToDouble(t, u).AsTask()))
			.Should<IResult<double, int>>()
			.Be(Ok<double, int>(Pi));

	[Fact]
	public async Task Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_V_2() =>
		(await Map(AsyncOk<string, int>(HelloWorld), AsyncOk<int, int>(FortyTwo), ToDouble))
			.Should<IResult<double, int>>()
			.Be(Ok<double, int>(Pi));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IResult_Of_V_When_IResult_Of_T_Is_Error() =>
		(await Map(AsyncError<string, int>(NegativeOne), AsyncOk<int, int>(FortyTwo), async (t, u) => await ToDouble(t, u).AsTask()))
			.Should<IResult<double, int>>()
			.Be(Error<double, int>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IResult_Of_V_When_IResult_Of_T_Is_Error_2() =>
		(await Map(AsyncError<string, int>(NegativeOne), AsyncOk<int, int>(FortyTwo), ToDouble))
			.Should<IResult<double, int>>()
			.Be(Error<double, int>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IResult_Of_V_When_IResult_Of_U_Is_Error() =>
		(await Map(AsyncOk<string, int>(HelloWorld), AsyncError<int, int>(NegativeOne), async (t, u) => await ToDouble(t, u).AsTask()))
			.Should<IResult<double, int>>()
			.Be(Error<double, int>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IResult_Of_V_When_IResult_Of_U_Is_Error_2() =>
		(await Map(AsyncOk<string, int>(HelloWorld), AsyncError<int, int>(NegativeOne), ToDouble))
			.Should<IResult<double, int>>()
			.Be(Error<double, int>(NegativeOne));

	[Fact]
	public async Task Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_X() =>
		(await Map(
			AsyncOk<string, int>(HelloWorld),
			AsyncOk<int, int>(FortyTwo),
			AsyncOk<double, int>(Pi),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should<IResult<char, int>>()
			.Be(Ok<char, int>(A));

	[Fact]
	public async Task Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IResult_Of_X_2() =>
		(await Map(AsyncOk<string, int>(HelloWorld), AsyncOk<int, int>(FortyTwo), AsyncOk<double, int>(Pi), ToChar))
			.Should<IResult<char, int>>()
			.Be(Ok<char, int>(A));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IResult_Of_X_When_IResult_Of_T_Is_Error() =>
		(await Map(
			AsyncError<string, int>(NegativeOne),
			AsyncOk<int, int>(FortyTwo),
			AsyncOk<double, int>(Pi),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should<IResult<char, int>>()
			.Be(Error<char, int>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IResult_Of_X_When_IResult_Of_T_Is_Error_2() =>
		(await Map(AsyncError<string, int>(NegativeOne), AsyncOk<int, int>(FortyTwo), AsyncOk<double, int>(Pi), ToChar))
			.Should<IResult<char, int>>()
			.Be(Error<char, int>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IResult_Of_X_When_IResult_Of_U_Is_Error() =>
		(await Map(
			AsyncOk<string, int>(HelloWorld),
			AsyncError<int, int>(NegativeOne),
			AsyncOk<double, int>(Pi),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should<IResult<char, int>>()
			.Be(Error<char, int>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IResult_Of_X_When_IResult_Of_U_Is_Error_2() =>
		(await Map(AsyncOk<string, int>(HelloWorld), AsyncError<int, int>(NegativeOne), AsyncOk<double, int>(Pi), ToChar))
			.Should<IResult<char, int>>()
			.Be(Error<char, int>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IResult_Of_X_When_IResult_Of_V_Is_Error() =>
		(await Map(
			AsyncOk<string, int>(HelloWorld),
			AsyncOk<int, int>(FortyTwo),
			AsyncError<double, int>(NegativeOne),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should<IResult<char, int>>()
			.Be(Error<char, int>(NegativeOne));

	[Fact]
	public async Task Not_Unwrap_Types_But_Return_An_IResult_Of_X_When_IResult_Of_V_Is_Error_2() =>
		(await Map(AsyncOk<string, int>(HelloWorld), AsyncOk<int, int>(FortyTwo), AsyncError<double, int>(NegativeOne), ToChar))
			.Should<IResult<char, int>>()
			.Be(Error<char, int>(NegativeOne));

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled_1() =>
		new Func<Task>(async () => await Map(
			((IResult<string, int>)new TestOk<string, int>()).AsTask(),
			AsyncOk<int, int>(FortyTwo),
			async (t, u) => await ToDouble(t, u).AsTask()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled_2() =>
		new Func<Task>(async () => await Map(
			((IResult<string, int>)new TestOk<string, int>()).AsTask(),
			AsyncOk<int, int>(FortyTwo),
			ToDouble))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_U_Pattern_Not_Handled_1() =>
		new Func<Task>(async () => await Map(
			AsyncOk<string, int>(HelloWorld),
			((IResult<int, int>)new TestOk<int, int>()).AsTask(),
			ToDouble))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_U_Pattern_Not_Handled_2() =>
		new Func<Task>(async () => await Map(
			AsyncOk<string, int>(HelloWorld),
			((IResult<int, int>)new TestOk<int, int>()).AsTask(),
			async (t, u) => await ToDouble(t, u).AsTask()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled_3() =>
		new Func<Task>(async () => await Map(
			((IResult<string, int>)new TestOk<string, int>()).AsTask(),
			AsyncOk<int, int>(FortyTwo),
			AsyncOk<double, int>(Pi),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled_4() =>
		new Func<Task>(async () => await Map(
			((IResult<string, int>)new TestOk<string, int>()).AsTask(),
			AsyncOk<int, int>(FortyTwo),
			AsyncOk<double, int>(Pi),
			ToChar))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_U_Pattern_Not_Handled_5() =>
		new Func<Task>(async () => await Map(
			AsyncOk<string, int>(HelloWorld),
			AsyncOk<int, int>(FortyTwo),
			((IResult<double, int>)new TestOk<double, int>()).AsTask(),
			async (t, u, v) => await ToChar(t, u, v).AsTask()))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_U_Pattern_Not_Handled_6() =>
		new Func<Task>(async () => await Map(
			AsyncOk<string, int>(HelloWorld),
			AsyncOk<int, int>(FortyTwo),
			((IResult<double, int>)new TestOk<double, int>()).AsTask(),
			ToChar))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IResult`2.Match: TestOk`2");
}

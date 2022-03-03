using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Option_Map_Should
{
	[Fact]
	public void Unwrap_T_In_IOption_Of_T_And_Invoke_Mapping_And_Return_Result_In_IOption_Of_U() =>
		Some(HelloWorld)
			.Map(ToInt)
			.Should<IOption<int>>()
			.Be(Some(FortyTwo));

	[Fact]
	public void Not_Unwrap_T_In_IOption_Of_T_But_Return_An_IOption_Of_U_When_IOption_Of_T_Is_None() =>
		None<string>()
			.Map(ToInt)
			.Should()
			.BeOfType<None<int>>();

	[Fact]
	public void Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IOption_Of_V() =>
		Some(HelloWorld)
			.Map(Some(FortyTwo), ToDouble)
			.Should<IOption<double>>()
			.Be(Some(Pi));

	[Fact]
	public void Not_Unwrap_Types_But_Return_An_IOption_Of_V_When_IOption_Of_T_Is_None() =>
		None<string>()
			.Map(Some(FortyTwo), ToDouble)
			.Should()
			.BeOfType<None<double>>();

	[Fact]
	public void Not_Unwrap_Types_But_Return_An_IOption_Of_V_When_IOption_Of_U_Is_None() =>
		Some(HelloWorld)
			.Map(None<int>(), ToDouble)
			.Should()
			.BeOfType<None<double>>();

	[Fact]
	public void Unwrap_Types_And_Invoke_Mapping_And_Return_Result_In_IOption_Of_X() =>
		Some(HelloWorld)
			.Map(Some(FortyTwo), Some(Pi), ToChar)
			.Should<IOption<char>>()
			.Be(Some(A));

	[Fact]
	public void Not_Unwrap_Types_But_Return_An_IOption_Of_X_When_IOption_Of_T_Is_None() =>
		None<string>()
			.Map(Some(FortyTwo), Some(Pi), ToChar)
			.Should()
			.BeOfType<None<char>>();

	[Fact]
	public void Not_Unwrap_Types_But_Return_An_IOption_Of_X_When_IOption_Of_U_Is_None() =>
		Some(HelloWorld)
			.Map(None<int>(), Some(Pi), ToChar)
			.Should()
			.BeOfType<None<char>>();

	[Fact]
	public void Not_Unwrap_Types_But_Return_An_IOption_Of_X_When_IOption_Of_V_Is_None() =>
		Some(HelloWorld)
			.Map(Some(FortyTwo), None<double>(), ToChar)
			.Should()
			.BeOfType<None<char>>();

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled_1() =>
		new Action(() => new TestSome<string>().Map(Some(FortyTwo), ToDouble))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_U_Pattern_Not_Handled_1() =>
		new Action(() => Some(HelloWorld).Map(new TestSome<int>(), ToDouble))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled_2() =>
		new Action(() => new TestSome<string>().Map(Some(FortyTwo), Some(Pi), ToChar))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_U_Pattern_Not_Handled_2() =>
		new Action(() => Some(HelloWorld).Map(Some(FortyTwo), new TestSome<double>(), ToChar))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled() =>
		new Action(() => new TestSome<string>().Map(ToInt))
			.Should()
			.Throw<InvalidPatternException>()
			.WithMessage("IOption`1.Match: TestSome`1");
}

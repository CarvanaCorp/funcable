using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Some_Equals_Should
{
	[Fact]
	public void Return_True_When_Some_T_Equals_Some_T() =>
		((Some<int>)Option.Some(FortyTwo))
			.Equals((Some<int>)Option.Some(FortyTwo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_True_When_IOption_T_Equals_Some_T() =>
		Option.Some(FortyTwo)
			.Equals((Some<int>)Option.Some(FortyTwo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IOption_T_Equals_None_T() =>
		Option.Some(FortyTwo)
			.Equals((None<int>)Option.None<int>())
			.Should()
			.BeFalse();

	[Fact]
	public void Return_False_When_Some_T_Not_Equals_Some_U() =>
		Option.Some(FortyTwo)
			.Equals(Option.Some(HelloWorld))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_False_When_Some_T_Not_Equals_T() =>
		((Some<int>)Option.Some(FortyTwo))
			.Equals(NegativeOne)
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_Some_T_Equals_Some_T_Operator() =>
		((Some<int>)Option.Some(FortyTwo) == (Some<int>)Option.Some(FortyTwo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_Some_T_Not_Equals_Some_T_Operator() =>
		((Some<int>)Option.Some(FortyTwo) != (Some<int>)Option.Some(FortyTwo))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_IOption_T_Equals_Some_T_Operator() =>
		(Option.Some(FortyTwo) == (Some<int>)Option.Some(FortyTwo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IOption_T_Not_Equals_Non_T_Operator() =>
		(Option.Some(FortyTwo) != (Some<int>)Option.Some(FortyTwo))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_Some_T_Equals_IOption_T_Operator() =>
		((Some<int>)Option.Some(FortyTwo) == Option.Some(FortyTwo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_Some_T_Not_Equals_IOption_T_Operator() =>
		((Some<int>)Option.Some(FortyTwo) != Option.Some(FortyTwo))
			.Should()
			.BeFalse();
}

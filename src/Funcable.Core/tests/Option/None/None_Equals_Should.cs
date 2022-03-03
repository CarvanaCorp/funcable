using FluentAssertions;
using Xunit;

namespace Funcable.Core.Tests;

public class None_Equals_Should
{
	[Fact]
	public void Return_True_When_None_T_Equals_None_T() =>
		((None<int>)Option.None<int>())
			.Equals((None<int>)Option.None<int>())
			.Should()
			.BeTrue();

	[Fact]
	public void Return_True_When_IOption_T_Equals_None_T() =>
		Option.None<int>()
			.Equals((None<int>)Option.None<int>())
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IOption_T_Equals_Some_T() =>
		Option.None<int>()
			.Equals((Some<int>)Option.Some(1))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_False_When_None_T_Not_Equals_None_U() =>
		Option.None<int>()
			.Equals(Option.None<string>())
			.Should()
			.BeFalse();

	[Fact]
	public void Return_False_When_None_T_Not_Equals_T() =>
		((None<int>)Option.None<int>())
			.Equals(1)
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_None_T_Equals_None_T_Operator() =>
		((None<int>)Option.None<int>() == (None<int>)Option.None<int>())
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_None_T_Not_Equals_None_T_Operator() =>
		((None<int>)Option.None<int>() != (None<int>)Option.None<int>())
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_IOption_T_Equals_None_T_Operator() =>
		(Option.None<int>() == (None<int>)Option.None<int>())
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IOption_T_Not_Equals_None_T_Operator() =>
		(Option.None<int>() != (None<int>)Option.None<int>())
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_None_T_Equals_IOption_T_Operator() =>
		((None<int>)Option.None<int>() == Option.None<int>())
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_None_T_Not_Equals_IOption_T_Operator() =>
		((None<int>)Option.None<int>() != Option.None<int>())
			.Should()
			.BeFalse();
}

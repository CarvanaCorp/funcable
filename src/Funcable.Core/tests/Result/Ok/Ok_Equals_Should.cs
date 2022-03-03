using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Ok_Equals_Should
{
	[Fact]
	public void Return_True_When_Ok_T_Equals_Ok_T() =>
		((Ok<int, string>)Result.Ok<int, string>(FortyTwo))
			.Equals((Ok<int, string>)Result.Ok<int, string>(FortyTwo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_True_When_IResult_T_Equals_Ok_T() =>
		Result.Ok<int, string>(FortyTwo)
			.Equals((Ok<int, string>)Result.Ok<int, string>(FortyTwo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IResult_T_Equals_Error_T() =>
		Result.Ok<int, string>(FortyTwo)
			.Equals((Error<int, string>)Result.Error<int, string>(HelloWorld))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_False_When_Ok_T_Not_Equals_Ok_U() =>
		Result.Ok<int, string>(FortyTwo)
			.Equals(Result.Ok<string, string>(HelloWorld))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_False_When_Ok_T_Not_Equals_T() =>
		((Ok<int, string>)Result.Ok<int, string>(FortyTwo))
			.Equals(NegativeOne)
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_Ok_T_Equals_Ok_T_Operator() =>
		((Ok<int, string>)Result.Ok<int, string>(FortyTwo) == (Ok<int, string>)Result.Ok<int, string>(FortyTwo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_Ok_T_Not_Equals_Ok_T_Operator() =>
		((Ok<int, string>)Result.Ok<int, string>(FortyTwo) != (Ok<int, string>)Result.Ok<int, string>(FortyTwo))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_IResult_T_Equals_Ok_T_Operator() =>
		(Result.Ok<int, string>(FortyTwo) == (Ok<int, string>)Result.Ok<int, string>(FortyTwo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IResult_T_Not_Equals_Not_T_Operator() =>
		(Result.Ok<int, string>(FortyTwo) != (Ok<int, string>)Result.Ok<int, string>(FortyTwo))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_Ok_T_Equals_IResult_T_Operator() =>
		((Ok<int, string>)Result.Ok<int, string>(FortyTwo) == Result.Ok<int, string>(FortyTwo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_Ok_T_Not_Equals_IResult_T_Operator() =>
		((Ok<int, string>)Result.Ok<int, string>(FortyTwo) != Result.Ok<int, string>(FortyTwo))
			.Should()
			.BeFalse();
}

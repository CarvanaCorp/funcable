using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Error_Equals_Should
{
	[Fact]
	public void Return_True_When_Error_TError_Equals_Error_TError() =>
		((Error<int, string>)Result.Error<int, string>(HelloWorld))
			.Equals((Error<int, string>)Result.Error<int, string>(HelloWorld))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_True_When_IResult_TError_Equals_Error_TError() =>
		Result.Error<int, string>(HelloWorld)
			.Equals((Error<int, string>)Result.Error<int, string>(HelloWorld))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IResult_TError_Equals_Ok_T() =>
		Result.Error<int, string>(HelloWorld)
			.Equals((Ok<int, string>)Result.Ok<int, string>(FortyTwo))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_False_When_Error_TError_Not_Equals_Error_UError() =>
		Result.Error<int, string>(HelloWorld)
			.Equals(Result.Error<string, double>(Pi))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_False_When_Error_TError_Not_Equals_TError() =>
		((Error<int, string>)Result.Error<int, string>(HelloWorld))
			.Equals(HolaMundo)
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_Error_TError_Equals_Error_TError_Operator() =>
		((Error<int, string>)Result.Error<int, string>(HelloWorld) == (Error<int, string>)Result.Error<int, string>(HelloWorld))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_Error_TError_Not_Equals_Error_TError_Operator() =>
		((Error<int, string>)Result.Error<int, string>(HelloWorld) != (Error<int, string>)Result.Error<int, string>(HelloWorld))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_IResult_TError_Equals_Error_TError_Operator() =>
		(Result.Error<int, string>(HelloWorld) == (Error<int, string>)Result.Error<int, string>(HelloWorld))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_IResult_TError_Not_Equals_Not_TError_Operator() =>
		(Result.Error<int, string>(HelloWorld) != (Error<int, string>)Result.Error<int, string>(HelloWorld))
			.Should()
			.BeFalse();

	[Fact]
	public void Return_True_When_Error_TError_Equals_IResult_TError_Operator() =>
		((Error<int, string>)Result.Error<int, string>(HolaMundo) == Result.Error<int, string>(HolaMundo))
			.Should()
			.BeTrue();

	[Fact]
	public void Return_False_When_Error_TError_Not_Equals_IResult_TError_Operator() =>
		((Error<int, string>)Result.Error<int, string>(HolaMundo) != Result.Error<int, string>(HolaMundo))
			.Should()
			.BeFalse();
}

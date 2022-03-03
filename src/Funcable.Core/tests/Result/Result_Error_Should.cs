using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Result_Error_Should
{
	[Fact]
	public void Construct_An_Error_Of_TError() =>
		Result.Error<string, int>(NegativeOne)
			.Should()
			.BeOfType<Error<string, int>>()
			.And
			.Match<Error<string, int>>(error => error.Equals(NegativeOne));

	[Fact]
	public void Throw_ArgumentNullException_When_Value_Passed_Is_Null() =>
		new Action(() => Result.Error<int, string>(null))
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Error: null (Parameter 'error')");
}

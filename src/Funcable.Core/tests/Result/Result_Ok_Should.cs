using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Result_Ok_Should
{
	[Fact]
	public void Construct_An_Ok_Of_T() =>
		Result.Ok<string, int>(HelloWorld)
			.Should()
			.BeOfType<Ok<string, int>>()
			.And
			.Match<Ok<string, int>>(ok => ok.Equals(HelloWorld));

	[Fact]
	public void Throw_ArgumentNullException_When_Value_Passed_Is_Null() =>
		new Action(() => Result.Ok<string, int>(null))
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Ok: null (Parameter 'value')");
}

using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Error_Should
{
	[Fact]
	public void Construct_An_Error_Of_TError() =>
		Error<string, int>(NegativeOne)
			.Should()
			.BeOfType<Error<string, int>>()
			.And
			.Match<Error<string, int>>(error => error.Equals(NegativeOne));

	[Fact]
	public void Construct_An_Error_Of_Error() =>
		Error<int>(HolaMundo, $"{FortyTwo}")
			.Should()
			.BeOfType<Error<int, Error>>()
			.And
			.Match<Error<int, Error>>(error => error.Equals(new Error(HolaMundo, $"{FortyTwo}", null)));

	[Fact]
	public void Throw_ArgumentNullException_When_Value_Passed_Is_Null() =>
		new Action(() => Error<int, string>(null))
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Error: null (Parameter 'error')");
}

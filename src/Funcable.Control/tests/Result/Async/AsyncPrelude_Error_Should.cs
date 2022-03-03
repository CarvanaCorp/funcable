using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Error_Should
{
	[Fact]
	public async Task Construct_An_Error_Of_TError() =>
		(await AsyncError<string, int>(NegativeOne))
			.Should()
			.BeOfType<Error<string, int>>()
			.And
			.Match<Error<string, int>>(error => error.Equals(NegativeOne));

	[Fact]
	public void Throw_ArgumentNullException_When_Value_Passed_Is_Null() =>
		new Func<Task>(async () => await AsyncError<int, string>(null))
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Error: null (Parameter 'error')");
}

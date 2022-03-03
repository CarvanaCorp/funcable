using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Flatten_Result_Should
{
	[Fact]
	public void Extract_Ok_When_T_Is_Ok() =>
		Flatten(
			Ok<IResult<string, int>, int>(Ok<string, int>(HelloWorld))
		)
		.Should<IResult<string, int>>()
		.Be(Ok<string, int>(HelloWorld));

	[Fact]
	public void Return_Error_When_T_Is_Error() =>
		Flatten(
			Ok<IResult<string, int>, int>(Error<string, int>(FortyTwo))
		)
		.Should<IResult<string, int>>()
		.Be(Error<string, int>(FortyTwo));

	[Fact]
	public void Return_Error_When_Is_Error() =>
		Flatten(
			Error<IResult<string, int>, int>(FortyTwo)
		)
		.Should<IResult<string, int>>()
		.Be(Error<string, int>(FortyTwo));
}

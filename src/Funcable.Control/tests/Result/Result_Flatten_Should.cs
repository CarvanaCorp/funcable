using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Result_Flatten_Should
{
	[Fact]
	public void Extract_Ok_When_T_Is_Ok() =>
		Ok<IResult<string, int>, int>(Ok<string, int>(HelloWorld))
			.Flatten()
			.Should<IResult<string, int>>()
			.Be(Ok<string, int>(HelloWorld));

	[Fact]
	public void Return_Error_When_T_Is_Error() =>
		Ok<IResult<string, int>, int>(Error<string, int>(FortyTwo))
			.Flatten()
			.Should<IResult<string, int>>()
			.Be(Error<string, int>(FortyTwo));

	[Fact]
	public void Return_Error_When_Is_Error() =>
		Error<IResult<string, int>, int>(FortyTwo)
			.Flatten()
			.Should<IResult<string, int>>()
			.Be(Error<string, int>(FortyTwo));
}

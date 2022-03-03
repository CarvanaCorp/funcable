using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Option_AsResult_Should
{
	[Fact]
	public void Convert_Option_T_To_Ok_T_When_Option_T_Is_Some_T() =>
		Some(HelloWorld)
			.AsResult()
			.Should<IResult<string, Error>>()
			.Be(Ok<string, Error>(HelloWorld));

	[Fact]
	public void Convert_Option_T_To_Error_Error_When_Option_T_Is_None_T() =>
		None<string>()
			.AsResult()
			.Should<IResult<string, Error>>()
			.BeOfType<Error<string, Error>>();
}

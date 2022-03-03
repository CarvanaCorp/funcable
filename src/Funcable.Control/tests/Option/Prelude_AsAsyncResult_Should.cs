using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_AsAsyncResult_Should
{
	[Fact]
	public async Task Convert_Option_T_To_AsyncOk_T_When_Option_T_Is_Some_T() =>
		(await AsAsyncResult(Some(HelloWorld)))
			.Should()
			.BeOfType<Ok<string, Error>>();

	[Fact]
	public async Task Convert_Option_T_To_AsyncError_Error_When_Option_T_Is_None_T() =>
		(await AsAsyncResult(None<string>()))
			.Should()
			.BeOfType<Error<string, Error>>();
}

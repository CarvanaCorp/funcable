using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_AsOption_Should
{
	[Fact]
	public void Convert_Result_T_To_Some_T_When_Result_T_Is_Ok_T() =>
		AsOption(Ok<string, int>(HelloWorld))
			.Should<IOption<string>>()
			.Be(Some(HelloWorld));

	[Fact]
	public void Convert_Result_TError_To_None_T_When_Result_T_Is_Error_TError() =>
		AsOption(Error<string, int>(FortyTwo))
			.Should<IOption<string>>()
			.BeOfType<None<string>>();
}

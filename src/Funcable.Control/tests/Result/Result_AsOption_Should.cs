using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Result_AsOption_Should
{
	[Fact]
	public void Convert_Result_T_To_Some_T_When_Result_T_Is_Ok_T() =>
		Ok<string, int>(HelloWorld)
			.AsOption()
			.Should<IOption<string>>()
			.Be(Some(HelloWorld));

	[Fact]
	public void Convert_Result_TError_To_None_T_When_Result_T_Is_Error_TError() =>
		Error<string, int>(FortyTwo)
			.AsOption()
			.Should<IOption<string>>()
			.BeOfType<None<string>>();
}

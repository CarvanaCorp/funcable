using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

#pragma warning disable IDE1006 // Disabled for Test Name.
public class T_Ok_Should
{
#pragma warning restore IDE1006 // Disabled for Test Name.
	[Fact]
	public void Wrap_T_In_Ok_Of_T_And_Return_Ok_T_TError() =>
		HelloWorld
			.Ok<string, int>()
			.Should<IResult<string, int>>()
			.Be(Ok<string, int>(HelloWorld));

	[Fact]
	public void Wrap_T_In_Ok_Of_T_And_Return_Ok_T_Error() =>
		HelloWorld
			.Ok()
			.Should<IResult<string, Error>>()
			.Be(Ok<string, Error>(HelloWorld));

	[Fact]
	public void Throw_ArgumentNullException_When_Passed_Null() =>
		new Action(() => { string hello = null; hello.Ok<string, int>(); })
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Ok: null (Parameter 'value')");
}

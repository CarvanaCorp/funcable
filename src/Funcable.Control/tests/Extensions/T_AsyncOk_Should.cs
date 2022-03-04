using Xunit;

namespace Funcable.Control.Tests;

#pragma warning disable IDE1006 // Disabled for Test Name.
public class T_AsyncOk_Should
#pragma warning restore IDE1006 // Disabled for Test Name.
{
	[Fact]
	public async Task Wrap_T_In_Ok_Of_T_And_Return_Ok_T_TError() =>
		(await HelloWorld.AsyncOk<string, int>())
			.Should<IResult<string, int>>()
			.Be(Ok<string, int>(HelloWorld));

	[Fact]
	public async Task Wrap_T_In_Ok_Of_T_And_Return_Ok_T_Error() =>
		(await HelloWorld.AsyncOk())
			.Should<IResult<string, Error>>()
			.Be(Ok<string, Error>(HelloWorld));

	[Fact]
	public void Throw_ArgumentNullException_When_Passed_Null() =>
		new Action(() => { string hello = null; hello.AsyncOk<string, int>(); })
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Ok: null (Parameter 'value')");
}

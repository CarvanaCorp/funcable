using Xunit;

namespace Funcable.Control.Tests;

#pragma warning disable IDE1006 // Disabled for Test Name.
public class T_AsyncError_Should
#pragma warning restore IDE1006 // Disabled for Test Name.
{
	[Fact]
	public async Task Wrap_Error_In_Error_Of_Error_And_Return_Error_Error() =>
		(await new Error(HolaMundo, FortyTwo.ToString()).AsyncError<string>())
			.Should<IResult<string, Error>>()
			.Be(Error<string, Error>(new Error(HolaMundo, FortyTwo.ToString())));

	[Fact]
	public async Task Wrap_TError_In_Error_Of_TError_And_Return_Error_TError() =>
		(await FortyTwo.AsyncError<string, int>())
			.Should<IResult<string, int>>()
			.Be(Error<string, int>(FortyTwo));

	[Fact]
	public void Throw_ArgumentNullException_When_Passed_Null() =>
		new Action(() => { string hello = null; hello.AsyncError<int, string>(); })
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Error: null (Parameter 'error')");
}

using Xunit;

namespace Funcable.Control.Tests;

#pragma warning disable IDE1006 // Disabled for Test Name.
public class T_Error_Should
{
#pragma warning restore IDE1006 // Disabled for Test Name.
	[Fact]
	public void Wrap_Error_In_Error_Of_Error_And_Return_Error_Error() =>
		new Error(HolaMundo, FortyTwo.ToString())
			.Error<string>()
			.Should<IResult<string, Error>>()
			.Be(Error<string, Error>(new Error(HolaMundo, FortyTwo.ToString())));

	[Fact]
	public void Wrap_TError_In_Error_Of_TError_And_Return_Error_TError() =>
		FortyTwo
			.Error<string, int>()
			.Should<IResult<string, int>>()
			.Be(Error<string, int>(FortyTwo));

	[Fact]
	public void Throw_ArgumentNullException_When_Passed_Null() =>
		new Action(() => { string hello = null; hello.Error<int, string>(); })
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Error: null (Parameter 'error')");
}

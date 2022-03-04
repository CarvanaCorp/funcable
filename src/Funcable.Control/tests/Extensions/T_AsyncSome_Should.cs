using Xunit;

namespace Funcable.Control.Tests;

#pragma warning disable IDE1006 // Disabled for Test Name.
public class T_AsyncSome_Should
#pragma warning restore IDE1006 // Disabled for Test Name.
{
	[Fact]
	public async Task Wrap_T_In_Task_Of_Some_Of_T_And_Return_Task_Of_Some_T() =>
		(await HelloWorld.AsyncSome())
			.Should<IOption<string>>()
			.Be(Some(HelloWorld));

	[Fact]
	public void Throw_ArgumentNullException_When_Passed_Null() =>
		new Action(() => { const string Hello = null; Hello.AsyncSome(); })
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Some: null (Parameter 'value')");
}

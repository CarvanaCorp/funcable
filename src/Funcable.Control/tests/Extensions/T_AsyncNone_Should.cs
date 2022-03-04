using Xunit;

namespace Funcable.Control.Tests;

#pragma warning disable IDE1006 // Disabled for Test Name.
public class T_AsyncNone_Should
#pragma warning restore IDE1006 // Disabled for Test Name.
{
	[Fact]
	public async Task Return_Task_If_None_Of_T() =>
		(await HelloWorld.AsyncNone())
			.Should<IOption<string>>()
			.Be(None<string>());

	[Fact]
	public async Task Return_None_Of_T_When_Null() =>
		(await new Func<Task<IOption<string>>>(() => { string hello = null; return hello.AsyncNone(); })())
			.Should<IOption<string>>()
			.Be(None<string>());
}

using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

#pragma warning disable IDE1006 // Disabled for Test Name.
public class T_Some_Should
{
#pragma warning restore IDE1006 // Disabled for Test Name.
	[Fact]
	public void Wrap_T_In_Some_Of_T_And_Return_Some_T() =>
		HelloWorld
			.Some()
			.Should<IOption<string>>()
			.Be(Some(HelloWorld));

	[Fact]
	public void Throw_ArgumentNullException_When_Passed_Null() =>
		new Action(() => { const string Hello = null; Hello.Some(); })
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Some: null (Parameter 'value')");
}

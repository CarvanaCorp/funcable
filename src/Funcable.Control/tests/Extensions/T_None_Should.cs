using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

#pragma warning disable IDE1006 // Disabled for Test Name.
public class T_None_Should
{
#pragma warning restore IDE1006 // Disabled for Test Name.
	[Fact]
	public void Return_None_Of_T() =>
		HelloWorld
			.None()
			.Should<IOption<string>>()
			.Be(None<string>());

	[Fact]
	public void Return_None_Of_T_When_Null() =>
		new Func<IOption<string>>(() => { string hello = null; return hello.None(); })()
			.Should<IOption<string>>()
			.Be(None<string>());
}

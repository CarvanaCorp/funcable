using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Some_Implicit_Cast_Should
{
	[Fact]
	public void Return_Wrapped_T() =>
		new Func<Some<string>>(() => HelloWorld)()
			.Should()
			.BeOfType<Some<string>>();

	[Fact]
	public void Throw_ArgumentNullException_When_Wrapped_Passed_Null() =>
		new Action(() => { Some<string> some = null; })
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Some: null (Parameter 'value')");
}

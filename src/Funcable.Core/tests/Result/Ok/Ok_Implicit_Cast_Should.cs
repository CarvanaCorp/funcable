using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Ok_Implicit_Cast_Should
{
	[Fact]
	public void Return_Wrapped_T() =>
		new Func<Ok<string, int>>(() => HelloWorld)()
			.Should()
			.BeOfType<Ok<string, int>>();

	[Fact]
	public void Throw_ArgumentNullException_When_Wrapped_Passed_Null() =>
		new Action(() => { Ok<string, int> ok = null; })
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Ok: null (Parameter 'value')");
}

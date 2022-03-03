using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Error_Implicit_Cast_Should
{
	[Fact]
	public void Return_Wrapped_T() =>
		new Func<Error<int, string>>(() => HelloWorld)()
			.Should()
			.BeOfType<Error<int, string>>();

	[Fact]
	public void Throw_ArgumentNullException_When_Wrapped_Passed_Null() =>
		new Action(() => { Error<int, string> ok = null; })
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Error: null (Parameter 'error')");
}

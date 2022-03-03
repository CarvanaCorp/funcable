using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Ok_Should
{
	[Fact]
	public void Construct_An_Ok_Of_T() =>
		Ok<string, int>(HelloWorld)
			.Should()
			.BeOfType<Ok<string, int>>()
			.And
			.Match<Ok<string, int>>(ok => ok.Equals(HelloWorld));

	[Fact]
	public void Throw_ArgumentNullException_When_Value_Passed_Is_Null() =>
		new Action(() => Ok<string, int>(null))
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Ok: null (Parameter 'value')");
}

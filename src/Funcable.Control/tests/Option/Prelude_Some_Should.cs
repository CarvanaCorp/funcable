using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Some_Should
{
	[Fact]
	public void Construct_A_Some_Of_T() =>
		Some(HelloWorld)
			.Should()
			.BeOfType<Some<string>>()
			.And
			.Match<Some<string>>(some => some.Equals(HelloWorld));

	[Fact]
	public void Throw_ArgumentNullException_When_Value_Passed_Is_Null() =>
		new Action(() => Some<string>(null))
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Some: null (Parameter 'value')");
}

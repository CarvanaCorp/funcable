using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Option_Some_Should
{
	[Fact]
	public void Construct_A_Some_Of_T() =>
		Option.Some(HelloWorld)
			.Should()
			.BeOfType<Some<string>>()
			.And
			.Match<Some<string>>(some => some.Equals(HelloWorld));

	[Fact]
	public void Throw_ArgumentNullException_When_Value_Passed_Is_Null() =>
		new Action(() => Option.Some<string>(null))
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Some: null (Parameter 'value')");
}

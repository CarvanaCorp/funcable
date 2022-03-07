using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Some_Should
{
	[Fact]
	public async Task Construct_A_Some_Of_T() =>
		(await AsyncSome(HelloWorld))
			.Should()
			.BeOfType<Some<string>>()
			.And
			.Match<Some<string>>(some => some.Equals(HelloWorld));

	[Fact]
	public void Throw_ArgumentNullException_When_Value_Passed_Is_Null() =>
		new Func<Task>(async () => await AsyncSome<string>(null))
			.Should()
			.Throw<ArgumentNullException>()
			.WithMessage("Some: null (Parameter 'value')");
}

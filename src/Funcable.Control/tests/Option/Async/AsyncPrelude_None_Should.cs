using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_None_Should
{
	[Fact]
	public async Task Construct_A_None_Of_T() =>
		(await AsyncNone<string>())
			.Should()
			.BeOfType<None<string>>();
}

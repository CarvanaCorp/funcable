using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Try_Should
{
	[Fact]
	public void Return_Result_Ok_When_Success() =>
		Try(() => HelloWorld).Should().Match<IResult<string, Error>>(
			r => FromOk(r).Equals(HelloWorld)
		);

	[Fact]
	public void Return_Result_Error_When_Failure() =>
		Try(() => true ? throw new InvalidOperationException("Ouch") : HelloWorld)
			.Should()
			.Match<IResult<string, Error>>(
				r => FromError(r).Message.Equals("Ouch")
			);
}

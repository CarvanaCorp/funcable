using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Prelude_Partition_Result_Should
{
	[Fact]
	public void Partition_Oks_And_Errors_And_Return_Tuple() =>
		Partition(
			new IResult<string, int>[]
			{
					Ok<string, int>(HelloWorld),
					Error<string, int>(FortyTwo),
					Error<string, int>(FortyTwo),
					Error<string, int>(FortyTwo),
					Ok<string, int>(HelloWorld),
					Error<string, int>(FortyTwo)
			}
		)
		.Should()
		.Match<(IEnumerable<string> Oks, IEnumerable<int> Errors)>(partitions => partitions.Oks.Count() == 2 && partitions.Errors.Count() == 4);
}

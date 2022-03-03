using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class Results_Partition_Should
{
	[Fact]
	public void Partition_Oks_And_Errors_And_Return_Tuple() =>
		new IResult<string, int>[]
		{
				Ok<string, int>(HelloWorld),
				Ok<string, int>(HelloWorld)
		}
		.Partition()
		.Should()
		.Match<(IEnumerable<string> Oks, IEnumerable<int> Errors)>(partitions => partitions.Oks.Count() == 2 && !partitions.Errors.Any());
}

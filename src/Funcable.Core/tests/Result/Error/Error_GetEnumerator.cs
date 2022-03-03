using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Error_GetEnumerator_Should
{
	[Fact]
	public void Return_An_Enumerator() =>
		new Action(() => { var r = ((IEnumerable<int>)Result.Error<int, string>(HelloWorld)).First(); })
			.Should()
			.Throw<InvalidOperationException>()
			.WithMessage("Sequence contains no elements");
}

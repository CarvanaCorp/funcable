using FluentAssertions;
using Xunit;

namespace Funcable.Core.Tests;

public class None_GetEnumerator_Should
{
	[Fact]
	public void Never_Return_An_Enumerator() =>
		new Action(() => ((None<string>)Option.None<string>()).First())
			.Should()
			.Throw<InvalidOperationException>()
			.WithMessage("Sequence contains no elements");
}

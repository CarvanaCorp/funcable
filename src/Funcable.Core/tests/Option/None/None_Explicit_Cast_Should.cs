using FluentAssertions;
using Xunit;

namespace Funcable.Core.Tests;

public class None_Explicit_Cast_Should
{
	[Fact]
	public void Throw_InvalidCastException() =>
		new Action(() => { var t = (string)(None<string>)Option.None<string>(); })
			.Should()
			.Throw<InvalidCastException>()
			.WithMessage("IOption`1: None");
}

using Xunit;

namespace Funcable.Control.Tests;

#pragma warning disable IDE1006 // Disabled for Test Name.
public class T_AsTask_Should
{
#pragma warning restore IDE1006 // Disabled for Test Name.
	[Fact]
	public void Wrap_T_In_Task_Of_T_And_Return_Task_Of_T() =>
		HelloWorld
			.AsTask()
			.Should()
			.BeOfType<Task<string>>();
}

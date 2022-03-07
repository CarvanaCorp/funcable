using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_OnOk_Should
{
	[Fact]
	public async Task Invoke_Handler_And_Return_Self_When_Ok() =>
		await OnOk(
			AsyncOk<string, int>(HelloWorld),
			t => t.Should().Be(HelloWorld)
		);

	[Fact]
	public async Task Invoke_Handler_And_Return_Self_When_Ok_2() =>
		await OnOk(
			AsyncOk<string, int>(HelloWorld),
			async t => (await t.AsTask()).Should().Be(HelloWorld)
		);

	[Fact]
	public async Task Not_Invoke_Handler_And_Return_Self_When_Error()
	{
		var greeting = string.Empty;
		await OnOk(
			AsyncError<string, int>(FortyTwo),
			_ => greeting = HelloWorld
		);
		greeting.Should().Be(string.Empty);
	}

	[Fact]
	public async Task Not_Invoke_Handler_And_Return_Self_When_Error_2()
	{
		var greeting = string.Empty;
		await OnOk(
			AsyncError<string, int>(FortyTwo),
			async _ => greeting = await HelloWorld.AsTask()
		);
		greeting.Should().Be(string.Empty);
	}
}

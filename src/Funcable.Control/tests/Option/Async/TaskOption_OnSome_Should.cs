using Xunit;

namespace Funcable.Control.Tests;

public class TaskOption_OnSome_Should
{
[Fact]
	public async Task Invoke_Handler_And_Return_Self_When_Some() =>
		await AsyncSome(HelloWorld).OnSome(
			t => t.Should().Be(HelloWorld)
		);

	[Fact]
	public async Task Invoke_Handler_And_Return_Self_When_Some_2() =>
		await AsyncSome(HelloWorld).OnSome(
			async t => (await t.AsTask()).Should().Be(HelloWorld)
		);

	[Fact]
	public async Task Not_Invoke_Handler_And_Return_Self_When_None()
	{
		var greeting = string.Empty;
		await AsyncNone<string>().OnSome(
			_ => greeting = HelloWorld
		);
		greeting.Should().Be(string.Empty);
	}

	[Fact]
	public async Task Not_Invoke_Handler_And_Return_Self_When_None_2()
	{
		var greeting = string.Empty;
		await AsyncNone<string>().OnSome(
			async _ => greeting = await HelloWorld.AsTask()
		);
		greeting.Should().Be(string.Empty);
	}
}

using Xunit;

namespace Funcable.Control.Tests;

public class TaskOption_OnNone_Should
{
[Fact]
	public async Task Invoke_Handler_And_Return_Self_When_None()
	{
		var greeting = string.Empty;
		await AsyncNone<string>().OnNone(
			() => greeting = FortyTwo.ToString()
		);
		greeting.Should().Be(FortyTwo.ToString());
	}

	[Fact]
	public async Task Invoke_Handler_And_Return_Self_When_None_2()
	{
		var greeting = string.Empty;
		await AsyncNone<string>().OnNone(
			async () => greeting = await FortyTwo.ToString().AsTask()
		);
		greeting.Should().Be(FortyTwo.ToString());
	}

	[Fact]
	public async Task Not_Invoke_Handler_And_Return_Self_When_Some()
	{
		var greeting = string.Empty;
		await AsyncSome(HolaMundo).OnNone(
			() => greeting = FortyTwo.ToString()
		);
		greeting.Should().Be(string.Empty);
	}

	[Fact]
	public async Task Not_Invoke_Handler_And_Return_Self_When_Some_2()
	{
		var greeting = string.Empty;
		await AsyncSome(HolaMundo).OnNone(
			async () => greeting = await FortyTwo.ToString().AsTask()
		);
		greeting.Should().Be(string.Empty);
	}
}

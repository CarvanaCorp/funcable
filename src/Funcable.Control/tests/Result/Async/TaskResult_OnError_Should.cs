using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class TaskResult_OnError_Should
{
	[Fact]
	public async Task Invoke_Handler_And_Return_Self_When_Error()
	{
		var greeting = string.Empty;
		await AsyncError<string, int>(FortyTwo).OnError(
			error => greeting = error.ToString()
		);
		greeting.Should().Be(FortyTwo.ToString());
	}

	[Fact]
	public async Task Invoke_Handler_And_Return_Self_When_Error_2()
	{
		var greeting = string.Empty;
		await AsyncError<string, int>(FortyTwo).OnError(
			async error => greeting = await error.ToString().AsTask()
		);
		greeting.Should().Be(FortyTwo.ToString());
	}

	[Fact]
	public async Task Not_Invoke_Handler_And_Return_Self_When_Ok()
	{
		var greeting = string.Empty;
		await AsyncOk<string, int>(HolaMundo).OnError(
			error => greeting = error.ToString()
		);
		greeting.Should().Be(string.Empty);
	}

	[Fact]
	public async Task Not_Invoke_Handler_And_Return_Self_When_Ok_2()
	{
		var greeting = string.Empty;
		await AsyncOk<string, int>(HolaMundo).OnError(
			async error => greeting = await error.ToString().AsTask()
		);
		greeting.Should().Be(string.Empty);
	}
}

using FluentAssertions;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class TaskResult_OnOk_Should
{
	[Fact]
	public async Task Invoke_Handler_And_Return_Self_When_Ok() =>
		await AsyncOk<string, int>(HelloWorld).OnOk(
			t => t.Should().Be(HelloWorld)
		);

	[Fact]
	public async Task Invoke_Handler_And_Return_Self_When_Ok_2() =>
		await AsyncOk<string, int>(HelloWorld).OnOk(
			async t => (await t.AsTask()).Should().Be(HelloWorld)
		);

	[Fact]
	public async Task Not_Invoke_Handler_And_Return_Self_When_Error()
	{
		var greeting = string.Empty;
		await AsyncError<string, int>(FortyTwo).OnOk(
			_ => greeting = HelloWorld
		);
		greeting.Should().Be(string.Empty);
	}

	[Fact]
	public async Task Not_Invoke_Handler_And_Return_Self_When_Error_2()
	{
		var greeting = string.Empty;
		await AsyncError<string, int>(FortyTwo).OnOk(
			async _ => greeting = await HelloWorld.AsTask()
		);
		greeting.Should().Be(string.Empty);
	}
}

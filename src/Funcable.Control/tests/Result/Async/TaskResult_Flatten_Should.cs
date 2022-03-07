using Xunit;

namespace Funcable.Control.Tests;

public class TaskResult_Flatten_Should
{
	[Fact]
	public async Task Extract_AsyncOk_When_T_Is_AsyncOk() =>
		(await AsyncOk<Task<IResult<string, int>>, int>(AsyncOk<string, int>(HelloWorld))
			.Flatten()
			.Match(s => s, i => i.ToString()))
			.Should()
			.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Extract_AsyncOk_When_T_Is_AsyncOk_2() =>
		(await Ok<Task<IResult<string, int>>, int>(AsyncOk<string, int>(HelloWorld))
			.Flatten()
			.Match(s => s, i => i.ToString()))
			.Should()
			.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Extract_AsyncOk_When_T_Is_Ok() =>
		(await AsyncOk<IResult<string, int>, int>(Ok<string, int>(HelloWorld))
			.Flatten()
			.Match(s => s, i => i.ToString()))
			.Should()
			.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Return_AsyncError_When_T_Is_AsyncError() =>
		(await AsyncOk<Task<IResult<string, int>>, int>(AsyncError<string, int>(FortyTwo))
			.Flatten()
			.Match(s => s, i => i.ToString()))
			.Should()
			.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_AsyncError_When_T_Is_AsyncError_2() =>
		(await Ok<Task<IResult<string, int>>, int>(AsyncError<string, int>(FortyTwo))
			.Flatten()
			.Match(s => s, i => i.ToString()))
			.Should()
			.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_AsyncError_When_T_Is_Error() =>
		(await AsyncOk<IResult<string, int>, int>(Error<string, int>(FortyTwo))
			.Flatten()
			.Match(s => s, i => i.ToString()))
			.Should()
			.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_Error_When_Is_AsyncError() =>
		(await AsyncError<Task<IResult<string, int>>, int>(FortyTwo)
			.Flatten())
			.Match(s => s, i => i.ToString())
			.Should()
			.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_Error_When_Is_AsyncError_2() =>
		(await Error<Task<IResult<string, int>>, int>(FortyTwo)
			.Flatten())
			.Match(s => s, i => i.ToString())
			.Should()
			.Match<string>(s => s.Equals(FortyTwo.ToString()));
}

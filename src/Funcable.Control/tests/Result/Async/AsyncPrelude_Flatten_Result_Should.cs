using FluentAssertions;
using Funcable.Core;
using Xunit;

using static Funcable.Control.Prelude;
using static Funcable.Control.Tests.FuncableTestFixture;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Flatten_Result_Should
{
	[Fact]
	public async Task Extract_AsyncOk_When_T_Is_AsyncOk() =>
		(await Flatten(
			AsyncOk<Task<IResult<string, int>>, int>(AsyncOk<string, int>(HelloWorld))
		)
		.Match(s => s, i => i.ToString()))
		.Should()
		.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Extract_AsyncOk_When_T_Is_AsyncOk_2() =>
		(await Flatten(
			Ok<Task<IResult<string, int>>, int>(AsyncOk<string, int>(HelloWorld))
		)
		.Match(s => s, i => i.ToString()))
		.Should()
		.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Extract_AsyncOk_When_T_Is_Ok() =>
		(await Flatten(
			AsyncOk<IResult<string, int>, int>(Ok<string, int>(HelloWorld))
		)
		.Match(s => s, i => i.ToString()))
		.Should()
		.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Return_AsyncError_When_T_Is_AsyncError() =>
		(await Flatten(
			AsyncOk<Task<IResult<string, int>>, int>(AsyncError<string, int>(FortyTwo))
		)
		.Match(s => s, i => i.ToString()))
		.Should()
		.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_AsyncError_When_T_Is_AsyncError_2() =>
		(await Flatten(
			Ok<Task<IResult<string, int>>, int>(AsyncError<string, int>(FortyTwo))
		)
		.Match(s => s, i => i.ToString()))
		.Should()
		.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_AsyncError_When_T_Is_Error() =>
		(await Flatten(
			AsyncOk<IResult<string, int>, int>(Error<string, int>(FortyTwo))
		)
		.Match(s => s, i => i.ToString()))
		.Should()
		.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_Error_When_Is_AsyncError() =>
		(await Flatten(
			AsyncError<Task<IResult<string, int>>, int>(FortyTwo)
		)
		.Match(s => s, i => i.ToString()))
		.Should()
		.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_Error_When_Is_AsyncError_2() =>
		(await Flatten(
			Error<Task<IResult<string, int>>, int>(FortyTwo)
		)
		.Match(s => s, i => i.ToString()))
		.Should()
		.Match<string>(s => s.Equals(FortyTwo.ToString()));
}

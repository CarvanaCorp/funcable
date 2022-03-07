using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Flatten_Option_Should
{
	[Fact]
	public async Task Extract_AsyncSome_When_T_Is_AsyncSome() =>
		(await Flatten(
			AsyncSome(AsyncSome(HelloWorld))
		)
		.Match(s => s, () => FortyTwo.ToString()))
		.Should()
		.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Extract_AsyncSome_When_T_Is_AsyncSome_2() =>
		(await Flatten(
			Some(AsyncSome(HelloWorld))
		)
		.Match(s => s, () => FortyTwo.ToString()))
		.Should()
		.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Extract_AsyncSome_When_T_Is_Some() =>
		(await Flatten(
			AsyncSome(Some(HelloWorld))
		)
		.Match(s => s, () => FortyTwo.ToString()))
		.Should()
		.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Return_AsyncNone_When_T_Is_AsyncNone() =>
		(await Flatten(
			AsyncSome(AsyncNone<string>())
		)
		.Match(s => s, () => FortyTwo.ToString()))
		.Should()
		.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_AsyncNone_When_T_Is_AsyncNone_2() =>
		(await Flatten(
			Some(AsyncNone<string>())
		)
		.Match(s => s, () => FortyTwo.ToString()))
		.Should()
		.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_AsyncNone_When_T_Is_None() =>
		(await Flatten(
			AsyncSome(None<string>())
		)
		.Match(s => s, () => FortyTwo.ToString()))
		.Should()
		.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_None_When_Is_AsyncNone() =>
		(await Flatten(
			AsyncNone<Task<IOption<string>>>()
		)
		.Match(s => s, () => FortyTwo.ToString()))
		.Should()
		.Match<string>(s => s.Equals(FortyTwo.ToString()));

	[Fact]
	public async Task Return_None_When_Is_AsyncNone_2() =>
		(await Flatten(
			None<Task<IOption<string>>>()
		)
		.Match(s => s, () => FortyTwo.ToString()))
		.Should()
		.Match<string>(s => s.Equals(FortyTwo.ToString()));
}

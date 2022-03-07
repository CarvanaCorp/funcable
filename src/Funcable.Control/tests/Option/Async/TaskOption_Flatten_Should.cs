using Xunit;

namespace Funcable.Control.Tests;

public class TaskOption_Flatten_Should
{
	[Fact]
	public async Task Extract_AsyncSome_When_T_Is_AsyncSome() =>
		(await AsyncSome(AsyncSome(HelloWorld))
			.Flatten()
			.Match(s => s, () => HolaMundo))
			.Should()
			.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Extract_AsyncSome_When_T_Is_AsyncSome_2() =>
		(await Some(AsyncSome(HelloWorld))
			.Flatten()
			.Match(s => s, () => HolaMundo))
			.Should()
			.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Extract_AsyncSome_When_T_Is_Some() =>
		(await AsyncSome(Some(HelloWorld))
			.Flatten()
			.Match(s => s, () => HolaMundo))
			.Should()
			.Match<string>(s => s.Equals(HelloWorld));

	[Fact]
	public async Task Return_AsyncNone_When_T_Is_AsyncNone() =>
		(await AsyncSome(AsyncNone<string>())
			.Flatten()
			.Match(s => s, () => HolaMundo))
			.Should()
			.Match<string>(s => s.Equals(HolaMundo));

	[Fact]
	public async Task Return_AsyncNone_When_T_Is_AsyncNone_2() =>
		(await Some(AsyncNone<string>())
			.Flatten()
			.Match(s => s, () => HolaMundo))
			.Should()
			.Match<string>(s => s.Equals(HolaMundo));

	[Fact]
	public async Task Return_AsyncNone_When_T_Is_None() =>
		(await AsyncSome(None<string>())
			.Flatten()
			.Match(s => s, () => HolaMundo))
			.Should()
			.Match<string>(s => s.Equals(HolaMundo));

	[Fact]
	public async Task Return_None_When_Is_AsyncNone() =>
		(await AsyncNone<Task<IOption<string>>>()
			.Flatten())
			.Match(s => s, () => HolaMundo)
			.Should()
			.Match<string>(s => s.Equals(HolaMundo));

	[Fact]
	public async Task Return_None_When_Is_AsyncNone_2() =>
		(await None<Task<IOption<string>>>()
			.Flatten())
			.Match(s => s, () => HolaMundo)
			.Should()
			.Match<string>(s => s.Equals(HolaMundo));
}

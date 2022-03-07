using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Match_Option_Should
{
	[Fact]
	public async Task Invoke_AsyncSomeMatch_And_Return_U_When_IOption_Of_T_Is_Some_Of_T() =>
		(await Match(
			AsyncSome(FortyTwo),
			async a => await HelloWorld.AsTask(),
			async () => await HolaMundo.AsTask()
		))
		.Should()
		.Be(HelloWorld);

	[Fact]
	public async Task Invoke_AsyncSomeMatch_And_Return_U_When_IOption_Of_T_Is_Some_Of_T_2() =>
		(await Match(
			AsyncSome(FortyTwo),
			async a => await HelloWorld.AsTask(),
			() => HolaMundo
		))
		.Should()
		.Be(HelloWorld);

	[Fact]
	public async Task Invoke_AsyncSomeMatch_And_Return_U_When_IOption_Of_T_Is_Some_Of_T_3() =>
		(await Match(
			AsyncSome(FortyTwo),
			a => HelloWorld,
			async () => await HolaMundo.AsTask()
		))
		.Should()
		.Be(HelloWorld);

	[Fact]
	public async Task Invoke_AsyncSomeMatch_And_Return_U_When_IOption_Of_T_Is_Some_Of_T_4() =>
		(await Match(
			AsyncSome(FortyTwo),
			a => HelloWorld,
			() => HolaMundo
		))
		.Should()
		.Be(HelloWorld);

	[Fact]
	public async Task Invoke_AsyncNoneMatch_And_Return_U_When_IOption_Of_T_Is_None_Of_T() =>
		(await Match(
			AsyncNone<string>(),
			async a => await HelloWorld.AsTask(),
			async () => await HolaMundo.AsTask()
		))
		.Should()
		.Be(HolaMundo);

	[Fact]
	public async Task Invoke_AsyncNoneMatch_And_Return_U_When_IOption_Of_T_Is_None_Of_T_2() =>
		(await Match(
			AsyncNone<string>(),
			async a => await HelloWorld.AsTask(),
			() => HolaMundo
		))
		.Should()
		.Be(HolaMundo);

	[Fact]
	public async Task Invoke_AsyncNoneMatch_And_Return_U_When_IOption_Of_T_Is_None_Of_T_3() =>
		(await Match(
			AsyncNone<string>(),
			a => HelloWorld,
			async () => await HolaMundo.AsTask()
		))
		.Should()
		.Be(HolaMundo);

	[Fact]
	public async Task Invoke_AsyncNoneMatch_And_Return_U_When_IOption_Of_T_Is_None_Of_T_4() =>
		(await Match(
			AsyncNone<string>(),
			a => HelloWorld,
			() => HolaMundo
		))
		.Should()
		.Be(HolaMundo);

	[Fact]
	public void Throw_PatternNotHandledException_When_IOption_T_Pattern_Not_Handled() =>
		new Func<Task>(
			async () => await Match(((IOption<string>)new TestSome<string>()).AsTask(), a => HelloWorld, () => HolaMundo)
		)
		.Should()
		.Throw<InvalidPatternException>()
		.WithMessage("IOption`1.Match: TestSome`1");
}

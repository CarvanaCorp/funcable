using Xunit;

namespace Funcable.Control.Tests;

public class AsyncPrelude_Match_Result_Should
{
	[Fact]
	public async Task Invoke_AsyncOkMatch_And_Return_U_When_IResult_Of_T_Is_Ok_Of_T() =>
		(await Match(
			AsyncOk<int, int>(FortyTwo),
			async a => await HelloWorld.AsTask(),
			async e => await HolaMundo.AsTask()
		))
		.Should()
		.Be(HelloWorld);

	[Fact]
	public async Task Invoke_AsyncOkMatch_And_Return_U_When_IResult_Of_T_Is_Ok_Of_T_2() =>
		(await Match(
			AsyncOk<int, int>(FortyTwo),
			async a => await HelloWorld.AsTask(),
			e => HolaMundo
		))
		.Should()
		.Be(HelloWorld);

	[Fact]
	public async Task Invoke_AsyncOkMatch_And_Return_U_When_IResult_Of_T_Is_Ok_Of_T_3() =>
		(await Match(
			AsyncOk<int, int>(FortyTwo),
			a => HelloWorld,
			async e => await HolaMundo.AsTask()
		))
		.Should()
		.Be(HelloWorld);

	[Fact]
	public async Task Invoke_AsyncOkMatch_And_Return_U_When_IResult_Of_T_Is_Ok_Of_T_4() =>
		(await Match(
			AsyncOk<int, int>(FortyTwo),
			a => HelloWorld,
			e => HolaMundo
		))
		.Should()
		.Be(HelloWorld);

	[Fact]
	public async Task Invoke_AsyncErrorMatch_And_Return_U_When_Result_Of_T_Is_Error_Of_T() =>
		(await Match(
			AsyncError<string, int>(FortyTwo),
			async a => await HelloWorld.AsTask(),
			async e => await HolaMundo.AsTask()
		))
		.Should()
		.Be(HolaMundo);

	[Fact]
	public async Task Invoke_AsyncErrorMatch_And_Return_U_When_Result_Of_T_Is_Error_Of_T_2() =>
		(await Match(
			AsyncError<string, int>(FortyTwo),
			async a => await HelloWorld.AsTask(),
			e => HolaMundo
		))
		.Should()
		.Be(HolaMundo);

	[Fact]
	public async Task Invoke_AsyncErrorMatch_And_Return_U_When_Result_Of_T_Is_Error_Of_T_3() =>
		(await Match(
			AsyncError<string, int>(FortyTwo),
			a => HelloWorld,
			async e => await HolaMundo.AsTask()
		))
		.Should()
		.Be(HolaMundo);

	[Fact]
	public async Task Invoke_AsyncErrorMatch_And_Return_U_When_Result_Of_T_Is_Error_Of_T_4() =>
		(await Match(
			AsyncError<string, int>(FortyTwo),
			a => HelloWorld,
			e => HolaMundo
		))
		.Should()
		.Be(HolaMundo);

	[Fact]
	public void Throw_PatternNotHandledException_When_IResult_T_Pattern_Not_Handled() =>
		new Func<Task>(
			async () => await Match(((IResult<string, int>)new TestOk<string, int>()).AsTask(), a => HelloWorld, e => HolaMundo)
		)
		.Should()
		.Throw<InvalidPatternException>()
		.WithMessage("IResult`2.Match: TestOk`2");
}

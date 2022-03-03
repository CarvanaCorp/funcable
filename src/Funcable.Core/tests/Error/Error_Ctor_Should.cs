using FluentAssertions;
using Xunit;

using static Funcable.Core.Tests.FuncableTestFixture;

namespace Funcable.Core.Tests;

public class Error_Ctor_Should
{
	[Fact]
	public void Construct_Error_With_Message() =>
		new Error(HelloWorld)
			.Should()
			.Match<Error>(error => error.Message.Equals(HelloWorld))
			.And
			.Match<Error>(error => error.Code.Equals(string.Empty))
			.And
			.Match<Error>(error => error.Context == null);

	[Fact]
	public void Construct_Error_With_Message_And_Code() =>
		new Error(HelloWorld, Code: HolaMundo)
			.Should()
			.Match<Error>(error => error.Message.Equals(HelloWorld))
			.And
			.Match<Error>(error => error.Code.Equals(HolaMundo))
			.And
			.Match<Error>(error => error.Context == null);

	[Fact]
	public void Construct_Error_With_Message_And_Context() =>
		new Error(HelloWorld, Context: new Exception())
			.Should()
			.Match<Error>(error => error.Message.Equals(HelloWorld))
			.And
			.Match<Error>(error => error.Code.Equals(string.Empty))
			.And
			.Match<Error>(error => error.Context!.GetType().Equals(typeof(Exception)));

	[Fact]
	public void Construct_Error_With_Message_And_Code_And_Context() =>
		new Error(HelloWorld, Code: HolaMundo, Context: new Exception())
			.Should()
			.Match<Error>(error => error.Message.Equals(HelloWorld))
			.And
			.Match<Error>(error => error.Code.Equals(HolaMundo))
			.And
			.Match<Error>(error => error.Context!.GetType().Equals(typeof(Exception)));

}

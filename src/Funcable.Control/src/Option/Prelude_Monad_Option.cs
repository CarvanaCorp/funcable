using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IOption<U> Bind<T, U>(IOption<T> option, Func<T, IOption<U>> binder)
		where T : notnull
		where U : notnull =>
		Match(
			option,
			binder,
			None<U>()
		);
}

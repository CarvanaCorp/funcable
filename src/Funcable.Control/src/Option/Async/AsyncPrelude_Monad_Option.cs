using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IOption<U>> Bind<T, U>(
		Task<IOption<T>> option,
		Func<T, IOption<U>> binder)
		where T : notnull
		where U : notnull =>
		Bind(
			option,
			async t => await Task.FromResult(binder(t)).ConfigureAwait(false)
		);

	[Pure]
	public static Task<IOption<U>> Bind<T, U>(
		Task<IOption<T>> option,
		Func<T, Task<IOption<U>>> binder)
		where T : notnull
		where U : notnull =>
		Match(
			option,
			async t => await binder(t).ConfigureAwait(false),
			async () => await AsyncNone<U>().ConfigureAwait(false)
		);
}

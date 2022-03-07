using System.Diagnostics.Contracts;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static Task<IOption<T>> Flatten<T>(
		Task<IOption<Task<IOption<T>>>> option)
		where T : notnull =>
		Match(
			option,
			async o => await o.ConfigureAwait(false),
			async () => await AsyncNone<T>().ConfigureAwait(false)
		);

	[Pure]
	public static Task<IOption<T>> Flatten<T>(
		Task<IOption<IOption<T>>> option)
		where T : notnull =>
		Match(
			option,
			o => o,
			() => None<T>()
		);

	[Pure]
	public static Task<IOption<T>> Flatten<T>(
		IOption<Task<IOption<T>>> option)
		where T : notnull=>
		Match(
			option,
			o => o,
			() => AsyncNone<T>()
		);
}

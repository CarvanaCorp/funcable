using System.Diagnostics.Contracts;
using Funcable.Core;

namespace Funcable.Control;

public static partial class Prelude
{
	[Pure]
	public static IOption<U> Map<T, U>(IOption<T> option, Func<T, U> mapping)
		where T : notnull
		where U : notnull =>
		Match(
			option,
			t => Some(mapping(t)),
			None<U>()
		);
}

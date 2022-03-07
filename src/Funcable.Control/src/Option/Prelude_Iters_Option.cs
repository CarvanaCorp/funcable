namespace Funcable.Control;

public static partial class Prelude
{
	public static Unit Iterate<T>(IOption<T> option, Action<T> iterator)
		where T : notnull =>
		Match(
			option,
			t => { iterator(t); return Unit; },
			Unit
		);

	public static Unit Iterate<T>(IEnumerable<IOption<T>> options, Action<T> iterator)
		where T : notnull
	{
		foreach (var option in options) { Iterate(option, iterator); }
		return Unit;
	}
}

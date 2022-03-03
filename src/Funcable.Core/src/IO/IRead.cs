using System.Threading.Tasks;

namespace Funcable.Core.IO
{
	public interface IRead<TIn, TOut, TError>
		where TOut : notnull
		where TError : notnull
	{
		Task<IResult<TOut, TError>> Read(TIn value);
	}

	public interface IRead<TIn, UIn, TOut, TError>
		where TOut : notnull
		where TError : notnull
	{
		Task<IResult<TOut, TError>> Read(TIn valueT, UIn valueU);
	}

	public interface IRead<TIn, UIn, VIn, TOut, TError>
		where TOut : notnull
		where TError : notnull
	{
		Task<IResult<TOut, TError>> Read(TIn valueT, UIn valueU, VIn valueV);
	}
}

namespace Funcable.Core.IO;

public interface IWrite<TIn, TOut, TError>
	where TOut : notnull
	where TError : notnull
{
	Task<IResult<TOut, TError>> Write(TIn value);
}

public interface IWrite<TIn, UIn, TOut, TError>
	where TOut : notnull
	where TError : notnull
{
	Task<IResult<TOut, TError>> Write(TIn valueT, UIn valueU);
}

public interface IWrite<TIn, UIn, VIn, TOut, TError>
	where TOut : notnull
	where TError : notnull
{
	Task<IResult<TOut, TError>> Write(TIn valueT, UIn valueU, VIn valueV);
}

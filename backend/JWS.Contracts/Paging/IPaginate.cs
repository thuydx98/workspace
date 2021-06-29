using System.Collections.Generic;

namespace JWS.Contracts.Paging
{
	public interface IPaginate<TResult>
	{
		int Size { get; }
		int Page { get; }
		int Total { get; }
		IList<TResult> Items { get; }
	}
}

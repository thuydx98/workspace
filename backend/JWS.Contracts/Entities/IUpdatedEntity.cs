using System;

namespace JWS.Contracts.Entities
{
	public interface IUpdatedEntity
	{
		DateTime? UpdatedAt { get; set; }
		string UpdatedBy { get; set; }
	}
}

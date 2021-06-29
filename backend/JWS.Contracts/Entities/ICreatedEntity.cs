using System;

namespace JWS.Contracts.Entities
{
	public interface ICreatedEntity
	{
		DateTime? CreatedAt { get; set; }
		string CreatedBy { get; set; }
	}
}

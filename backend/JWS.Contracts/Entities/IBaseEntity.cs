using System.ComponentModel.DataAnnotations;

namespace JWS.Contracts.Entities
{
	public interface IBaseEntity<TKey>
	{
		[Key]
		public TKey Id { get; set; }
	}
}

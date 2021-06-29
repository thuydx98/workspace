using System.ComponentModel;

namespace JWS.Common.Enums
{
	public enum HeaderMediaType
	{
		[Description("application/json")]
		JSON,
		[Description("application/x-www-form-urlencoded")]
		FORM
	}
}

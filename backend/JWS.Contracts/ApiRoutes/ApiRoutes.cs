using System;

namespace JWS.Contracts.ApiRoutes
{
	public static class ApiRoutes
	{
		private const string Root = "api";

		public static class AssetHistories
		{
			private const string ControllerUri = Root + "/asset-histories";

			public const string GetPagingList = ControllerUri;
		}

		public static class Funds
		{
			private const string ControllerUri = Root + "/funds";

			public const string GetList = ControllerUri;
			public const string Add = ControllerUri;
			public const string Update = ControllerUri + "/{fundId}";
			public const string Delete = ControllerUri + "/{fundId}";
		}
	}
}

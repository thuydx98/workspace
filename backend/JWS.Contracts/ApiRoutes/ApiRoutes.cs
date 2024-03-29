﻿using System;

namespace JWS.Contracts.ApiRoutes
{
	public static class ApiRoutes
	{
		private const string Root = "api";

		public static class Assets
		{
			private const string ControllerUri = Root + "/assets";

			public const string Overview = ControllerUri + "/overview";
			public const string GetPagingList = ControllerUri;
			public const string Add = ControllerUri;
		}

		public static class Funds
		{
			private const string ControllerUri = Root + "/funds";

			public const string GetList = ControllerUri;
			public const string Get = ControllerUri + "/{fundId}";
			public const string Add = ControllerUri;
			public const string Update = ControllerUri + "/{fundId}";
			public const string Delete = ControllerUri + "/{fundId}";

			public static class Histories
			{
				private const string ControllerUri = Funds.ControllerUri + "/{fundId}/histories";

				public const string GetList = ControllerUri;
				public const string Add = ControllerUri;
			}

			public static class Investments
			{
				private const string ControllerUri = Funds.ControllerUri + "/{fundId}/investments";

				public const string GetPagingList = ControllerUri;
				public const string Add = ControllerUri;
				public const string Edit = ControllerUri + "/{investmentId}";
				public const string Delete = ControllerUri + "/{investmentId}";
			}

			public static class Criterias
			{
				private const string ControllerUri = Funds.ControllerUri + "/{fundId}/criterias";

				public const string Add = ControllerUri;
				public const string Edit = ControllerUri + "/{criteriaId}";
				public const string Delete = ControllerUri + "/{criteriaId}";
			}
		}

		public static class Posts
		{
			private const string ControllerUri = Root + "/posts";

			public const string GetList = ControllerUri;
			public const string Get = ControllerUri + "/{postId}";
			public const string Add = ControllerUri;
			public const string Edit = ControllerUri + "/{postId}";
			public const string Delete = ControllerUri + "/{postId}";
		}

		public static class Tasks
		{
			private const string ControllerUri = Root + "/tasks";

			public const string GetList = ControllerUri;
			public const string Add = ControllerUri;
			public const string Edit = ControllerUri + "/{taskId}";
			public const string Delete = ControllerUri + "/{taskId}";
		}
	}
}

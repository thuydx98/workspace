﻿using JWS.Service.Assets.Queries.GetPagingListAssetHistory;
using JWS.Service.Funds.Commands.AddFund;
using JWS.Service.Funds.Commands.DeleteFund;
using JWS.Service.Funds.Commands.UpdateFund;
using JWS.Service.Funds.Queries.GetListFund;
using Microsoft.Extensions.DependencyInjection;

namespace JWS.Infrastructure.Configures
{
    public static class Services
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
            #region Assets
            services.AddService<GetPagingListAssetHistoryRequest, GetPagingListAssetHistoryHandler>();
            #endregion

            #region Funds
            services.AddService<GetListFundRequest, GetListFundHandler>();
            services.AddService<AddFundRequest, AddFundHandler>();
            services.AddService<UpdateFundRequest, UpdateFundHandler>();
            services.AddService<DeleteFundRequest, DeleteFundHandler>();
            #endregion

            return services;
		}
	}
}
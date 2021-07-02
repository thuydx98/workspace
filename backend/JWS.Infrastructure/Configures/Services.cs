using JWS.Service.Assets.Commands.AddAsset;
using JWS.Service.Assets.Queries.GetPagingListAsset;
using JWS.Service.FundHistories.Commands.AddFundHistory;
using JWS.Service.FundHistories.Queries.GetPagingListFundHistory;
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
            services.AddService<GetPagingListAssetRequest, GetPagingListAssetHandler>();
            services.AddService<AddAssetRequest, AddAssetHandler>();
            #endregion

            #region Funds
            services.AddService<GetListFundRequest, GetListFundHandler>();
            services.AddService<AddFundRequest, AddFundHandler>();
            services.AddService<UpdateFundRequest, UpdateFundHandler>();
            services.AddService<DeleteFundRequest, DeleteFundHandler>();
            #endregion


            #region Fund Histories
            services.AddService<GetPagingListFundHistoryRequest, GetPagingListFundHistoryHandler>();
            services.AddService<AddFundHistoryRequest, AddFundHistoryHandler>();
            #endregion

            return services;
		}
	}
}

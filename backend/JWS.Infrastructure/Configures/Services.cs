using JWS.Service.Assets.Commands.AddAsset;
using JWS.Service.Assets.Queries.GetOverview;
using JWS.Service.Assets.Queries.GetPagingListAsset;
using JWS.Service.FundCriteria.Commands.AddEditFundCriteria;
using JWS.Service.FundCriteria.Commands.DeleteFundCriteria;
using JWS.Service.FundHistories.Commands.AddFundHistory;
using JWS.Service.FundHistories.Queries.GetPagingListFundHistory;
using JWS.Service.FundInvestments.Commands.AddEditFundInvestment;
using JWS.Service.FundInvestments.Commands.DeleteFundInvestment;
using JWS.Service.FundInvestments.Jobs.SyncStockPrice;
using JWS.Service.FundInvestments.Queries.GetPagingListFundInvestment;
using JWS.Service.Funds.Commands.AddFund;
using JWS.Service.Funds.Commands.DeleteFund;
using JWS.Service.Funds.Commands.UpdateFund;
using JWS.Service.Funds.Queries.GetFund;
using JWS.Service.Funds.Queries.GetListFund;
using JWS.Service.Posts.Commands.AddEditPost;
using JWS.Service.Posts.Commands.DeletePost;
using JWS.Service.Posts.Queries.GetPostById;
using JWS.Service.Posts.Queries.GetPostsByUserId;
using JWS.Service.Tasks.Commands.AddEditTask;
using JWS.Service.Tasks.Commands.DeleteTask;
using JWS.Service.Tasks.Queries.GetListTask;
using Microsoft.Extensions.DependencyInjection;

namespace JWS.Infrastructure.Configures
{
    public static class Services
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            #region Assets
            services.AddService<GetOverviewRequest, GetOverviewHandler>();
            services.AddService<GetPagingListAssetRequest, GetPagingListAssetHandler>();
            services.AddService<AddAssetRequest, AddAssetHandler>();
            #endregion

            #region Funds
            services.AddService<GetListFundRequest, GetListFundHandler>();
            services.AddService<GetFundRequest, GetFundHandler>();
            services.AddService<AddFundRequest, AddFundHandler>();
            services.AddService<UpdateFundRequest, UpdateFundHandler>();
            services.AddService<DeleteFundRequest, DeleteFundHandler>();
            #endregion

            #region Fund Histories
            services.AddService<GetPagingListFundHistoryRequest, GetPagingListFundHistoryHandler>();
            services.AddService<AddFundHistoryRequest, AddFundHistoryHandler>();
            #endregion

            #region Fund Investments
            services.AddHostedService<SyncStockPriceJob>();
            services.AddService<GetPagingListFundInvestmentRequest, GetPagingListFundInvestmentHandler>();
            services.AddService<AddEditFundInvestmentRequest, AddEditFundInvestmentHandler>();
            services.AddService<DeleteFundInvestmentRequest, DeleteFundInvestmentHandler>();
            #endregion

            #region Fund Criteries
            services.AddService<AddEditFundCriteriaRequest, AddEditFundCriteriaHandler>();
            services.AddService<DeleteFundCriteriaRequest, DeleteFundCriteriaHandler>();
            #endregion

            #region Posts
            services.AddService<AddEditPostRequest, AddEditPostHandler>();
            services.AddService<DeletePostRequest, DeletePostHandler>();
            services.AddService<GetPostsByUserIdRequest, GetPostsByUserIdHandler>();
            services.AddService<GetPostByIdRequest, GetPostByIdHandler>();
            #endregion

            #region Tasks
            services.AddService<AddEditTaskRequest, AddEditTaskHandler>();
            services.AddService<DeleteTaskRequest, DeleteTaskHandler>();
            services.AddService<GetListTaskRequest, GetListTaskHandler>();
            #endregion

            return services;
        }
    }
}

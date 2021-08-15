using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.Funds.ViewModels;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Funds.Queries.GetListFund
{
    public class GetListFundHandler : IRequestHandler<GetListFundRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetListFundHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult> Handle(GetListFundRequest request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue || request.UserId == Guid.Empty)
            {
                return ApiResult.Failed(HttpCode.BadRequest);
            }

            var funds = await _unitOfWork.GetRepository<FundEntity>().GetListAsync(
                selector: n => new FundViewModel
                {
                    Id = n.Id,
                    Name = n.Name,
                    Total = 
                        n.FundHistories.Where(n => n.Type == FundHistoryType.RECHARGE).Sum(n => n.Amount) - 
                        n.FundHistories.Where(n => n.Type == FundHistoryType.WITHDRAW).Sum(n => n.Amount),
                    Invest = 0,
                },
                predicate: n => !n.IsDeleted && n.UserId == request.UserId,
                orderBy: n => n.OrderByDescending(o => o.CreatedAt),
                cancellationToken: cancellationToken);

            return ApiResult.Succeeded(funds);
        }
    }
}

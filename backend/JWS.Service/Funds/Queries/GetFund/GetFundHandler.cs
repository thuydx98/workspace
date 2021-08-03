using JWS.Common.ApiResponse;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.Funds.ViewModels;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Funds.Queries.GetFund
{
    public class GetFundHandler : IRequestHandler<GetFundRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetFundHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult> Handle(GetFundRequest request, CancellationToken cancellationToken)
        {
            var fund = await _unitOfWork.GetRepository<FundEntity>().SingleOrDefaultAsync(
                selector: n => new FundViewModel
                {
                    Id = n.Id,
                    Name = n.Name,
                    Total = 
                        n.FundHistories.Sum(n => n.Amount) - 
                        n.FundHistories.Where(n => n.Type == FundHistoryType.WITHDRAW).Sum(n => n.Amount)
                },
                predicate: n => !n.IsDeleted && n.Id == request.FundId && n.UserId == request.UserId,
                orderBy: n => n.OrderByDescending(o => o.CreatedAt),
                cancellationToken: cancellationToken);

            return ApiResult.Succeeded(fund);
        }
    }
}

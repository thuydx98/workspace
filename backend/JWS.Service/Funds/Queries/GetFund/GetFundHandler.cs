using AutoMapper;
using JWS.Common.ApiResponse;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.FundCriteria.ViewModels;
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
        private readonly IMapper _mapper;

        public GetFundHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult> Handle(GetFundRequest request, CancellationToken cancellationToken)
        {
            var fund = await _unitOfWork.GetRepository<FundEntity>().SingleOrDefaultAsync(
                selector: n => new FundViewModel
                {
                    Id = n.Id,
                    Name = n.Name,
                    Type = n.Type.HasValue ? n.Type.ToString() : null,
                    Capital =
                        n.Histories.Where(n => n.Type == FundHistoryType.RECHARGE).Sum(n => n.Amount) -
                        n.Histories.Where(n => n.Type == FundHistoryType.WITHDRAW).Sum(n => n.Amount),
                    Reality =
                        n.Histories.Where(n => n.Type == FundHistoryType.RECHARGE).Sum(n => n.Amount) -
                        n.Histories.Where(n => n.Type == FundHistoryType.WITHDRAW).Sum(n => n.Amount) +
                        n.Investments.Where(n => n.Status == FundInvestmentStatus.COMPLETED).Sum(n => n.FinalProfit),
                    Invest = 
                        n.Investments.Where(n => n.Status == FundInvestmentStatus.INVESTING).Sum(n => n.TotalCapital),
                    RealityInvest =
                        n.Investments.Where(n => n.Status == FundInvestmentStatus.INVESTING).Sum(n => n.TotalCapital + n.FinalProfit),

                    Criterias = n.Criterias.OrderBy(o => o.Name).Select(s => _mapper.Map<FundCriteriaViewModel>(s)).ToArray(),
                },
                predicate: n => !n.IsDeleted && n.Id == request.FundId && n.UserId == request.UserId,
                cancellationToken: cancellationToken);

            return ApiResult.Succeeded(fund);
        }
    }
}

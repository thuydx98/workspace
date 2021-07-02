using AutoMapper;
using JWS.Common.ApiResponse;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.FundHistories.ViewModels;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.FundHistories.Queries.GetPagingListFundHistory
{
    public class GetPagingListFundHistoryHandler : IRequestHandler<GetPagingListFundHistoryRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPagingListFundHistoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult> Handle(GetPagingListFundHistoryRequest request, CancellationToken cancellationToken)
        {
            var funds = await _unitOfWork.GetRepository<FundHistoryEntity>().GetPagingListAsync(
                selector: n => _mapper.Map<FundHistoryViewModel>(n),
                predicate: n => n.Id == request.FundId && n.Fund.UserId == request.UserId,
                orderBy: n => n.OrderByDescending(o => o.At),
                page: request.Page,
                size: request.Size,
                cancellationToken: cancellationToken);

            return ApiResult.Succeeded(funds);
        }
    }
}

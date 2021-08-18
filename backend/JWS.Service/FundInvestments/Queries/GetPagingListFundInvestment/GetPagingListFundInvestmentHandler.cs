using AutoMapper;
using JWS.Common.ApiResponse;
using JWS.Common.Extensions;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.FundInvestments.ViewModels;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.FundInvestments.Queries.GetPagingListFundInvestment
{
    public class GetPagingListFundInvestmentHandler : IRequestHandler<GetPagingListFundInvestmentRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPagingListFundInvestmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult> Handle(GetPagingListFundInvestmentRequest request, CancellationToken cancellationToken)
        {
            var predicate = BuildPredicate(request);

            var funds = await _unitOfWork.GetRepository<FundInvestmentEntity>().GetPagingListAsync(
                selector: n => _mapper.Map<FundInvestmentViewModel>(n),
                predicate: predicate,
                orderBy: n => n.OrderByDescending(o => o.CreatedAt),
                page: request.Page,
                size: request.Size,
                cancellationToken: cancellationToken);

            return ApiResult.Succeeded(funds);
        }

		private Expression<Func<FundInvestmentEntity, bool>> BuildPredicate(GetPagingListFundInvestmentRequest request)
		{
			Expression<Func<FundInvestmentEntity, bool>> filterQuery = n => n.FundId == request.FundId && n.Fund.UserId == request.UserId;

			if (request.MinCriteria.HasValue)
			{
				filterQuery = filterQuery.AndAlso(p => true);
			}

			if (request.Statuses.IsNotEmpty())
			{
				var statuses = request.Statuses.Split(',').Select(item => Enum.Parse<FundInvestmentStatus>(item)).ToList();
                filterQuery = filterQuery.AndAlso(p => statuses.Contains(p.Status));
			}

			return filterQuery;
		}
	}
}

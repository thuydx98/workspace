using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.FundCriteria.Commands.DeleteFundCriteria
{
    public class DeleteFundCriteriaHandler : IRequestHandler<DeleteFundCriteriaRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFundCriteriaHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult> Handle(DeleteFundCriteriaRequest request, CancellationToken cancellationToken)
        {
            var criteria = await _unitOfWork.GetRepository<FundCriteriaEntity>().SingleOrDefaultAsync(
                predicate: n => n.Id == request.CriteriaId && n.FundId == request.FundId && n.Fund.UserId == request.UserId,
                asNoTracking: false,
                cancellationToken: cancellationToken);

            if (criteria == null)
            {
                return ApiResult.Failed(HttpCode.Notfound);
            }

            _unitOfWork.GetRepository<FundCriteriaEntity>().Delete(criteria);

            await _unitOfWork.CommitAsync();

            return ApiResult.Succeeded();
        }
    }
}

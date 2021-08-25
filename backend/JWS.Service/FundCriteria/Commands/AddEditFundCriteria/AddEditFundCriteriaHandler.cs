using AutoMapper;
using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.FundCriteria.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.FundCriteria.Commands.AddEditFundCriteria
{
    public class AddEditFundCriteriaHandler : IRequestHandler<AddEditFundCriteriaRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddEditFundCriteriaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResult> Handle(AddEditFundCriteriaRequest request, CancellationToken cancellationToken)
        {
            FundCriteriaEntity criteria = null;

            if (request.CriteriaId.HasValue)
            {
                criteria = await _unitOfWork.GetRepository<FundCriteriaEntity>().SingleOrDefaultAsync(
                    predicate: n => !n.IsDeleted && n.Id == request.CriteriaId && n.FundId == request.FundId && n.Fund.UserId == request.UserId,
                    cancellationToken: cancellationToken);

                if (criteria == null)
                {
                    return ApiResult.Failed(HttpCode.Notfound);
                }
            }

            criteria ??= new FundCriteriaEntity();

            criteria.Name = request.Name;
            criteria.FundId = request.FundId;

            if (request.CriteriaId.HasValue)
            {
                _unitOfWork.GetRepository<FundCriteriaEntity>().Update(criteria);
            }
            else
            {
                _unitOfWork.GetRepository<FundCriteriaEntity>().Insert(criteria);
            }

            await _unitOfWork.CommitAsync();

            return ApiResult.Succeeded(_mapper.Map<FundCriteriaViewModel>(criteria));
        }
    }
}

using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.Funds.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Funds.Commands.DeleteFund
{
    public class DeleteFundHandler : IRequestHandler<DeleteFundRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DeleteFundHandler(IUnitOfWork unitOfWork, ILogger<DeleteFundHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResult> Handle(DeleteFundRequest request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue || request.UserId == Guid.Empty || request.FundId == Guid.Empty)
            {
                return ApiResult.Failed(HttpCode.BadRequest);
            }

            try
            {
                var fund = await _unitOfWork.GetRepository<FundEntity>().SingleOrDefaultAsync(
                    predicate: n => n.Id == request.FundId && n.UserId == request.UserId.Value,
                    cancellationToken: cancellationToken);

                if (fund == null)
                {
                    return ApiResult.Failed(HttpCode.Notfound);
                }

                fund.IsDeleted = true;

                _unitOfWork.GetRepository<FundEntity>().Update(fund);

                await _unitOfWork.CommitAsync();

                return ApiResult.Succeeded(new FundViewModel
                {
                    Id = fund.Id,
                    Name = fund.Name,
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return ApiResult.Failed(HttpCode.InternalServerError);
            }
        }
    }
}

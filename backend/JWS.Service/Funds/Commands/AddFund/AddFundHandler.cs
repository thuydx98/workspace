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

namespace JWS.Service.Funds.Commands.AddFund
{
    public class AddFundHandler : IRequestHandler<AddFundRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public AddFundHandler(IUnitOfWork unitOfWork, ILogger<AddFundHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResult> Handle(AddFundRequest request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue || request.UserId == Guid.Empty)
            {
                return ApiResult.Failed(HttpCode.BadRequest);
            }

            try
            {
                var fund = new FundEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = request.UserId.Value,
                    Name = request.Name,
                };

                await _unitOfWork.GetRepository<FundEntity>().InsertAsync(fund);
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

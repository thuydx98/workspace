using AutoMapper;
using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.FundHistories.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.FundHistories.Commands.AddFundHistory
{
    public class AddFundHistoryHandler : IRequestHandler<AddFundHistoryRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AddFundHistoryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AddFundHistoryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResult> Handle(AddFundHistoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var fund = await _unitOfWork.GetRepository<FundEntity>().SingleOrDefaultAsync(
                    predicate: n => n.Id == request.FundId && n.UserId == request.UserId,
                    cancellationToken: cancellationToken);

                if (fund == null)
                {
                    return ApiResult.Failed(HttpCode.Notfound);
                }

                var history = new FundHistoryEntity
                {
                    Id = Guid.NewGuid(),
                    Type = request.Type,
                    Amount = request.Amount,
                    Note = request.Note,
                    At = request.At,
                    FundId = fund.Id,
                };

                await _unitOfWork.GetRepository<FundHistoryEntity>().InsertAsync(history);
                await _unitOfWork.CommitAsync();

                return ApiResult.Succeeded(_mapper.Map<FundHistoryViewModel>(history));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return ApiResult.Failed(HttpCode.InternalServerError);
            }
        }
    }
}

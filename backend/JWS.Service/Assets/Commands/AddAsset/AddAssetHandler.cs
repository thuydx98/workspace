using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.Assets.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Assets.Commands.AddAsset
{
    public class AddAssetHandler : IRequestHandler<AddAssetRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public AddAssetHandler(IUnitOfWork unitOfWork, ILogger<AddAssetHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResult> Handle(AddAssetRequest request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue || request.UserId == Guid.Empty)
            {
                return ApiResult.Failed(HttpCode.BadRequest);
            }

            var asset = new AssetEntity
            {
                Id = Guid.NewGuid(),
                At = request.At,
                UserId = request.UserId.Value,
                Amount = request.Amount,
                Type = AssetType.INCOME,
                Note = request.Note,
            };

            try
            {
                await _unitOfWork.GetRepository<AssetEntity>().InsertAsync(asset);
                await _unitOfWork.CommitAsync();

                return ApiResult.Succeeded(new AssetViewModel
                {
                    Id = asset.Id,
                    Type = asset.Type.ToString(),
                    Amount = asset.Amount,
                    At = asset.At,
                    Note = asset.Note,
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

using JWS.Common.ApiResponse;
using JWS.Data.Entities;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace JWS.Service.Assets.Commands.AddAsset
{
    public class AddAssetRequest : IRequest<ApiResult>
    {
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime At { get; set; }
        [Required]
        public AssetType Type { get; set; }

        public string Note { get; set; }
        public Guid? UserId { get; set; }
    }
}

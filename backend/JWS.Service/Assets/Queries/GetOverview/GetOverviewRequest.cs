using JWS.Common.ApiResponse;
using MediatR;
using System;

namespace JWS.Service.Assets.Queries.GetOverview
{
    public class GetOverviewRequest : IRequest<ApiResult>
    {
        public Guid? UserId { get; set; }
    }
}

using JWS.Common.ApiResponse;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Posts.Queries.GetPostsByUserId
{
    public class GetPostsByUserIdHandler : IRequestHandler<GetPostsByUserIdRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPostsByUserIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult> Handle(GetPostsByUserIdRequest request, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.GetRepository<PostEntity>().GetListAsync(
                selector: n => new
                {
                    n.Id,
                    n.Title,
                    n.ParentId,
                },
                predicate: n => !n.IsDeleted && n.UserId == request.UserId,
                orderBy: n => n.OrderBy(o => o.CreatedAt),
                cancellationToken: cancellationToken);

            return ApiResult.Succeeded(posts);
        }
    }
}

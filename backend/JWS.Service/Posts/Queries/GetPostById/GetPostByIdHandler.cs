using JWS.Common.ApiResponse;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.Posts.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Posts.Queries.GetPostById
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPostByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.GetRepository<PostEntity>().SingleOrDefaultAsync(
                selector: n => new PostViewModel(n),
                predicate: n => !n.IsDeleted && n.UserId == request.UserId && n.Id == request.PostId,
                cancellationToken: cancellationToken);

            return ApiResult.Succeeded(post);
        }
    }
}

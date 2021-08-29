using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Posts.Commands.DeletePost
{
    public class DeletePostHandler : IRequestHandler<DeletePostRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DeletePostHandler(IUnitOfWork unitOfWork, ILogger<DeletePostHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResult> Handle(DeletePostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var post = await _unitOfWork.GetRepository<PostEntity>().SingleOrDefaultAsync(
                    predicate: n => !n.IsDeleted && n.UserId == request.UserId && n.Id == request.Id,
                    include: n => n.Include(i => i.Children),
                    asNoTracking: false,
                    cancellationToken: cancellationToken);

                if (post == null)
                {
                    return ApiResult.Failed(HttpCode.Notfound);
                }

                if (request.IsDeleteChilren)
                {
                    await RecursiveDeleteAsync(post.Children, cancellationToken);
                }
                else
                {
                    foreach (var item in post.Children)
                    {
                        item.ParentId = post.ParentId;
                    }

                    _unitOfWork.GetRepository<PostEntity>().Update(post.Children);
                }

                post.IsDeleted = true;

                _unitOfWork.GetRepository<PostEntity>().Update(post);

                await _unitOfWork.CommitAsync();

                return ApiResult.Succeeded();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error at: {DateTime.UtcNow.ToString()} (UTC)");
                return ApiResult.Failed(HttpCode.InternalServerError);
            }
        }

        private async Task RecursiveDeleteAsync(ICollection<PostEntity> children, CancellationToken cancellationToken)
        {
            if (children != null && children.Count > 0)
            {
                foreach (var item in children)
                {
                    var posts = await _unitOfWork.GetRepository<PostEntity>().GetListAsync(
                        predicate: n => !n.IsDeleted && n.ParentId == item.Id,
                        include: n => n.Include(i => i.Children),
                        asNoTracking: false,
                        cancellationToken: cancellationToken);

                    await RecursiveDeleteAsync(posts, cancellationToken);

                    item.IsDeleted = true;

                    _unitOfWork.GetRepository<PostEntity>().Update(item);
                }
            }
        }
    }
}

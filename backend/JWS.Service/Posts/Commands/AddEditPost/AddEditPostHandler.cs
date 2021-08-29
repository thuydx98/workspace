using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.Posts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Posts.Commands.AddEditPost
{
    public class AddEditPostHandler : IRequestHandler<AddEditPostRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public AddEditPostHandler(IUnitOfWork unitOfWork, ILogger<AddEditPostHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResult> Handle(AddEditPostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                PostEntity post = null;
                if (request.Id.HasValue)
                {
                    post = await _unitOfWork.GetRepository<PostEntity>().SingleOrDefaultAsync(
                        predicate: n => !n.IsDeleted && n.UserId == request.UserId && n.Id == request.Id,
                        include: n => n.Include(i => i.Tags),
                        asNoTracking: false,
                        cancellationToken: cancellationToken);

                    if (post == null)
                    {
                        return ApiResult.Failed(HttpCode.Notfound);
                    }
                }

                post ??= new PostEntity();

                if (!request.Id.HasValue)
                {
                    post.Title = request.Title;
                    post.UserId = request.UserId.Value;
                    post.ParentId = request.ParentId;
                }
                else
                {
                    _unitOfWork.GetRepository<PostTagEntity>().Delete(post.Tags);

                    post.Title = request.Title;
                    post.AvaterUrl = request.AvaterUrl;
                    post.Content = request.Content;
                    post.Tags = request.Tags.Select(tag => new PostTagEntity
                    {
                        Tag = tag,
                    }).ToArray();
                }

                if (request.Id.HasValue)
                {
                    _unitOfWork.GetRepository<PostEntity>().Update(post);
                }
                else
                {
                    _unitOfWork.GetRepository<PostEntity>().Insert(post);
                }

                await _unitOfWork.CommitAsync();

                return ApiResult.Succeeded(new PostViewModel(post));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error at: {DateTime.UtcNow.ToString()} (UTC)");
                return ApiResult.Failed(HttpCode.InternalServerError);
            }
        }
    }
}
